using System.Collections.Generic;
using System.Linq;
using Database;
using STRINGS;
using HarmonyLib;
using KMod;


namespace ExtendedBridges
{
	public class ExtendedBridges : UserMod2
	{
		// Add strings for the bridges and add them to the build menu
		[HarmonyPatch(typeof(GeneratedBuildings), "LoadGeneratedBuildings")]
		internal class ExtendedBridges_GeneratedBuildings_LoadGeneratedBuildings
		{
			private static void Prefix()
			{
				// New strings
				Strings.Add("STRINGS.BUILDINGS.PREFABS.EXTENDEDLIQUIDCONDUITBRIDGE.NAME", UI.FormatAsLink("Long Liquid Bridge", "EXTENDEDLIQUIDCONDUITBRIDGE"));
				Strings.Add("STRINGS.BUILDINGS.PREFABS.EXTENDEDLIQUIDCONDUITBRIDGE.DESC", "Separate pipe systems prevent mingled contents from causing building damage.");
				Strings.Add("STRINGS.BUILDINGS.PREFABS.EXTENDEDLIQUIDCONDUITBRIDGE.EFFECT", string.Concat(new string[] { "Runs one " + UI.FormatAsLink("Liquid Pipe", "LIQUIDPIPING") + " section over another two without joining them.\n\nCan be run through wall and floor tile." }));

				Strings.Add("STRINGS.BUILDINGS.PREFABS.EXTENDEDGASCONDUITBRIDGE.NAME", UI.FormatAsLink("Long Gas Bridge", "EXTENDEDGASCONDUITBRIDGE"));
				Strings.Add("STRINGS.BUILDINGS.PREFABS.EXTENDEDGASCONDUITBRIDGE.DESC", "Separate pipe systems prevent mingled contents from causing building damage.");
				Strings.Add("STRINGS.BUILDINGS.PREFABS.EXTENDEDGASCONDUITBRIDGE.EFFECT", string.Concat(new string[] { "Runs one " + UI.FormatAsLink("Gas Pipe", "GASPIPING") + " section over another two without joining them.\n\nCan be run through wall and floor tile." }));

				Strings.Add("STRINGS.BUILDINGS.PREFABS.EXTENDEDSOLIDCONDUITBRIDGE.NAME", UI.FormatAsLink("Long Conveyor Bridge", "EXTENDEDSOLIDCONDUITBRIDGE"));
				Strings.Add("STRINGS.BUILDINGS.PREFABS.EXTENDEDSOLIDCONDUITBRIDGE.DESC", "Separating rail systems helps prevent materials from reaching the wrong destinations.");
				Strings.Add("STRINGS.BUILDINGS.PREFABS.EXTENDEDSOLIDCONDUITBRIDGE.EFFECT", string.Concat(new string[] { "Runs one " + UI.FormatAsLink("Conveyor Rail", "SOLIDCONDUIT") + " section over another two without joining them.\n\nCan be run through wall and floor tile." }));

				Strings.Add("STRINGS.BUILDINGS.PREFABS.EXTENDEDWIREBRIDGE.NAME", UI.FormatAsLink("Long Wire Bridge", "EXTENDEDWIREBRIDGE"));
				Strings.Add("STRINGS.BUILDINGS.PREFABS.EXTENDEDWIREBRIDGE.DESC", "Splitting generators onto separate systems can prevent power overloads and wasted electricity.");
				Strings.Add("STRINGS.BUILDINGS.PREFABS.EXTENDEDWIREBRIDGE.EFFECT", "Runs one wire section over another two without joining them.\n\nCan be run through wall and floor tile.");

				Strings.Add("STRINGS.BUILDINGS.PREFABS.EXTENDEDWIREREFINEDBRIDGE.NAME", UI.FormatAsLink("Long Conductive Wire Bridge", "EXTENDEDWIREREFINEDBRIDGE"));
				Strings.Add("STRINGS.BUILDINGS.PREFABS.EXTENDEDWIREREFINEDBRIDGE.DESC", "Splitting generators onto separate systems can prevent power overloads and wasted electricity.");
				Strings.Add("STRINGS.BUILDINGS.PREFABS.EXTENDEDWIREREFINEDBRIDGE.EFFECT", string.Concat(new string[] { "Carries more ", UI.FormatAsLink("Wattage", "POWER"), " than a regular ", UI.FormatAsLink("Wire Bridge", "WIREBRIDGE"), " without overloading.\n\nRuns one wire section over another two without joining them.\n\nCan be run through wall and floor tile." }));

				Strings.Add("STRINGS.BUILDINGS.PREFABS.EXTENDEDLOGICWIREBRIDGE.NAME", UI.FormatAsLink("Long Automation Wire Bridge", "EXTENDEDLOGICWIREBRIDGE"));
				Strings.Add("STRINGS.BUILDINGS.PREFABS.EXTENDEDLOGICWIREBRIDGE.DESC", "Wire bridges allow multiple automation grids to exist in a small area without connecting.");
				Strings.Add("STRINGS.BUILDINGS.PREFABS.EXTENDEDLOGICWIREBRIDGE.EFFECT", string.Concat(new string[] { "Runs one " + UI.FormatAsLink("Automation Wire", "LOGICWIRE") + " section over another two without joining them.\n\nCan be run through wall and floor tile." }));

				Strings.Add("STRINGS.BUILDINGS.PREFABS.EXTENDEDLOGICRIBBONBRIDGE.NAME", UI.FormatAsLink("Long Automation Ribbon Bridge", "EXTENDEDLOGICRIBBONBRIDGE"));
				Strings.Add("STRINGS.BUILDINGS.PREFABS.EXTENDEDLOGICRIBBONBRIDGE.DESC", "Wire bridges allow multiple automation grids to exist in a small area without connecting.");
				Strings.Add("STRINGS.BUILDINGS.PREFABS.EXTENDEDLOGICRIBBONBRIDGE.EFFECT", string.Concat(new string[] { "Runs one " + UI.FormatAsLink("Automation Ribbon", "LOGICRIBBON") + " section over another two without joining them.\n\nCan be run through wall and floor tile." }));

				// Add to build menus
				ModUtil.AddBuildingToPlanScreen("Plumbing", ExtendedLiquidConduitBridgeConfig.ID);
				ModUtil.AddBuildingToPlanScreen("HVAC", ExtendedGasConduitBridgeConfig.ID);
				ModUtil.AddBuildingToPlanScreen("Conveyance", ExtendedSolidConduitBridgeConfig.ID);
				ModUtil.AddBuildingToPlanScreen("Power", ExtendedWireBridgeConfig.ID);
				ModUtil.AddBuildingToPlanScreen("Power", ExtendedWireRefinedBridgeConfig.ID);
				ModUtil.AddBuildingToPlanScreen("Automation", ExtendedLogicWireBridgeConfig.ID);
				ModUtil.AddBuildingToPlanScreen("Automation", ExtendedLogicRibbonBridgeConfig.ID);
			}
		}

