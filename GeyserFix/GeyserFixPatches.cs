#region

using System.Collections.Generic;
using Harmony;

#endregion

namespace GeyserFix
{
    [HarmonyPatch(typeof(GeyserGenericConfig))]
    [HarmonyPatch("GenerateConfigs")]
    public class GeyserGenPath
    {
        private static void Postfix(List<GeyserGenericConfig.GeyserPrefabParams> __result)
        {
            var geyserToRemove = new[]
            {
                "geyser_molten_volcano_small_kanim",
                "geyser_liquid_co2_kanim",
                "geyser_gas_co2_hot_kanim",
                "geyser_gas_chlorine_kanim"
            };
            foreach (var geyser in geyserToRemove)
            {
                __result.RemoveAll(x => x.anim == geyser);
            }
        }
    }

    //[HarmonyPatch(typeof(GeyserGenericConfig))]
    //[HarmonyPatch("CreatePrefabs")]
    //public class GeyserGenPath
    //{
    //    private static List<GeyserGenericConfig.GeyserPrefabParams> GenerateConfigs()
    //    {
    //        List<GeyserGenericConfig.GeyserPrefabParams> list = new List<GeyserGenericConfig.GeyserPrefabParams>();
    //        list.Add(new GeyserGenericConfig.GeyserPrefabParams("geyser_gas_steam_kanim", 2, 4, new GeyserConfigurator.GeyserType("steam", SimHashes.Steam, 383.15f, 1000f, 2000f, 5f)));
    //        list.Add(new GeyserGenericConfig.GeyserPrefabParams("geyser_gas_steam_hot_kanim", 2, 4, new GeyserConfigurator.GeyserType("hot_steam", SimHashes.Steam, 773.15f, 500f, 1000f, 5f)));
    //        list.Add(new GeyserGenericConfig.GeyserPrefabParams("geyser_liquid_water_hot_kanim", 4, 2, new GeyserConfigurator.GeyserType("hot_water", SimHashes.Water, 368.15f, 2000f, 4000f, 500f)));
    //        list.Add(new GeyserGenericConfig.GeyserPrefabParams("geyser_liquid_water_slush_kanim", 4, 2, new GeyserConfigurator.GeyserType("slush_water", SimHashes.DirtyWater, 263.15f, 1000f, 2000f, 500f)));
    //        list.Add(new GeyserGenericConfig.GeyserPrefabParams("geyser_liquid_water_filthy_kanim", 4, 2, new GeyserConfigurator.GeyserType("filthy_water", SimHashes.DirtyWater, 303.15f, 2000f, 4000f, 500f).AddDisease(new SimUtil.DiseaseInfo
    //        {
    //            idx = Db.Get().Diseases.GetIndex("FoodPoisoning"),
    //            count = 20000
    //        })));
    //        list.Add(new GeyserGenericConfig.GeyserPrefabParams("geyser_liquid_salt_water_kanim", 4, 2, new GeyserConfigurator.GeyserType("salt_water", SimHashes.SaltWater, 368.15f, 2000f, 4000f, 500f)));
    //        //list.Add(new GeyserGenericConfig.GeyserPrefabParams("geyser_molten_volcano_small_kanim", 3, 3, new GeyserConfigurator.GeyserType("small_volcano", SimHashes.Magma, 2000f, 400f, 800f, 150f, 6000f, 12000f, 0.005f, 0.01f)));
    //        list.Add(new GeyserGenericConfig.GeyserPrefabParams("geyser_molten_volcano_big_kanim", 3, 3, new GeyserConfigurator.GeyserType("big_volcano", SimHashes.Magma, 2000f, 800f, 1600f, 150f, 6000f, 12000f, 0.005f, 0.01f)));
    //        //list.Add(new GeyserGenericConfig.GeyserPrefabParams("geyser_liquid_co2_kanim", 4, 2, new GeyserConfigurator.GeyserType("liquid_co2", SimHashes.LiquidCarbonDioxide, 218f, 100f, 200f, 50f)));
    //        //list.Add(new GeyserGenericConfig.GeyserPrefabParams("geyser_gas_co2_hot_kanim", 2, 4, new GeyserConfigurator.GeyserType("hot_co2", SimHashes.CarbonDioxide, 773.15f, 70f, 140f, 5f)));
    //        list.Add(new GeyserGenericConfig.GeyserPrefabParams("geyser_gas_hydrogen_hot_kanim", 2, 4, new GeyserConfigurator.GeyserType("hot_hydrogen", SimHashes.Hydrogen, 773.15f, 70f, 140f, 5f)));
    //        list.Add(new GeyserGenericConfig.GeyserPrefabParams("geyser_gas_po2_hot_kanim", 2, 4, new GeyserConfigurator.GeyserType("hot_po2", SimHashes.ContaminatedOxygen, 773.15f, 70f, 140f, 5f)));
    //        list.Add(new GeyserGenericConfig.GeyserPrefabParams("geyser_gas_po2_slimy_kanim", 2, 4, new GeyserConfigurator.GeyserType("slimy_po2", SimHashes.ContaminatedOxygen, 333.15f, 70f, 140f, 5f).AddDisease(new SimUtil.DiseaseInfo
    //        {
    //            idx = Db.Get().Diseases.GetIndex("SlimeLung"),
    //            count = 5000
    //        })));
    //        //list.Add(new GeyserGenericConfig.GeyserPrefabParams("geyser_gas_chlorine_kanim", 2, 4, new GeyserConfigurator.GeyserType("chlorine_gas", SimHashes.ChlorineGas, 333.15f, 70f, 140f, 5f)));
    //        list.Add(new GeyserGenericConfig.GeyserPrefabParams("geyser_gas_methane_kanim", 2, 4, new GeyserConfigurator.GeyserType("methane", SimHashes.Methane, 423.15f, 70f, 140f, 5f)));
    //        list.Add(new GeyserGenericConfig.GeyserPrefabParams("geyser_molten_copper_kanim", 3, 3, new GeyserConfigurator.GeyserType("molten_copper", SimHashes.MoltenCopper, 2500f, 200f, 400f, 150f, 480f, 1080f, 0.0166666675f, 0.1f)));
    //        list.Add(new GeyserGenericConfig.GeyserPrefabParams("geyser_molten_iron_kanim", 3, 3, new GeyserConfigurator.GeyserType("molten_iron", SimHashes.MoltenIron, 2800f, 200f, 400f, 150f, 480f, 1080f, 0.0166666675f, 0.1f)));
    //        list.Add(new GeyserGenericConfig.GeyserPrefabParams("geyser_molten_gold_kanim", 3, 3, new GeyserConfigurator.GeyserType("molten_gold", SimHashes.MoltenGold, 2900f, 200f, 400f, 150f, 480f, 1080f, 0.0166666675f, 0.1f)));
    //        list.Add(new GeyserGenericConfig.GeyserPrefabParams("geyser_liquid_oil_kanim", 4, 2, new GeyserConfigurator.GeyserType("oil_drip", SimHashes.CrudeOil, 600f, 1f, 250f, 50f, 600f, 600f, 1f, 1f, 100f, 500f)));
    //        list.Add(new GeyserGenericConfig.GeyserPrefabParams("geyser_liquid_ethanol_chilled", 4, 2, new GeyserConfigurator.GeyserType("chilled_ethanol", SimHashes.Ethanol, 263.15f, 1000f, 2000f, 500f, 60f, 1140f, 0.1f, 0.9f, 15000f, 135000f, 0.4f, 0.8f)));
    //        return list;
    //    }

