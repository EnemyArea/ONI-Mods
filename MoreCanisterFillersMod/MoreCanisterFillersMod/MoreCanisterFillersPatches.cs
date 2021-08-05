#region

using System.Linq;
using System.Reflection;
using CaiLib.Utils;
using Database;
using HarmonyLib;
using MoreCanisterFillersMod.Components;
using TUNING;
using UnityEngine;

#endregion

namespace MoreCanisterFillersMod
{
    // Token: 0x02000003 RID: 3
    public static class MoreCanisterFillersPatches
    {
        [HarmonyPatch(typeof(Techs), "Init")]
        public static class Techs_Init_Path
        {
            public static void Prefix()
            {
                ModUtil.AddBuildingToPlanScreen("Plumbing", "asquared31415.PipedLiquidBottler");
                ModUtil.AddBuildingToPlanScreen("Conveyance", "asquared31415.ConveyorBottleEmptier");
                ModUtil.AddBuildingToPlanScreen("Conveyance", "asquared31415.ConveyorGasPipeFillerConfig");
                ModUtil.AddBuildingToPlanScreen("Conveyance", "asquared31415.ConveyorLiquidPipeFillerConfig");
                ModUtil.AddBuildingToPlanScreen("Conveyance", "asquared31415.ConveyorGasLoaderConfig");
                ModUtil.AddBuildingToPlanScreen("Conveyance", "asquared31415.ConveyorLiquidLoaderConfig");
            }
        }

        [HarmonyPatch(typeof(GeneratedBuildings), nameof(GeneratedBuildings.LoadGeneratedBuildings))]
        public static class GeneratedBuildings_LoadGeneratedBuildings_Path
        {
            public static void Prefix()
            {
                BuildingUtils.AddBuildingToTechnology("LiquidPiping", "asquared31415.PipedLiquidBottler");
                BuildingUtils.AddBuildingToTechnology("SolidTransport", "asquared31415.ConveyorBottleEmptier");
                BuildingUtils.AddBuildingToTechnology("SolidTransport", "asquared31415.ConveyorGasPipeFillerConfig");
                BuildingUtils.AddBuildingToTechnology("SolidTransport", "asquared31415.ConveyorLiquidPipeFillerConfig");
                BuildingUtils.AddBuildingToTechnology("SolidTransport", "asquared31415.ConveyorGasLoaderConfig");
                BuildingUtils.AddBuildingToTechnology("SolidTransport", "asquared31415.ConveyorLiquidLoaderConfig");
                LocString.CreateLocStringKeys(typeof(STRINGS.BUILDINGS));
            }
        }

        // Token: 0x02000018 RID: 24
        [HarmonyPatch(typeof(GasBottlerConfig), "ConfigureBuildingTemplate")]
        public class GasFillerPatches
        {
            // Token: 0x06000046 RID: 70 RVA: 0x0000330C File Offset: 0x0000150C
            public static void Postfix(GameObject go)
            {
                go.AddOrGet<AutoDropInv>();
            }
        }
        
        // Token: 0x02000019 RID: 25
        [HarmonyPatch(typeof(SolidConduitInboxConfig), "DoPostConfigureComplete")]
        public static class SolidConduitInboxConfig_DoPostConfigureComplete_Patches
        {
            // Token: 0x06000048 RID: 72 RVA: 0x00003320 File Offset: 0x00001520
            public static void Postfix(GameObject go)
            {
                Storage storage = go.AddOrGet<Storage>();
                storage.storageFilters.AddRange(STORAGEFILTERS.LIQUIDS);
                storage.storageFilters.AddRange(STORAGEFILTERS.GASES);
            }
        }

        // Token: 0x0200001A RID: 26
        [HarmonyPatch(typeof(SolidTransferArm), "IsPickupableRelevantToMyInterests")]
        public static class TransferArmFix
        {
            // Token: 0x06000049 RID: 73 RVA: 0x00003348 File Offset: 0x00001548
            public static void Prefix()
            {
                if (!_hasPatched)
                {
                    _hasPatched = true;
                    SolidTransferArm.tagBits = new TagBits(STORAGEFILTERS.NOT_EDIBLE_SOLIDS.Concat(STORAGEFILTERS.FOOD).Concat(STORAGEFILTERS.GASES).Concat(STORAGEFILTERS.LIQUIDS).ToArray<Tag>());
                }
            }

            // Token: 0x04000014 RID: 20
            private static bool _hasPatched;
        }
    }
}