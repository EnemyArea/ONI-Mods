using System.Collections.Generic;
using TUNING;
using UnityEngine;

namespace MoreCanisterFillersMod.Buildings
{
	// Token: 0x0200000A RID: 10
	public class ConveyorLiquidLoaderConfig : IBuildingConfig
	{
		// Token: 0x06000017 RID: 23 RVA: 0x00002568 File Offset: 0x00000768
		public override BuildingDef CreateBuildingDef()
		{
			BuildingDef buildingDef = BuildingTemplates.CreateBuildingDef("asquared31415.ConveyorLiquidLoaderConfig", 1, 2, "conveyorin_kanim", 30, 30f, BUILDINGS.CONSTRUCTION_MASS_KG.TIER3, MATERIALS.ALL_METALS, 1600f, BuildLocationRule.Anywhere, BUILDINGS.DECOR.PENALTY.TIER1, NOISE_POLLUTION.NONE);
			buildingDef.Floodable = false;
			buildingDef.Overheatable = false;
			buildingDef.ViewMode = OverlayModes.SolidConveyor.ID;
			buildingDef.InputConduitType = ConduitType.Liquid;
			buildingDef.UtilityInputOffset = CellOffset.none;
			buildingDef.OutputConduitType = ConduitType.Solid;
			buildingDef.UtilityOutputOffset = new CellOffset(0, 1);
			buildingDef.PermittedRotations = PermittedRotations.R360;
			buildingDef.RequiresPowerInput = true;
			buildingDef.PowerInputOffset = new CellOffset(0, 1);
			buildingDef.EnergyConsumptionWhenActive = 60f;
			buildingDef.SelfHeatKilowattsWhenActive = 0.06f;
            GeneratedBuildings.RegisterWithOverlay(OverlayScreen.SolidConveyorIDs, "SolidConduitInbox");
			return buildingDef;
		}

		// Token: 0x06000018 RID: 24 RVA: 0x00002620 File Offset: 0x00000820
		public override void ConfigureBuildingTemplate(GameObject go, Tag prefabTag)
		{
			GeneratedBuildings.MakeBuildingAlwaysOperational(go);
			ConduitConsumer conduitConsumer = go.AddOrGet<ConduitConsumer>();
			conduitConsumer.conduitType = ConduitType.Liquid;
			conduitConsumer.consumptionRate = 10f;
			conduitConsumer.capacityKG = 20f;
			conduitConsumer.forceAlwaysSatisfied = true;
			SolidConduitDispenser solidConduitDispenser = go.AddOrGet<SolidConduitDispenser>();
			solidConduitDispenser.alwaysDispense = true;
			solidConduitDispenser.elementFilter = null;
			BuildingTemplates.CreateDefaultStorage(go);
		}

		// Token: 0x06000019 RID: 25 RVA: 0x0000267C File Offset: 0x0000087C
		public override void DoPostConfigureUnderConstruction(GameObject go)
		{
			base.DoPostConfigureUnderConstruction(go);
			go.GetComponent<Constructable>().requiredSkillPerk = Db.Get().SkillPerks.ConveyorBuild.Id;
		}

		// Token: 0x0600001A RID: 26 RVA: 0x000026A4 File Offset: 0x000008A4
		public override void DoPostConfigureComplete(GameObject go)
		{
			Prioritizable.AddRef(go);

            List<Tag> list = new List<Tag>();
            list.AddRange(STORAGEFILTERS.LIQUIDS);
            Storage storage = go.AddOrGet<Storage>();
            storage.capacityKg = 1000f;
            storage.showInUI = true;
            storage.showDescriptor = true;
            storage.storageFilters = list;
            storage.allowItemRemoval = false;
            storage.onlyTransferFromLowerPriority = true;
            storage.showCapacityStatusItem = true;
            storage.showCapacityAsMainStatus = true;
            go.AddOrGet<TreeFilterable>();

			go.AddOrGet<SolidConduitInbox>();
            go.AddOrGet<SolidConduitDispenser>();
        }

		// Token: 0x04000009 RID: 9
		public const string Id = "asquared31415.ConveyorLiquidLoaderConfig";

		// Token: 0x0400000A RID: 10
		public const string Anim = "conveyorin_kanim";
	}
}
