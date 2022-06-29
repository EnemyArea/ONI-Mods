using HarmonyLib;

namespace BalanceWaterPumpConsumption
{
	[HarmonyPatch(typeof(LiquidFilterConfig), "CreateBuildingDef")]
	public static class LiquidFilterConfigMod
	{
		public static void Postfix(ref BuildingDef __result)
		{
			__result.EnergyConsumptionWhenActive = 60f;
		}
	}
}
