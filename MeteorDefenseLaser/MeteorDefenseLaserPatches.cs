#region

using System.Collections.Generic;
using Database;
using HarmonyLib;
using KMod;
using TUNING;

#endregion

namespace MeteorDefenseLaser
{
    public class MeteorDefenseLaserMod : UserMod2
    {
    }

    public static class BuildingUtils
    {
        public static void AddBuildingToPlanScreen(HashedString category, string buildingId, string addAfterBuildingId = null)
        {
            int num = BUILDINGS.PLANORDER.FindIndex((PlanScreen.PlanInfo x) => x.category == category);
            if (num == -1)
            {
                return;
            }

            IList<string> list = BUILDINGS.PLANORDER[num].data as IList<string>;
            if (list == null)
            {
                Debug.Log("Could not add " + buildingId + " to the building menu.");
                return;
            }

            int num2 = list.IndexOf(addAfterBuildingId);
            if (num2 != -1)
            {
                list.Insert(num2 + 1, buildingId);
                return;
            }

            list.Add(buildingId);
        }

        public static void AddBuildingToTechnology(string tech, string buildingId)
        {
            Db.Get().Techs.Get(tech).unlockedItemIDs.Add(buildingId);
        }
    }

    [HarmonyPatch(typeof(Techs), "Init")]
    internal class Techs_Init_Patch
    {
        private static void Prefix()
        {
            BuildingUtils.AddBuildingToPlanScreen("Automation", MeteorDefenseLaserConfig.ID);
        }
    }

    [HarmonyPatch(typeof(GeneratedBuildings), nameof(GeneratedBuildings.LoadGeneratedBuildings))]
    public static class GeneratedBuildings_LoadGeneratedBuildings_Patch
    {
        private static void Prefix()
        {
            Strings.Add("STRINGS.BUILDINGS.PREFABS.METEORDEFENSELASER.NAME", "Meteor Defense Laser");
            Strings.Add("STRINGS.BUILDINGS.PREFABS.METEORDEFENSELASER.DESC", "Requires significant power.");
            Strings.Add("STRINGS.BUILDINGS.PREFABS.METEORDEFENSELASER.EFFECT", "Blasts incoming meteors into smithereens.");
            Strings.Add("STRINGS.BUILDING.STATUSITEMS.LASERSTOREDCHARGE.NAME", "Power available: {0} of {1}.");
            Strings.Add("STRINGS.BUILDING.STATUSITEMS.LASERSTOREDCHARGE.TOOLTIP", "This building can store enough power to fire the laser for 3 seconds.");
            Strings.Add("STRINGS.BUILDING.STATUSITEMS.LASERKILLS.NAME", "Kill count: {0}");
            Strings.Add("STRINGS.BUILDING.STATUSITEMS.LASERKILLS.TOOLTIP", "Number of meteors destroyed.");
            BuildingUtils.AddBuildingToTechnology("SkyDetectors", MeteorDefenseLaserConfig.ID);
        }
    }

    [HarmonyPatch(typeof(Comet), "OnSpawn")]
    internal class Comet_OnSpawn
    {
        private static void Prefix(Comet __instance)
        {
            __instance.FindOrAdd<TrackedComet>();
        }
    }
}