using System.Collections.Generic;
using System.Linq;
using HarmonyLib;
using Klei;
using KMod;
using Newtonsoft.Json;
using ProcGen;
using STRINGS;


namespace EthanolGeyser
{
    public class EthanolGeyserPatches : UserMod2
    {
        public const string Id = "chilled_ethanol";
        public static string Name = UI.FormatAsLink("Chilled Ethanol Geyser", $"GeyserGeneric_{Id.ToUpper()}");
        public static string Description = $"A highly pressurized geyser that periodically erupts with {UI.FormatAsLink("Chilled Ethanol", "ETHANOL")}.";

        [HarmonyPatch(typeof(Worlds), "UpdateWorldCache")]
        public class Worlds_UpdateWorldCache_Patch
        {
            private static void Postfix(Worlds __instance, string path, string prefix, ISet<string> referencedWorlds, List<YamlIO.Error> errors)
            {
                var json = "{\"names\":[\"poi/poi_rust_geyser_ethanol\"],\"listRule\":5,\"someCount\":3,\"moreCount\":0,\"times\":3,\"priority\":10,\"allowDuplicates\":true,\"allowExtremeTemperatureOverlap\":false,\"useRelaxedFiltering\":false,\"allowedCellsFilter\":[{\"tagcommand\":3,\"tag\":\"AtDepths\",\"minDistance\":2,\"maxDistance\":10,\"command\":1,\"temperatureRanges\":[],\"zoneTypes\":[],\"subworldNames\":[]},{\"tagcommand\":0,\"tag\":null,\"minDistance\":0,\"maxDistance\":0,\"command\":1,\"temperatureRanges\":[],\"zoneTypes\":[0],\"subworldNames\":[]},{\"tagcommand\":1,\"tag\":\"NoGlobalFeatureSpawning\",\"minDistance\":0,\"maxDistance\":0,\"command\":4,\"temperatureRanges\":[],\"zoneTypes\":[],\"subworldNames\":[]}]}";

                var templateSpawnRules = JsonConvert.DeserializeObject<ProcGen.World.TemplateSpawnRules>(json, new JsonSerializerSettings()
                {
                    ContractResolver = new PrivateResolver(),
                    ConstructorHandling = ConstructorHandling.AllowNonPublicDefaultConstructor
                });

                foreach (var world in __instance.worldCache)
                {
                    if (!world.Value.worldTemplateRules.Any(x => x.names.Contains("poi_rust_geyser_ethanol")))
                    {
                        //UnityEngine.Debug.Log(JsonConvert.SerializeObject(world.Value));
                        world.Value.worldTemplateRules.Add(templateSpawnRules);
                    }
                }
            }
        }

        [HarmonyPatch(typeof(GeyserGenericConfig))]
        [HarmonyPatch("GenerateConfigs")]
        public class GeyserGenericConfig_GenerateConfigs_Patch
        {
            private static void Postfix(List<GeyserGenericConfig.GeyserPrefabParams> __result)
            {
                Strings.Add($"STRINGS.CREATURES.SPECIES.GEYSER.{Id.ToUpper()}.NAME", Name);
                Strings.Add($"STRINGS.CREATURES.SPECIES.GEYSER.{Id.ToUpper()}.DESC", Description);

                __result.Add(new GeyserGenericConfig.GeyserPrefabParams("geyserliquidethanolchilled_kanim", 4, 2, new GeyserConfigurator.GeyserType(Id, SimHashes.Ethanol, GeyserConfigurator.GeyserShape.Liquid, 263.15f, 1000f, 2000f, 500f), false));
            }
        }
    }
}
