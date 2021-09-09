using System.Reflection;
using HarmonyLib;
using NeonEden.Utilities;
using UnityEngine;

namespace NeonEden
{
    // Token: 0x02000004 RID: 4
	[HarmonyPatch(typeof(Db), "Initialize")]
	internal class NeonEdenLitePatch
	{
		// Token: 0x06000005 RID: 5 RVA: 0x0000219C File Offset: 0x0000039C
		public static void Prefix()
		{
			string str = "NEON_EDEN_LITE";
			Strings.Add("STRINGS.WORLDS." + str + ".NAME", "Neon Eden Lite");
			Strings.Add("STRINGS.WORLDS." + str + ".DESCRIPTION", "A good target location with an abundance of resources.\n\n<smallcaps>Neon Eden will pose almost no challenges and the abundance of resources will enable you to support a large colony. </smallcaps>\n\n");
			string text = "Asteroid_NeonEdenLite";
			ModUtil.RegisterForTranslation(typeof(NeonEdenLitePatch));
			
            var sprite = Assembly.GetExecutingAssembly().GetManifestResourceStream("NeonEden." + text + ".dds");
            Debug.Log(sprite == null ? "NeonEden." + text + ".dds is null" : "NeonEden." + text + ".dds");

			Sprite value = Sprites.CreateSpriteDXT5(sprite, 512, 512);
			Assets.Sprites.Add(text, value);
		}
	}
}
