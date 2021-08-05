using System;
using System.Collections.Generic;
using System.Diagnostics;
using Database;
using HarmonyLib;

namespace HeavyBatteriesMod
{
    // Token: 0x02000006 RID: 6
    public class HeavyBatteriesTech
    {
        public static void AddBuildingToTech(string tech, string buildingid)
        {
            var techTree = Db.Get().Techs.Get(tech);
            techTree.unlockedItemIDs.Add(buildingid);
        }

        [HarmonyPatch(typeof(Techs), "Init")]
        public static void Prefix(Db __instance)
        {
            Debug.Log("Heavy Batteries - Loaded: ");
            AddBuildingToTech("DupeTrafficControl", HeavyBatteryConfig.ID);
            AddBuildingToTech("DupeTrafficControl", HeavySmartBatteryConfig.ID);
            AddBuildingToTech("DupeTrafficControl", HeavyTransformerConfig.ID);

            bool emergencyBatteryEnabled = ConfigFile.config.emergencyBatteryEnabled;
            if (emergencyBatteryEnabled)
            {
                AddBuildingToTech("DupeTrafficControl", EmergencyBatteryConfig.ID);
            }
        }
    }
}
