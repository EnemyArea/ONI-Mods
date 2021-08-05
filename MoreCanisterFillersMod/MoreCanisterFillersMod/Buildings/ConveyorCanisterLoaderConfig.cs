using System;
using System.Collections.Generic;
using TUNING;
using UnityEngine;

namespace MoreCanisterFillersMod.Buildings
{
	// Token: 0x0200000C RID: 12
	public class ConveyorCanisterLoaderConfig : IBuildingConfig
	{
		// Token: 0x06000021 RID: 33 RVA: 0x000027B0 File Offset: 0x000009B0
		public override BuildingDef CreateBuildingDef()
		{
			var tier = BUILDINGS.CONSTRUCTION_MASS_KG.TIER3;
			var refined_METALS = MATERIALS.REFINED_METALS;
			var none = NOISE_POLLUTION.NONE;
			var buildingDef = BuildingTemplates.CreateBuildingDef("asquared31415.ConveyorBottleLoader", 1, 2, "conveyorin_kanim", 100, 60f, tier, refined_METALS, 1600f, BuildLocationRule.Anywhere, BUILDINGS.DECOR.PENALTY.TIER1, none);
			buildingDef.Deprecated = true;
			buildingDef.RequiresPowerInput = true;
			buildingDef.EnergyConsumptionWhenActive = 120f;
			buildingDef.SelfHeatKilowattsWhenActive = 2f;
			buildingDef.Floodable = false;
			buildingDef.ViewMode = OverlayModes.SolidConveyor.ID;
			buildingDef.AudioCategory = "Metal";
			buildingDef.OutputConduitType = ConduitType.Solid;
			buildingDef.PowerInputOffset = new CellOffset(0, 1);
			buildingDef.UtilityOutputOffset = CellOffset.none;
			buildingDef.PermittedRotations = PermittedRotations.R360;
			buildingDef.LogicInputPorts = LogicOperationalController.CreateSingleInputPortList(CellOffset.none);
			GeneratedBuildings.RegisterWithOverlay(OverlayScreen.SolidConveyorIDs, "asquared31415.ConveyorBottleLoader");
			return buildingDef;
		}

		// Token: 0x06000022 RID: 34 RVA: 0x00002884 File Offset: 0x00000A84
		public override void DoPostConfigureUnderConstruction(GameObject go)
		{
			go.GetComponent<Constructable>().requiredSkillPerk = Db.Get().SkillPerks.ConveyorBuild.Id;
		}

		// Token: 0x06000023 RID: 35 RVA: 0x000028A8 File Offset: 0x00000AA8
		public override void DoPostConfigureComplete(GameObject go)
		{
			go.AddOrGet<LogicOperationalController>();
			Prioritizable.AddRef(go);
			go.GetComponent<KPrefabID>().AddTag(RoomConstraints.ConstraintTags.IndustrialMachinery);
			go.AddOrGet<EnergyConsumer>();
			go.AddOrGet<Automatable>();
			var list = new List<Tag>();
			list.AddRange(STORAGEFILTERS.GASES);
			list.AddRange(STORAGEFILTERS.LIQUIDS);
			var storage = go.AddOrGet<Storage>();
			storage.capacityKg = 1000f;
			storage.showInUI = true;
			storage.showDescriptor = true;
			storage.storageFilters = list;
			storage.allowItemRemoval = false;
			storage.onlyTransferFromLowerPriority = true;
			go.AddOrGet<TreeFilterable>();
			go.AddOrGet<SolidConduitInbox>();
			go.AddOrGet<SolidConduitDispenser>();
			go.AddOrGet<DropAllWorkable>();
		}

		// Token: 0x0400000D RID: 13
		private const string Id = "asquared31415.ConveyorBottleLoader";
	}
}
