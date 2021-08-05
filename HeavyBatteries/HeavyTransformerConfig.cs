using TUNING;
using UnityEngine;

namespace HeavyBatteriesMod
{
	// Token: 0x0200000B RID: 11
	public class HeavyTransformerConfig : IBuildingConfig
	{
		// Token: 0x0600003D RID: 61 RVA: 0x00002BB8 File Offset: 0x00000DB8
		public override BuildingDef CreateBuildingDef()
		{
			string id = "HeavyTransformer";
			int width = 5;
			int height = 4;
			string anim = "transformer_kanim";
			int hitpoints = 45;
			float construction_time = 50f;
			float[] construction_mass = new float[]
			{
				(float)ConfigFile.config.heavyTransformerCostM,
				(float)ConfigFile.config.heavyTransformerCostC,
				(float)ConfigFile.config.heavyTransformerCostI
			};
			string[] construction_materials = new string[]
			{
				"RefinedMetal",
				SimHashes.Copper.ToString(),
				SimHashes.SuperInsulator.ToString()
			};
			float melting_point = 800f;
			BuildLocationRule build_location_rule = BuildLocationRule.OnFloor;
			EffectorValues tier = NOISE_POLLUTION.NOISY.TIER6;
			BuildingDef buildingDef = BuildingTemplates.CreateBuildingDef(id, width, height, anim, hitpoints, construction_time, construction_mass, construction_materials, melting_point, build_location_rule, BUILDINGS.DECOR.PENALTY.TIER1, tier, 0.2f);
			buildingDef.RequiresPowerInput = true;
            buildingDef.RequiresPowerOutput = true;
			buildingDef.UseWhitePowerOutputConnectorColour = true;
			buildingDef.PowerInputOffset = new CellOffset(-2, 2);
			buildingDef.PowerOutputOffset = new CellOffset(2, 0);
			buildingDef.ElectricalArrowOffset = new CellOffset(1, 0);
			buildingDef.ExhaustKilowattsWhenActive = 2f;
			buildingDef.SelfHeatKilowattsWhenActive = 3f;
			buildingDef.ViewMode = OverlayModes.Power.ID;
			buildingDef.AudioCategory = "Metal";
			buildingDef.Entombable = true;
			buildingDef.GeneratorWattageRating = 12000f;
			buildingDef.GeneratorBaseCapacity = 12000f;
			buildingDef.PermittedRotations = PermittedRotations.FlipH;
			return buildingDef;
		}

		// Token: 0x0600003E RID: 62 RVA: 0x00002D20 File Offset: 0x00000F20
		public override void ConfigureBuildingTemplate(GameObject go, Tag prefab_tag)
		{
			go.GetComponent<KPrefabID>().AddTag(RoomConstraints.ConstraintTags.IndustrialMachinery, false);
			go.AddComponent<RequireInputs>();
			BuildingDef def = go.GetComponent<Building>().Def;
			Battery battery = go.AddOrGet<Battery>();
			battery.powerSortOrder = 1000;
			battery.capacity = def.GeneratorWattageRating;
			battery.chargeWattage = def.GeneratorWattageRating;
			PowerTransformer powerTransformer = go.AddComponent<PowerTransformer>();
			powerTransformer.powerDistributionOrder = 9;
		}

		// Token: 0x0600003F RID: 63 RVA: 0x00002D8C File Offset: 0x00000F8C
		public override void DoPostConfigureComplete(GameObject go)
		{
			UnityEngine.Object.DestroyImmediate(go.GetComponent<EnergyConsumer>());
			go.AddOrGetDef<PoweredActiveController.Def>();
		}

		// Token: 0x04000017 RID: 23
		public const string ID = "HeavyTransformer";
	}
}
