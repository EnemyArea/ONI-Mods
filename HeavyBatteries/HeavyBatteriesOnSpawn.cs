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
            bool flag = __instance.name.Contains(HeavyBatteryConfig.ID) || __instance.name.Contains(HeavySmartBatteryConfig.ID) || __instance.name.Contains(EmergencyBatteryConfig.ID);
            if (flag)
            {
                __instance.gameObject.GetComponent<KBatchedAnimController>().animHeight = 2f;
                __instance.gameObject.GetComponent<KBatchedAnimController>().animWidth = 2f;
            }
            else
            {
                bool flag2 = __instance.name.Contains(HeavyTransformerConfig.ID);
                if (flag2)
                {
                    __instance.gameObject.GetComponent<KBatchedAnimController>().animHeight = 2f;
                    __instance.gameObject.GetComponent<KBatchedAnimController>().animWidth = 2f;
                }
            }
        }
    }
}
