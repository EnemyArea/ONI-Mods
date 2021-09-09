using System.Reflection;
using HarmonyLib;
using NeonEden.Utilities;
using UnityEngine;

namespace NeonEden
{
	// Token: 0x02000003 RID: 3
	[HarmonyPatch(typeof(Db), "Initialize")]
	internal class NeonEdenPatch
	{
		// Token: 0x06000003 RID: 3 RVA: 0x000020DC File Offset: 0x000002DC
		public static void Prefix()
		{
			string str = "NEON_EDEN";
			Strings.Add("STRINGS.WORLDS." + str + ".NAME", "Neon Eden");
			Strings.Add("STRINGS.WORLDS." + str + ".DESCRIPTION", "A huge target location with an abundance of resources.\n\n<smallcaps>Neon Eden will pose almost no challenges and the abundance of resources and space will enable you to support a large colony. </smallcaps>\n\n");
			string text = "Asteroid_NeonEden";
			ModUtil.RegisterForTranslation(typeof(NeonEdenPatch));

            var sprite = Assembly.GetExecutingAssembly().GetManifestResourceStream("NeonEden." + text + ".dds");
            Debug.Log(sprite == null ? "NeonEden." + text + ".dds is null" : "NeonEden." + text + ".dds");

            Sprite value = Sprites.CreateSpriteDXT5(sprite, 512, 512);
            Assets.Sprites.Add(text, value);
		}
	}
}
