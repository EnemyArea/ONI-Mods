using STRINGS;

namespace MoreCanisterFillersMod
{
	// Token: 0x02000004 RID: 4
	public static class STRINGS
	{
		// Token: 0x0200001B RID: 27
		public static class BUILDINGS
		{
			// Token: 0x02000023 RID: 35
			public static class PREFABS
			{
				// Token: 0x02000032 RID: 50
				public static class ASQUARED31415
				{
					// Token: 0x02000033 RID: 51
					public static class PIPEDLIQUIDBOTTLER
					{
						// Token: 0x0400007B RID: 123
						public static LocString NAME = "Bottle Filler";

						// Token: 0x0400007C RID: 124
						public static LocString EFFECT = "Automatically stores piped " + UI.FormatAsLink("Liquids", "ELEMENTS_LIQUID") + " into canisters for manual transport.";

						// Token: 0x0400007D RID: 125
						public static LocString DESC = "Bottles allow Duplicants to manually deliver liquids from place to place.";
					}

					// Token: 0x02000034 RID: 52
					public static class CONVEYORBOTTLEEMPTIER
					{
						// Token: 0x0400007E RID: 126
						public static LocString NAME = "Conveyor Loaded Canister Emptier";

						// Token: 0x0400007F RID: 127
						public static LocString EFFECT = "Unloads bottles from a " + UI.FormatAsLink("Conveyor Rail", "SOLIDCONDUIT") + " into the world.";

						// Token: 0x04000080 RID: 128
						public static LocString DESC = "";
					}

					// Token: 0x02000035 RID: 53
					public static class CONVEYORLIQUIDPIPEFILLERCONFIG
					{
						// Token: 0x04000081 RID: 129
						public static LocString NAME = "Liquid Pipe Filler";

						// Token: 0x04000082 RID: 130
						public static LocString EFFECT = "Unloads bottles from a " + UI.FormatAsLink("Conveyor Rail", "SOLIDCONDUIT") + " into a liquid pipe.";

						// Token: 0x04000083 RID: 131
						public static LocString DESC = "";
					}

					// Token: 0x02000036 RID: 54
					public static class CONVEYORLIQUIDLOADERCONFIG
					{
						// Token: 0x04000084 RID: 132
						public static LocString NAME = "Liquid Conveyor Loader";

						// Token: 0x04000085 RID: 133
						public static LocString EFFECT = "Loads liquids from a pipe onto a " + UI.FormatAsLink("Conveyor Rail", "SOLIDCONDUIT");

						// Token: 0x04000086 RID: 134
						public static LocString DESC = "";
					}

					// Token: 0x02000037 RID: 55
					public static class CONVEYORGASPIPEFILLERCONFIG
					{
						// Token: 0x04000087 RID: 135
						public static LocString NAME = "Gas Pipe Filler";

						// Token: 0x04000088 RID: 136
						public static LocString EFFECT = "Unloads canisters from a " + UI.FormatAsLink("Conveyor Rail", "SOLIDCONDUIT") + " into a gas pipe.";

						// Token: 0x04000089 RID: 137
						public static LocString DESC = "";
					}

					// Token: 0x02000038 RID: 56
					public static class CONVEYORGASLOADERCONFIG
					{
						// Token: 0x0400008A RID: 138
						public static LocString NAME = "Gas Conveyor Loader";

						// Token: 0x0400008B RID: 139
						public static LocString EFFECT = "Loads gasses from a pipe onto a " + UI.FormatAsLink("Conveyor Rail", "SOLIDCONDUIT");

						// Token: 0x0400008C RID: 140
						public static LocString DESC = "";
					}

					// Token: 0x02000039 RID: 57
					public static class CONVEYORBOTTLELOADER
					{
						// Token: 0x0400008D RID: 141
						public static LocString NAME = "Conveyor Canister Loader (deprecated)";

						// Token: 0x0400008E RID: 142
						public static LocString EFFECT = "This building is deprecated. Please use the Conveyor Loader from the base game.";

						// Token: 0x0400008F RID: 143
						public static LocString DESC = "";
					}
				}
			}
		}
	}
}
