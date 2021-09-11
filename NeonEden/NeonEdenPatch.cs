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
            Strings.Add("STRINGS.CLUSTER_NAMES." + str + ".NAME", "Neon Eden");
            Strings.Add("STRINGS.CLUSTER_NAMES." + str + ".DESCRIPTION", "A huge target location with an abundance of resources.\n\n<smallcaps>Neon Eden will pose almost no challenges and the abundance of resources and space will enable you to support a large colony. </smallcaps>\n\n");
            Strings.Add("STRINGS.SUBWORLDS.NEONEDEN.NAME", "Neon Eden");
            Strings.Add("STRINGS.SUBWORLDS.NEONEDEN.DESC", "A huge target location with an abundance of resources.\n\n<smallcaps>Neon Eden will pose almost no challenges and the abundance of resources and space will enable you to support a large colony. </smallcaps>\n\n");
            Strings.Add("STRINGS.SUBWORLDS.NEONEDEN.UTILITY", "Neon Eden UTILITY");
            string text = "Asteroid_NeonEden";
            ModUtil.RegisterForTranslation(typeof(NeonEdenPatch));

            var sprite = Assembly.GetExecutingAssembly().GetManifestResourceStream("NeonEden." + text + ".dds");
            Debug.Log(sprite == null ? "sprite is null" : "sprite is not null");
            Sprite value = Sprites.CreateSpriteDXT5(sprite, 512, 512);
            Assets.Sprites.Add(text, value);

            var textureBiom = Assembly.GetExecutingAssembly().GetManifestResourceStream("NeonEden.NeonEdenBiom.png");
            Debug.Log(textureBiom == null ? "textureBiom is null" : "textureBiom is not null");
            Sprite spriteBiom = Sprites.CreateSpriteFromPng(textureBiom, 512, 512);
            Assets.Sprites.Add("biomeIconNeoneden", spriteBiom);
        }
    }
}
