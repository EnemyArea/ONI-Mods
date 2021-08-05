using System.Collections.Generic;
using TUNING;
using UnityEngine;

namespace HeavyBatteriesMod
{
	// Token: 0x02000003 RID: 3
	public class EmergencyBatteryConfig : BaseBatteryConfig
	{
		// Token: 0x06000024 RID: 36 RVA: 0x000022D4 File Offset: 0x000004D4
		public override BuildingDef CreateBuildingDef()
		{
			string id = "EmergencyBattery";
			int width = 3;
			int height = 5;
			int hitpoints = 250;
			string anim = "batterylg_kanim";
			float construction_time = 320f;
			float[] construction_mass = new float[]
			{
				(float)ConfigFile.config.emergencyBatteryCostM,
				(float)ConfigFile.config.emergencyBatteryCostI,
				(float)ConfigFile.config.emergencyBatteryCostC
			};
			string[] construction_materials = new string[]
			{
				"RefinedMetal",
				SimHashes.SuperInsulator.ToString(),
				SimHashes.Ceramic.ToString()
			};
			float melting_point = 850f;
			float exhaust_temperature_active = 0f;
			float self_heat_kilowatts_active = 0f;
			EffectorValues tier = NOISE_POLLUTION.NOISY.TIER2;
			BuildingDef buildingDef = base.CreateBuildingDef(id, width, height, hitpoints, anim, construction_time, construction_mass, construction_materials, melting_point, exhaust_temperature_active, self_heat_kilowatts_active, TUNING.BUILDINGS.DECOR.PENALTY.TIER2, tier);
			buildingDef.PermittedRotations = PermittedRotations.Unrotatable;
			SoundEventVolumeCache.instance.AddVolume("batterymed_kanim", "Battery_med_rattle", NOISE_POLLUTION.NOISY.TIER2);
            buildingDef.LogicOutputPorts = new List<LogicPorts.Port>
            {
                LogicPorts.Port.OutputPort(BatterySmart.PORT_ID, new CellOffset(0, 0), STRINGS.BUILDINGS.PREFABS.BATTERYSMART.LOGIC_PORT, STRINGS.BUILDINGS.PREFABS.BATTERYSMART.LOGIC_PORT_ACTIVE, STRINGS.BUILDINGS.PREFABS.BATTERYSMART.LOGIC_PORT_INACTIVE, true, false)
            };
			return buildingDef;
		}

		// Token: 0x06000025 RID: 37 RVA: 0x000023D7 File Offset: 0x000005D7
		public override void DoPostConfigurePreview(BuildingDef def, GameObject go)
		{
			//GeneratedBuildings.RegisterLogicPorts(go, null, EmergencyBatteryConfig.OUTPUT_PORTS);
            GeneratedBuildings.RegisterSingleLogicInputPort(go);
		}

		// Token: 0x06000026 RID: 38 RVA: 0x000023E7 File Offset: 0x000005E7
		public override void DoPostConfigureUnderConstruction(GameObject go)
		{
			//GeneratedBuildings.RegisterLogicPorts(go, null, EmergencyBatteryConfig.OUTPUT_PORTS);
            GeneratedBuildings.RegisterSingleLogicInputPort(go);
		}

		// Token: 0x06000027 RID: 39 RVA: 0x000023F8 File Offset: 0x000005F8
		public override void DoPostConfigureComplete(GameObject go)
		{
			BatterySmart batterySmart = go.AddOrGet<BatterySmart>();
			batterySmart.capacity = (float)ConfigFile.config.emergencyBatteryCapacity;
			batterySmart.joulesLostPerSecond = 0f;
			batterySmart.powerSortOrder = 1500;
			//GeneratedBuildings.RegisterLogicPorts(go, null, EmergencyBatteryConfig.OUTPUT_PORTS);
            GeneratedBuildings.RegisterSingleLogicInputPort(go);
			base.DoPostConfigureComplete(go);
		}

		// Token: 0x04000012 RID: 18
		public const string ID = "EmergencyBattery";
    }
}
