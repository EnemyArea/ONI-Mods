using HarmonyLib;
using STRINGS;

namespace HeavyBatteriesMod
{
	// Token: 0x02000005 RID: 5
	[HarmonyPatch(typeof(GeneratedBuildings), "LoadGeneratedBuildings")]
	public class HeavyBatteriesMod
	{
		// Token: 0x0600002C RID: 44 RVA: 0x000024B8 File Offset: 0x000006B8
		public static void Prefix()
		{
			Debug.Log("HeavyBatteries - Prefix: ");

			Strings.Add("STRINGS.BUILDINGS.PREFABS.HEAVYBATTERY.NAME", "Heavy Battery");
			Strings.Add("STRINGS.BUILDINGS.PREFABS.HEAVYBATTERY.DESC", "Heavy batteries hold lots of power and keep systems running longer before recharging.");
			Strings.Add("STRINGS.BUILDINGS.PREFABS.HEAVYBATTERY.EFFECT", "Stores most runoff " + UI.FormatAsLink("Power", "POWER") + " from generators, but loses charge over time.");
			Strings.Add("STRINGS.BUILDINGS.PREFABS.HEAVYSMARTBATTERY.NAME", "Heavy Smart Battery");
			Strings.Add("STRINGS.BUILDINGS.PREFABS.HEAVYSMARTBATTERY.DESC", "Heavy smart batteries can send an automation signal while they require charging.");
			Strings.Add("STRINGS.BUILDINGS.PREFABS.HEAVYSMARTBATTERY.EFFECT", string.Concat("Stores most runoff ", UI.FormatAsLink("Power", "POWER"), " from generators, but loses charge over time.\n\nSends an ", UI.FormatAsLink("Active", "LOGIC"), " or ", UI.FormatAsLink("Standby", "LOGIC"), " signal based on the configuration of the Logic Activation Parameters."));
            Strings.Add("STRINGS.BUILDINGS.PREFABS.HEAVYTRANSFORMER.NAME", "Heavy Transformer");
			Strings.Add("STRINGS.BUILDINGS.PREFABS.HEAVYTRANSFORMER.DESC", "DO NOT TOUCH! SERIOUSLY!!!");
			Strings.Add("STRINGS.BUILDINGS.PREFABS.HEAVYTRANSFORMER.EFFECT", string.Concat("Protects circuits from overloading by increasing or decreasing ", UI.FormatAsLink("Power", "POWER"), " flow.\n\nStores a great deal of ", UI.FormatAsLink("Power", "POWER"), "."));

            bool emergencyBatteryEnabled = ConfigFile.config.emergencyBatteryEnabled;
            if (emergencyBatteryEnabled)
            {
                Strings.Add("STRINGS.BUILDINGS.PREFABS.EMERGENCYBATTERY.NAME", "Emergency Battery");
                Strings.Add("STRINGS.BUILDINGS.PREFABS.EMERGENCYBATTERY.DESC", "Emergency batteries can send an automation signal while they require charging.");
                Strings.Add("STRINGS.BUILDINGS.PREFABS.EMERGENCYBATTERY.EFFECT", string.Concat("Stores half of runoff ", UI.FormatAsLink("Power", "POWER"), " from generators, but never loses charge.\n\nSends an ", UI.FormatAsLink("Active", "LOGIC"), " or ", UI.FormatAsLink("Standby", "LOGIC"), " signal based on the configuration of the Logic Activation Parameters."));
                ModUtil.AddBuildingToPlanScreen("Power", "EmergencyBattery");
            }

            ModUtil.AddBuildingToPlanScreen("Power", "HeavyBattery");
            ModUtil.AddBuildingToPlanScreen("Power", "HeavySmartBattery");
            ModUtil.AddBuildingToPlanScreen("Power", "HeavyTransformer");
        }
	}
}