    //    private static GameObject CreateGeyser(string id, string anim, int width, int height, string name, string desc, HashedString presetType)
    //    {
    //        float mass = 2000f;
    //        GameObject gameObject = EntityTemplates.CreatePlacedEntity(id, name, desc, mass, Assets.GetAnim(anim), "inactive", Grid.SceneLayer.BuildingBack, width, height, BUILDINGS.DECOR.BONUS.TIER1, NOISE_POLLUTION.NOISY.TIER6);
    //        gameObject.AddOrGet<OccupyArea>().objectLayers = new ObjectLayer[1]
    //        {
    //            ObjectLayer.Building
    //        };
    //        PrimaryElement component = gameObject.GetComponent<PrimaryElement>();
    //        component.SetElement(SimHashes.Katairite);
    //        component.Temperature = 372.15f;
    //        gameObject.AddOrGet<Prioritizable>();
    //        gameObject.AddOrGet<Uncoverable>();
    //        Geyser geyser = gameObject.AddOrGet<Geyser>();
    //        geyser.outputOffset = new Vector2I(0, 1);
    //        GeyserConfigurator geyserConfigurator = gameObject.AddOrGet<GeyserConfigurator>();
    //        geyserConfigurator.presetType = presetType;
    //        Studyable studyable = gameObject.AddOrGet<Studyable>();
    //        studyable.meterTrackerSymbol = "geotracker_target";
    //        studyable.meterAnim = "tracker";
    //        gameObject.AddOrGet<LoopingSounds>();
    //        SoundEventVolumeCache.instance.AddVolume("geyser_side_steam_kanim", "Geyser_shake_LP", NOISE_POLLUTION.NOISY.TIER5);
    //        SoundEventVolumeCache.instance.AddVolume("geyser_side_steam_kanim", "Geyser_erupt_LP", NOISE_POLLUTION.NOISY.TIER6);
    //        return gameObject;
    //    }

