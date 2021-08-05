using System;
using HarmonyLib;

namespace HeavyBatteriesMod
{
	// Token: 0x02000008 RID: 8
	[HarmonyPatch(typeof(Battery), "AddEnergy", typeof(float))]
	public class HeavyBatteriesEmergencyBatteryEnergy
	{
		// Token: 0x06000032 RID: 50 RVA: 0x000028F8 File Offset: 0x00000AF8
		public static void Prefix(Battery __instance, ref float joules)
		{
			bool flag = __instance.gameObject.GetComponent<KPrefabID>().PrefabTag == "EmergencyBattery";
			if (flag)
			{
				joules /= 2f;
			}
		}
	}
}
