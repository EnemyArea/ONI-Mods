namespace FlowSplitters.Utils
{
	public static class BuildingUtils
	{
		public static void AddBuildingToPlanScreen(HashedString category, string buildingId)
        {
            ModUtil.AddBuildingToPlanScreen(category, buildingId);
        }

		public static void AddBuildingToTechnology(string techId, string buildingId)
		{
			Db.Get().Techs.Get(techId).unlockedItemIDs.Add(buildingId);
		}
    }
}
