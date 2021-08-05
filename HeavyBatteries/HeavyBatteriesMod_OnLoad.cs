#region

using HarmonyLib;
using KMod;

#endregion

namespace HeavyBatteriesMod
{
    // Token: 0x02000004 RID: 4
    public class HeavyBatteriesMod_OnLoad : UserMod2
    {
        public override void OnLoad(Harmony harmony)
        {
            Debug.Log("Startup at: " + this.path);
            ConfigFile.loadFile(this.path);

            base.OnLoad(harmony);
        }

        //      // Token: 0x0600002A RID: 42 RVA: 0x000024A4 File Offset: 0x000006A4
        //public static void OnLoad(Harmony harmony)
        //      {
        //	//ConfigFile.loadFile(modPath);
        //}
    }
}