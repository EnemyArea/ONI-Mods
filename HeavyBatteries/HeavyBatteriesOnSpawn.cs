using HarmonyLib;

namespace HeavyBatteriesMod
{
	// Token: 0x02000007 RID: 7
	[HarmonyPatch(typeof(Building), "OnSpawn")]
	public class HeavyBatteriesOnSpawn
	{
		// Token: 0x06000030 RID: 48 RVA: 0x00002820 File Offset: 0x00000A20
		public static void Postfix(Building __instance)
		{
			string[] array = new string[]
			{
				"HeavyBattery",
				"HeavySmartBattery",
				"HeavyTransformer",
				"EmergencyBattery"
			};
			bool flag = __instance.name.Contains(array[0]) || __instance.name.Contains(array[1]) || __instance.name.Contains(array[3]);
			if (flag)
			{
				__instance.gameObject.GetComponent<KBatchedAnimController>().animHeight = 2f;
				__instance.gameObject.GetComponent<KBatchedAnimController>().animWidth = 2f;
			}
			else
			{
				bool flag2 = __instance.name.Contains(array[2]);
				if (flag2)
				{
					__instance.gameObject.GetComponent<KBatchedAnimController>().animHeight = 2f;
					__instance.gameObject.GetComponent<KBatchedAnimController>().animWidth = 1.5f;
				}
			}
		}
	}
}
