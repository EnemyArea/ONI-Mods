using System;
using TUNING;
using UnityEngine;

namespace MoreCanisterFillersMod.Buildings
{
	// Token: 0x02000008 RID: 8
	public class ConveyorGasLoaderConfig : IBuildingConfig
	{
		// Token: 0x0600000D RID: 13 RVA: 0x00002320 File Offset: 0x00000520
		public override BuildingDef CreateBuildingDef()
		{
			var buildingDef = BuildingTemplates.CreateBuildingDef("asquared31415.ConveyorGasLoaderConfig", 1, 2, "conveyorin_kanim", 30, 30f, BUILDINGS.CONSTRUCTION_MASS_KG.TIER3, MATERIALS.ALL_METALS, 1600f, BuildLocationRule.Anywhere, BUILDINGS.DECOR.PENALTY.TIER1, NOISE_POLLUTION.NONE, 0.2f);
			buildingDef.Floodable = false;
			buildingDef.Overheatable = false;
			buildingDef.ViewMode = OverlayModes.SolidConveyor.ID;
			buildingDef.InputConduitType = ConduitType.Gas;
			buildingDef.UtilityInputOffset = CellOffset.none;
			buildingDef.OutputConduitType = ConduitType.Solid;
			buildingDef.UtilityOutputOffset = new CellOffset(0, 1);
			buildingDef.PermittedRotations = PermittedRotations.R360;
			buildingDef.RequiresPowerInput = true;
			buildingDef.PowerInputOffset = new CellOffset(0, 1);
			buildingDef.EnergyConsumptionWhenActive = 60f;
			buildingDef.SelfHeatKilowattsWhenActive = 0.06f;
			return buildingDef;
		}

		// Token: 0x0600000E RID: 14 RVA: 0x000023D8 File Offset: 0x000005D8
		public override void ConfigureBuildingTemplate(GameObject go, Tag prefabTag)
		{
			GeneratedBuildings.MakeBuildingAlwaysOperational(go);
			var conduitConsumer = go.AddOrGet<ConduitConsumer>();
			conduitConsumer.conduitType = ConduitType.Gas;
			conduitConsumer.consumptionRate = 10f;
			conduitConsumer.capacityKG = 20f;
			conduitConsumer.forceAlwaysSatisfied = true;
			var solidConduitDispenser = go.AddOrGet<SolidConduitDispenser>();
			solidConduitDispenser.alwaysDispense = true;
			solidConduitDispenser.elementFilter = null;
			BuildingTemplates.CreateDefaultStorage(go, false);
		}

		// Token: 0x0600000F RID: 15 RVA: 0x00002434 File Offset: 0x00000634
		public override void DoPostConfigureUnderConstruction(GameObject go)
		{
			base.DoPostConfigureUnderConstruction(go);
			go.GetComponent<Constructable>().requiredSkillPerk = Db.Get().SkillPerks.ConveyorBuild.Id;
		}

		// Token: 0x06000010 RID: 16 RVA: 0x0000245C File Offset: 0x0000065C
		public override void DoPostConfigureComplete(GameObject go)
		{
			Prioritizable.AddRef(go);
		}

		// Token: 0x04000005 RID: 5
		public const string Id = "asquared31415.ConveyorGasLoaderConfig";

		// Token: 0x04000006 RID: 6
		public const string Anim = "conveyorin_kanim";
	}
}
