using System.Collections.Generic;
using System.Runtime.InteropServices;
using TUNING;

namespace CaiLib.Utils
{
	// Token: 0x02000010 RID: 16
	[ComVisible(false)]
	public static class BuildingUtils
	{
		// Token: 0x0600002E RID: 46 RVA: 0x00002BA8 File Offset: 0x00000DA8
		public static void AddBuildingToPlanScreen(HashedString category, string buildingId, string addAfterBuildingId = null)
		{
			int num = BUILDINGS.PLANORDER.FindIndex((PlanScreen.PlanInfo x) => x.category == category);
			if (num == -1)
			{
				return;
			}
			IList<string> list = BUILDINGS.PLANORDER[num].data as IList<string>;
			if (list == null)
			{
				CaiLib.Logger.Logger.Log("Could not add " + buildingId + " to the building menu.");
				return;
			}
			int num2 = list.IndexOf(addAfterBuildingId);
			if (num2 != -1)
			{
				list.Insert(num2 + 1, buildingId);
				return;
			}
			list.Add(buildingId);
		}

		// Token: 0x0600002F RID: 47 RVA: 0x00002C38 File Offset: 0x00000E38
		public static void AddBuildingToTechnology(string tech, string buildingId)
		{
            Db.Get().Techs.Get(tech).unlockedItemIDs.Add(buildingId);
		}
	}
}
