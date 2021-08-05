using System;
using MoreCanisterFillersMod.Components;
using TUNING;
using UnityEngine;

namespace MoreCanisterFillersMod.Buildings
{
    // Token: 0x02000172 RID: 370
	public class PipedLiquidBottlerConfig : IBuildingConfig
	{
		// Token: 0x0600070C RID: 1804 RVA: 0x000294CC File Offset: 0x000276CC
		public override BuildingDef CreateBuildingDef()
		{
			BuildingDef buildingDef = BuildingTemplates.CreateBuildingDef(ID, WIDTH, HEIGHT, "gas_bottler_kanim", 100, 120f, BUILDINGS.CONSTRUCTION_MASS_KG.TIER4, MATERIALS.ALL_METALS, 800f, BuildLocationRule.OnFloor, BUILDINGS.DECOR.PENALTY.TIER1, NOISE_POLLUTION.NOISY.TIER0);
			buildingDef.InputConduitType = CONDUIT_TYPE;
			buildingDef.Floodable = false;
			buildingDef.ViewMode = OverlayModes.LiquidConduits.ID;
			buildingDef.AudioCategory = "HollowMetal";
			buildingDef.UtilityInputOffset = new CellOffset(0, 0);
            buildingDef.PermittedRotations = PermittedRotations.FlipH;
			GeneratedBuildings.RegisterWithOverlay(OverlayScreen.LiquidVentIDs, ID);
			return buildingDef;
		}

		// Token: 0x0600070D RID: 1805 RVA: 0x00029550 File Offset: 0x00027750
		public override void ConfigureBuildingTemplate(GameObject go, Tag prefab_tag)
		{
			Storage storage = BuildingTemplates.CreateDefaultStorage(go);
			storage.showDescriptor = true;
			storage.storageFilters = STORAGEFILTERS.LIQUIDS;
			storage.capacityKg = 1000f;
			go.AddOrGet<DropAllWorkable>();
            go.AddOrGet<AutoDropInv>();
            PipedLiquidBottler pipedLiquidBottler = go.AddOrGet<PipedLiquidBottler>();
            pipedLiquidBottler.Storage = storage;
            pipedLiquidBottler.workTime = 9f;
			ConduitConsumer conduitConsumer = go.AddOrGet<ConduitConsumer>();
			conduitConsumer.storage = storage;
			conduitConsumer.conduitType = ConduitType.Liquid;
			conduitConsumer.ignoreMinMassCheck = true;
			conduitConsumer.forceAlwaysSatisfied = true;
			conduitConsumer.alwaysConsume = true;
			conduitConsumer.capacityKG = storage.capacityKg;
			conduitConsumer.keepZeroMassObject = false;
		}

		// Token: 0x0600070E RID: 1806 RVA: 0x000295E2 File Offset: 0x000277E2
		public override void DoPostConfigureComplete(GameObject go)
		{
			go.GetComponent<KPrefabID>().AddTag(GameTags.OverlayBehindConduits);
		}

		// Token: 0x04000470 RID: 1136
		public const string ID = "asquared31415.PipedLiquidBottler";

		// Token: 0x04000471 RID: 1137
		private const ConduitType CONDUIT_TYPE = ConduitType.Liquid;

		// Token: 0x04000472 RID: 1138
		private const int WIDTH = 3;

		// Token: 0x04000473 RID: 1139
		private const int HEIGHT = 2;
	}


	//// Token: 0x0200000E RID: 14
	//public class PipedLiquidBottlerConfig : IBuildingConfig
	//{
	//	// Token: 0x06000029 RID: 41 RVA: 0x00002A84 File Offset: 0x00000C84
	//	public override BuildingDef CreateBuildingDef()
	//	{
	//		BuildingDef buildingDef = BuildingTemplates.CreateBuildingDef("asquared31415.PipedLiquidBottler", 3, 2, "gas_bottler_kanim", 100, 120f, BUILDINGS.CONSTRUCTION_MASS_KG.TIER4, MATERIALS.ALL_METALS, 800f, BuildLocationRule.OnFloor, BUILDINGS.DECOR.PENALTY.TIER1, NOISE_POLLUTION.NOISY.TIER0, 0.2f);
	//		buildingDef.InputConduitType = ConduitType.Liquid;
	//		buildingDef.Floodable = false;
	//		buildingDef.ViewMode = OverlayModes.LiquidConduits.ID;
	//		buildingDef.AudioCategory = "HollowMetal";
	//		buildingDef.PermittedRotations = PermittedRotations.FlipH;
	//		buildingDef.UtilityInputOffset = new CellOffset(0, 0);
 //           GeneratedBuildings.RegisterWithOverlay(OverlayScreen.LiquidVentIDs, "PipedLiquidBottler");
	//		return buildingDef;
	//	}

	//	// Token: 0x0600002A RID: 42 RVA: 0x00002B04 File Offset: 0x00000D04
	//	public override void ConfigureBuildingTemplate(GameObject go, Tag prefabTag)
	//	{
	//		Storage storage = BuildingTemplates.CreateDefaultStorage(go, false);
	//		storage.showDescriptor = true;
	//		storage.storageFilters = STORAGEFILTERS.LIQUIDS;
	//		storage.capacityKg = 1000f;
	//		go.AddOrGet<DropAllWorkable>();
	//		go.AddOrGet<AutoDropInv>();
	//		ConduitConsumer conduitConsumer = go.AddOrGet<ConduitConsumer>();
	//		conduitConsumer.storage = storage;
	//		conduitConsumer.conduitType = ConduitType.Liquid;
	//		conduitConsumer.ignoreMinMassCheck = true;
	//		conduitConsumer.forceAlwaysSatisfied = true;
	//		conduitConsumer.alwaysConsume = true;
	//		conduitConsumer.capacityKG = storage.capacityKg;
	//		conduitConsumer.keepZeroMassObject = false;
	//		PipedLiquidBottler pipedLiquidBottler = go.AddOrGet<PipedLiquidBottler>();
	//		pipedLiquidBottler.Storage = storage;
	//		pipedLiquidBottler.workTime = 9f;
	//	}

	//	// Token: 0x0600002B RID: 43 RVA: 0x00002B9C File Offset: 0x00000D9C
	//	public override void DoPostConfigureComplete(GameObject go)
	//	{
	//	}

	//	// Token: 0x0400000F RID: 15
	//	public const string Id = "asquared31415.PipedLiquidBottler";
	//}
}
