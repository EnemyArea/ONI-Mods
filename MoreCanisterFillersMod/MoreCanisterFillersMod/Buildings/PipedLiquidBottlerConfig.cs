using System;
using MoreCanisterFillersMod.Components;
using TUNING;
using UnityEngine;

namespace MoreCanisterFillersMod.Buildings
{
	// Token: 0x0200000E RID: 14
	public class PipedLiquidBottlerConfig : IBuildingConfig
	{
		// Token: 0x06000029 RID: 41 RVA: 0x00002A84 File Offset: 0x00000C84
		public override BuildingDef CreateBuildingDef()
		{
			BuildingDef buildingDef = BuildingTemplates.CreateBuildingDef("asquared31415.PipedLiquidBottler", 3, 2, "gas_bottler_kanim", 100, 120f, BUILDINGS.CONSTRUCTION_MASS_KG.TIER4, MATERIALS.ALL_METALS, 800f, BuildLocationRule.OnFloor, BUILDINGS.DECOR.PENALTY.TIER1, NOISE_POLLUTION.NOISY.TIER0, 0.2f);
			buildingDef.InputConduitType = ConduitType.Liquid;
			buildingDef.Floodable = false;
			buildingDef.ViewMode = OverlayModes.LiquidConduits.ID;
			buildingDef.AudioCategory = "HollowMetal";
			buildingDef.PermittedRotations = PermittedRotations.FlipH;
			buildingDef.UtilityInputOffset = new CellOffset(0, 0);
			return buildingDef;
		}

		// Token: 0x0600002A RID: 42 RVA: 0x00002B04 File Offset: 0x00000D04
		public override void ConfigureBuildingTemplate(GameObject go, Tag prefabTag)
		{
			Storage storage = BuildingTemplates.CreateDefaultStorage(go, false);
			storage.showDescriptor = true;
			storage.storageFilters = STORAGEFILTERS.LIQUIDS;
			storage.capacityKg = 1000f;
			go.AddOrGet<DropAllWorkable>();
			go.AddOrGet<AutoDropInv>();
			ConduitConsumer conduitConsumer = go.AddOrGet<ConduitConsumer>();
			conduitConsumer.storage = storage;
			conduitConsumer.conduitType = ConduitType.Liquid;
			conduitConsumer.ignoreMinMassCheck = true;
			conduitConsumer.forceAlwaysSatisfied = true;
			conduitConsumer.alwaysConsume = true;
			conduitConsumer.capacityKG = storage.capacityKg;
			conduitConsumer.keepZeroMassObject = false;
			PipedLiquidBottler pipedLiquidBottler = go.AddOrGet<PipedLiquidBottler>();
			pipedLiquidBottler.Storage = storage;
			pipedLiquidBottler.workTime = 9f;
		}

		// Token: 0x0600002B RID: 43 RVA: 0x00002B9C File Offset: 0x00000D9C
		public override void DoPostConfigureComplete(GameObject go)
		{
		}

		// Token: 0x0400000F RID: 15
		public const string Id = "asquared31415.PipedLiquidBottler";
	}
}