        // Add the new bridges to the tech tree
        [HarmonyPatch(typeof(Techs), "Init")]
        internal class ExtendedBridges_Techs_Initialize
        {
            private static void Postfix(Techs __instance)
            {
                Debug.Log("ExtendedBridges_Techs_Initialize...");
                __instance.Get("ImprovedLiquidPiping").AddUnlockedItemIDs(ExtendedLiquidConduitBridgeConfig.ID);
                __instance.Get("ImprovedGasPiping").AddUnlockedItemIDs(ExtendedGasConduitBridgeConfig.ID);
                __instance.Get("AdvancedPowerRegulation").AddUnlockedItemIDs(ExtendedWireBridgeConfig.ID);
                __instance.Get("PrettyGoodConductors").AddUnlockedItemIDs(ExtendedWireRefinedBridgeConfig.ID);
                __instance.Get("LogicCircuits").AddUnlockedItemIDs(ExtendedLogicWireBridgeConfig.ID);
                __instance.Get("ParallelAutomation").AddUnlockedItemIDs(ExtendedLogicRibbonBridgeConfig.ID);
                __instance.Get("SolidTransport").AddUnlockedItemIDs(ExtendedSolidConduitBridgeConfig.ID);
                Debug.Log("ExtendedBridges_Techs_Initialize complete");
            }
        }

        // Update buildings on spawn
        [HarmonyPatch(typeof(Building), "OnSpawn")]
		internal class ExtendedBridges_Building_OnSpawn
		{
			private static void Postfix(Building __instance)
			{
				List<string> bridges = new List<string>()
				{
					"ExtendedLiquidConduitBridge",
					"ExtendedGasConduitBridge",
					"ExtendedSolidConduitBridge",
					"ExtendedWireBridge",
					"ExtendedWireRefinedBridge",
					"ExtendedLogicWireBridge",
					"ExtendedLogicRibbonBridge",
				};

				// Check to see if the building is on the above list
				string result = bridges.FirstOrDefault(s => __instance.name.Contains(s));

				if (!string.IsNullOrEmpty(result))
				{
					// Stretch the anim
					Debug.Log("Extending " + __instance.name);
					KBatchedAnimController animController = __instance.gameObject.GetComponent<KBatchedAnimController>();
					animController.animWidth = 1.4f;

					// Change the prefab tag on the extended automation bridge
					if (string.Equals(__instance.name, "ExtendedLogicWireBridgeComplete"))
					{
						KPrefabID kPrefabID = __instance.gameObject.AddOrGet<KPrefabID>();
						kPrefabID.PrefabTag = TagManager.Create("LogicWireBridge");
					}

					// Change the prefab tag on the extended automation ribbon bridge
					if (string.Equals(__instance.name, "ExtendedLogicRibbonBridgeComplete"))
					{
						KPrefabID kPrefabID = __instance.gameObject.AddOrGet<KPrefabID>();
						kPrefabID.PrefabTag = TagManager.Create("LogicRibbonBridge");
					}
				}
			}
		}
	}
}
