using System;
using TUNING;
using UnityEngine;

namespace MoreCanisterFillersMod.Buildings
{
	// Token: 0x02000009 RID: 9
	public class ConveyorGasPipeFillerConfig : IBuildingConfig
	{
		// Token: 0x06000012 RID: 18 RVA: 0x0000246C File Offset: 0x0000066C
		public override BuildingDef CreateBuildingDef()
		{
			var buildingDef = BuildingTemplates.CreateBuildingDef("asquared31415.ConveyorGasPipeFillerConfig", 1, 2, "conveyorout_kanim", 30, 30f, BUILDINGS.CONSTRUCTION_MASS_KG.TIER3, MATERIALS.ALL_METALS, 1600f, BuildLocationRule.Anywhere, BUILDINGS.DECOR.PENALTY.TIER1, NOISE_POLLUTION.NONE, 0.2f);
			buildingDef.Floodable = false;
			buildingDef.Overheatable = false;
			buildingDef.ViewMode = OverlayModes.SolidConveyor.ID;
			buildingDef.InputConduitType = ConduitType.Solid;
			buildingDef.UtilityInputOffset = CellOffset.none;
			buildingDef.OutputConduitType = ConduitType.Gas;
			buildingDef.UtilityOutputOffset = new CellOffset(0, 1);
			buildingDef.PermittedRotations = PermittedRotations.R360;
			return buildingDef;
		}

		// Token: 0x06000013 RID: 19 RVA: 0x000024FC File Offset: 0x000006FC
		public override void ConfigureBuildingTemplate(GameObject go, Tag prefabTag)
		{
			GeneratedBuildings.MakeBuildingAlwaysOperational(go);
			go.AddOrGet<SolidConduitConsumer>();
			var conduitDispenser = go.AddOrGet<ConduitDispenser>();
			conduitDispenser.conduitType = ConduitType.Gas;
			conduitDispenser.alwaysDispense = true;
			conduitDispenser.elementFilter = null;
			BuildingTemplates.CreateDefaultStorage(go, false);
		}

		// Token: 0x06000014 RID: 20 RVA: 0x00002530 File Offset: 0x00000730
		public override void DoPostConfigureUnderConstruction(GameObject go)
		{
			base.DoPostConfigureUnderConstruction(go);
			go.GetComponent<Constructable>().requiredSkillPerk = Db.Get().SkillPerks.ConveyorBuild.Id;
		}

		// Token: 0x06000015 RID: 21 RVA: 0x00002558 File Offset: 0x00000758
		public override void DoPostConfigureComplete(GameObject go)
		{
			Prioritizable.AddRef(go);
		}

		// Token: 0x04000007 RID: 7
		public const string Id = "asquared31415.ConveyorGasPipeFillerConfig";

		// Token: 0x04000008 RID: 8
		public const string Anim = "conveyorout_kanim";
	}
}
