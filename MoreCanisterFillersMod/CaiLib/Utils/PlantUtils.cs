using System;
using System.Runtime.InteropServices;
using TUNING;

namespace CaiLib.Utils
{
	// Token: 0x02000013 RID: 19
	[ComVisible(false)]
	public class PlantUtils
	{
		// Token: 0x06000034 RID: 52 RVA: 0x00002CE8 File Offset: 0x00000EE8
		public static void AddCropType(string cropId, float domesticatedGrowthTimeInCycles, int producedPerHarvest)
		{
			CROPS.CROP_TYPES.Add(new Crop.CropVal(cropId, domesticatedGrowthTimeInCycles * 600f, producedPerHarvest, true));
		}
	}
}
