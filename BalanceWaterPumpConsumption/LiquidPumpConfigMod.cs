using HarmonyLib;

namespace BalanceWaterPumpConsumption
{
	// Token: 0x02000005 RID: 5
	[HarmonyPatch(typeof(LiquidPumpConfig), "CreateBuildingDef")]
	public static class LiquidPumpConfigMod
	{
		// Token: 0x06000009 RID: 9 RVA: 0x00002103 File Offset: 0x00000303
		public static void Postfix(ref BuildingDef __result)
		{
			__result.EnergyConsumptionWhenActive = 120f;
		}
	}
}
