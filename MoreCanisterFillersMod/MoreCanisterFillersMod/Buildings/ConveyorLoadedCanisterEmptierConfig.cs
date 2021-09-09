using System.Collections.Generic;
using TUNING;
using UnityEngine;

namespace MoreCanisterFillersMod.Buildings
{
	// Token: 0x0200000D RID: 13
	public class ConveyorLoadedCanisterEmptierConfig : IBuildingConfig
	{
		// Token: 0x06000025 RID: 37 RVA: 0x00002958 File Offset: 0x00000B58
		public override BuildingDef CreateBuildingDef()
		{
			var tier = BUILDINGS.CONSTRUCTION_MASS_KG.TIER4;
			var raw_MINERALS = MATERIALS.RAW_MINERALS;
			var none = NOISE_POLLUTION.NONE;
			var buildingDef = BuildingTemplates.CreateBuildingDef("asquared31415.ConveyorBottleEmptier", 1, 3, "gas_emptying_station_kanim", 30, 10f, tier, raw_MINERALS, 1600f, BuildLocationRule.OnFloor, BUILDINGS.DECOR.PENALTY.TIER1, none);
			buildingDef.Floodable = false;
			buildingDef.AudioCategory = "Metal";
			buildingDef.Overheatable = true;
			buildingDef.PermittedRotations = PermittedRotations.FlipH;
			buildingDef.ViewMode = OverlayModes.SolidConveyor.ID;
			buildingDef.InputConduitType = ConduitType.Solid;
			buildingDef.UtilityInputOffset = new CellOffset(0, 0);
			return buildingDef;
		}

		// Token: 0x06000026 RID: 38 RVA: 0x000029E8 File Offset: 0x00000BE8
		public override void ConfigureBuildingTemplate(GameObject go, Tag prefabTag)
		{
			Prioritizable.AddRef(go);
			var storage = go.AddOrGet<Storage>();
			var list = new List<Tag>();
			list.AddRange(STORAGEFILTERS.GASES);
			list.AddRange(STORAGEFILTERS.LIQUIDS);
			storage.storageFilters = list;
			storage.showDescriptor = true;
			storage.capacityKg = 200f;
			storage.allowItemRemoval = false;
			go.AddOrGet<DropAllWorkable>();
			var solidConduitConsumer = go.AddOrGet<SolidConduitConsumer>();
			solidConduitConsumer.storage = storage;
			solidConduitConsumer.alwaysConsume = true;
			solidConduitConsumer.capacityKG = storage.capacityKg;
			go.AddOrGet<UnfilteredBottleEmptier>().EmptyRate = 0.4f;
		}

		// Token: 0x06000027 RID: 39 RVA: 0x00002A78 File Offset: 0x00000C78
		public override void DoPostConfigureComplete(GameObject go)
		{
		}

		// Token: 0x0400000E RID: 14
		public const string Id = "asquared31415.ConveyorBottleEmptier";
	}
}
