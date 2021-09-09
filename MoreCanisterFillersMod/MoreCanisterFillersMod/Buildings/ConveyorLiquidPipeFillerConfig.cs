using TUNING;
using UnityEngine;

namespace MoreCanisterFillersMod.Buildings
{
	// Token: 0x0200000B RID: 11
	public class ConveyorLiquidPipeFillerConfig : IBuildingConfig
	{
		// Token: 0x0600001C RID: 28 RVA: 0x000026B4 File Offset: 0x000008B4
		public override BuildingDef CreateBuildingDef()
		{
			var buildingDef = BuildingTemplates.CreateBuildingDef("asquared31415.ConveyorLiquidPipeFillerConfig", 1, 2, "conveyorout_kanim", 30, 30f, BUILDINGS.CONSTRUCTION_MASS_KG.TIER3, MATERIALS.ALL_METALS, 1600f, BuildLocationRule.Anywhere, BUILDINGS.DECOR.PENALTY.TIER1, NOISE_POLLUTION.NONE);
			buildingDef.Floodable = false;
			buildingDef.Overheatable = false;
			buildingDef.ViewMode = OverlayModes.SolidConveyor.ID;
			buildingDef.InputConduitType = ConduitType.Solid;
			buildingDef.UtilityInputOffset = CellOffset.none;
			buildingDef.OutputConduitType = ConduitType.Liquid;
			buildingDef.UtilityOutputOffset = new CellOffset(0, 1);
			buildingDef.PermittedRotations = PermittedRotations.R360;
			return buildingDef;
		}

		// Token: 0x0600001D RID: 29 RVA: 0x00002744 File Offset: 0x00000944
		public override void ConfigureBuildingTemplate(GameObject go, Tag prefabTag)
		{
			GeneratedBuildings.MakeBuildingAlwaysOperational(go);
			go.AddOrGet<SolidConduitConsumer>();
			var conduitDispenser = go.AddOrGet<ConduitDispenser>();
			conduitDispenser.conduitType = ConduitType.Liquid;
			conduitDispenser.alwaysDispense = true;
			conduitDispenser.elementFilter = null;
			BuildingTemplates.CreateDefaultStorage(go);
		}

		// Token: 0x0600001E RID: 30 RVA: 0x00002778 File Offset: 0x00000978
		public override void DoPostConfigureUnderConstruction(GameObject go)
		{
			base.DoPostConfigureUnderConstruction(go);
			go.GetComponent<Constructable>().requiredSkillPerk = Db.Get().SkillPerks.ConveyorBuild.Id;
		}

		// Token: 0x0600001F RID: 31 RVA: 0x000027A0 File Offset: 0x000009A0
		public override void DoPostConfigureComplete(GameObject go)
		{
			Prioritizable.AddRef(go);
            go.AddOrGet<SolidConduitOutbox>();
		}

		// Token: 0x0400000B RID: 11
		public const string Id = "asquared31415.ConveyorLiquidPipeFillerConfig";

		// Token: 0x0400000C RID: 12
		public const string Anim = "conveyorout_kanim";
	}
}
