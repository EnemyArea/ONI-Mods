using System.Collections.Generic;
using TUNING;
using UnityEngine;

namespace HeavyBatteriesMod
{
	// Token: 0x0200000A RID: 10
	public class HeavySmartBatteryConfig : BaseBatteryConfig
	{
		// Token: 0x06000037 RID: 55 RVA: 0x00002A34 File Offset: 0x00000C34
		public override BuildingDef CreateBuildingDef()
		{
			string id = "HeavySmartBattery";
			int width = 4;
			int height = 4;
			int hitpoints = 75;
			string anim = "smartbattery_kanim";
			float construction_time = 160f;
			float[] construction_mass = new float[]
			{
				(float)ConfigFile.config.heavySmartBatteryCost
			};
			string[] refined_METALS = MATERIALS.REFINED_METALS;
			float melting_point = 800f;
			float exhaust_temperature_active = (float)ConfigFile.config.heavySmartBatteryHeatExhaust;
			float self_heat_kilowatts_active = (float)ConfigFile.config.heavySmartBatterySelfHeat;
			EffectorValues tier = NOISE_POLLUTION.NOISY.TIER1;
			BuildingDef buildingDef = base.CreateBuildingDef(id, width, height, hitpoints, anim, construction_time, construction_mass, refined_METALS, melting_point, exhaust_temperature_active, self_heat_kilowatts_active, BUILDINGS.DECOR.PENALTY.TIER3, tier);
			SoundEventVolumeCache.instance.AddVolume("batterymed_kanim", "Battery_med_rattle", NOISE_POLLUTION.NOISY.TIER2);
            buildingDef.LogicOutputPorts = new List<LogicPorts.Port>
            {
                LogicPorts.Port.OutputPort(BatterySmart.PORT_ID, new CellOffset(0, 0), STRINGS.BUILDINGS.PREFABS.BATTERYSMART.LOGIC_PORT, STRINGS.BUILDINGS.PREFABS.BATTERYSMART.LOGIC_PORT_ACTIVE, STRINGS.BUILDINGS.PREFABS.BATTERYSMART.LOGIC_PORT_INACTIVE, true)
            };
			return buildingDef;
		}

		// Token: 0x06000038 RID: 56 RVA: 0x00002AE5 File Offset: 0x00000CE5
		public override void DoPostConfigurePreview(BuildingDef def, GameObject go)
		{
			//GeneratedBuildings.RegisterLogicPorts(go, null, HeavySmartBatteryConfig.OUTPUT_PORTS);
            GeneratedBuildings.RegisterSingleLogicInputPort(go);
		}

		// Token: 0x06000039 RID: 57 RVA: 0x00002AF5 File Offset: 0x00000CF5
		public override void DoPostConfigureUnderConstruction(GameObject go)
		{
			//GeneratedBuildings.RegisterLogicPorts(go, null, HeavySmartBatteryConfig.OUTPUT_PORTS);
            GeneratedBuildings.RegisterSingleLogicInputPort(go);
		}

		// Token: 0x0600003A RID: 58 RVA: 0x00002B08 File Offset: 0x00000D08
		public override void DoPostConfigureComplete(GameObject go)
		{
			BatterySmart batterySmart = go.AddOrGet<BatterySmart>();
			batterySmart.capacity = (float)ConfigFile.config.heavySmartBatteryCapacity;
			batterySmart.joulesLostPerSecond = batterySmart.capacity * 0.005f / 600f;
			batterySmart.powerSortOrder = 1000;
            //GeneratedBuildings.RegisterLogicPorts(go, null, HeavySmartBatteryConfig.OUTPUT_PORTS);
			GeneratedBuildings.RegisterSingleLogicInputPort(go);
			base.DoPostConfigureComplete(go);
		}

		// Token: 0x04000015 RID: 21
		public const string ID = "HeavySmartBattery";
    }
}
