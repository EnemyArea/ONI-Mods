using HarmonyLib;
using KMod;
using static FlowSplitters.Logger.Logger;

namespace FlowSplitters
{
	public class FlowSplittersMod : UserMod2
	{
		public override void OnLoad(Harmony harmony)
		{
			LogInit(mod);

			base.OnLoad(harmony);
		}
	}
}
