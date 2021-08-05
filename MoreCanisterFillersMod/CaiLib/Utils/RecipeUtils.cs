using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace CaiLib.Utils
{
	// Token: 0x02000014 RID: 20
	[ComVisible(false)]
	public class RecipeUtils
	{
		// Token: 0x06000036 RID: 54 RVA: 0x00002D0C File Offset: 0x00000F0C
		public static ComplexRecipe AddComplexRecipe(ComplexRecipe.RecipeElement[] input, ComplexRecipe.RecipeElement[] output, string fabricatorId, float productionTime, string recipeDescription, ComplexRecipe.RecipeNameDisplay nameDisplayType, int sortOrder, string requiredTech = null)
		{
			return new ComplexRecipe(ComplexRecipeManager.MakeRecipeID(fabricatorId, input, output), input, output)
			{
				time = productionTime,
				description = recipeDescription,
				nameDisplay = nameDisplayType,
				fabricators = new List<Tag>
				{
					fabricatorId
				},
				sortOrder = sortOrder,
				requiredTech = requiredTech
			};
		}
	}
}
