using System.Runtime.InteropServices;
using STRINGS;

namespace CaiLib.Utils
{
	// Token: 0x02000015 RID: 21
	[ComVisible(false)]
	public static class StringUtils
	{
		// Token: 0x06000038 RID: 56 RVA: 0x00002D74 File Offset: 0x00000F74
		public static void AddBuildingStrings(string buildingId, string name, string description, string effect)
		{
			Strings.Add(new string[]
			{
				"STRINGS.BUILDINGS.PREFABS." + buildingId.ToUpperInvariant() + ".NAME",
				UI.FormatAsLink(name, buildingId)
			});
			Strings.Add(new string[]
			{
				"STRINGS.BUILDINGS.PREFABS." + buildingId.ToUpperInvariant() + ".DESC",
				description
			});
			Strings.Add(new string[]
			{
				"STRINGS.BUILDINGS.PREFABS." + buildingId.ToUpperInvariant() + ".EFFECT",
				effect
			});
		}

		// Token: 0x06000039 RID: 57 RVA: 0x00002E00 File Offset: 0x00001000
		public static void AddPlantStrings(string plantId, string name, string description, string domesticatedDescription)
		{
			Strings.Add(new string[]
			{
				"STRINGS.CREATURES.SPECIES." + plantId.ToUpperInvariant() + ".NAME",
				UI.FormatAsLink(name, plantId)
			});
			Strings.Add(new string[]
			{
				"STRINGS.CREATURES.SPECIES." + plantId.ToUpperInvariant() + ".DESC",
				description
			});
			Strings.Add(new string[]
			{
				"STRINGS.CREATURES.SPECIES." + plantId.ToUpperInvariant() + ".DOMESTICATEDDESC",
				domesticatedDescription
			});
		}

		// Token: 0x0600003A RID: 58 RVA: 0x00002E8C File Offset: 0x0000108C
		public static void AddPlantSeedStrings(string plantId, string name, string description)
		{
			Strings.Add(new string[]
			{
				"STRINGS.CREATURES.SPECIES.SEEDS." + plantId.ToUpperInvariant() + ".NAME",
				UI.FormatAsLink(name, plantId)
			});
			Strings.Add(new string[]
			{
				"STRINGS.CREATURES.SPECIES.SEEDS." + plantId.ToUpperInvariant() + ".DESC",
				description
			});
		}

		// Token: 0x0600003B RID: 59 RVA: 0x00002EF4 File Offset: 0x000010F4
		public static void AddFoodStrings(string foodId, string name, string description, string recipeDescription = null)
		{
			Strings.Add(new string[]
			{
				"STRINGS.ITEMS.FOOD." + foodId.ToUpperInvariant() + ".NAME",
				UI.FormatAsLink(name, foodId)
			});
			Strings.Add(new string[]
			{
				"STRINGS.ITEMS.FOOD." + foodId.ToUpperInvariant() + ".DESC",
				description
			});
			if (recipeDescription != null)
			{
				Strings.Add(new string[]
				{
					"STRINGS.ITEMS.FOOD." + foodId.ToUpperInvariant() + ".RECIPEDESC",
					recipeDescription
				});
			}
		}
	}
}