    //    public static bool Prefix(ref List<GameObject> __result)
    //    {
    //        try
    //        {
    //            Debug.Log("--PATCHED! CreatePrefabs");

    //            List<GameObject> list = new List<GameObject>();
    //            List<GeyserGenericConfig.GeyserPrefabParams> configs = GenerateConfigs();
    //            foreach (GeyserGenericConfig.GeyserPrefabParams item in configs)
    //            {
    //                list.Add(CreateGeyser(item.id, item.anim, item.width, item.height, Strings.Get(item.nameStringKey), Strings.Get(item.descStringKey), item.geyserType.idHash));
    //            }

    //            GameObject gameObject = EntityTemplates.CreateEntity("GeyserGeneric", "Random Geyser Spawner");
    //            gameObject.AddOrGet<SaveLoadRoot>();
    //            KPrefabID component = gameObject.GetComponent<KPrefabID>();
    //            component.prefabInitFn += delegate (GameObject inst)
    //            {
    //                int num = 0;
    //                if (SaveLoader.Instance.worldDetailSave != null)
    //                {
    //                    num = SaveLoader.Instance.worldDetailSave.globalWorldSeed;
    //                }
    //                else
    //                {
    //                    Debug.LogWarning("Could not load global world seed for geysers");
    //                }

    //                int num2 = num;
    //                Vector3 position = inst.transform.GetPosition();
    //                int num3 = num2 + (int)position.x;
    //                Vector3 position2 = inst.transform.GetPosition();
    //                num = num3 + (int)position2.y;
    //                System.Random random = new System.Random(num);
    //                int index = random.Next(0, configs.Count);

    //                GeyserGenericConfig.GeyserPrefabParams geyserPrefabParams = configs[index];
    //                GameObject gameObject2 = GameUtil.KInstantiate(Assets.GetPrefab(geyserPrefabParams.id), inst.transform.GetPosition(), Grid.SceneLayer.BuildingBack);
    //                gameObject2.SetActive(value: true);
    //                inst.DeleteObject();
    //            };
    //            list.Add(gameObject);
    //            __result = list;
    //        }
    //        catch (Exception e)
    //        {
    //            UnityEngine.Debug.LogException(e);
    //        }

    //        return false;
    //    }
    //}
}