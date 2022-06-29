using HarmonyLib;

namespace BalanceWaterPumpConsumption
{
	// Token: 0x02000006 RID: 6
	[HarmonyPatch(typeof(LiquidMiniPumpConfig), "CreateBuildingDef")]
	public static class LiquidMiniPumpConfigMod
	{
		// Token: 0x0600000A RID: 10 RVA: 0x00002112 File Offset: 0x00000312
		public static void Postfix(ref BuildingDef __result)
		{
			__result.EnergyConsumptionWhenActive = 30f;
		}
	}
}
