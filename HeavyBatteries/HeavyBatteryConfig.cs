using TUNING;
using UnityEngine;

namespace HeavyBatteriesMod
{
	// Token: 0x02000009 RID: 9
	public class HeavyBatteryConfig : BaseBatteryConfig
	{
		// Token: 0x06000034 RID: 52 RVA: 0x00002938 File Offset: 0x00000B38
		public override BuildingDef CreateBuildingDef()
		{
			string id = "HeavyBattery";
			int width = 4;
			int height = 4;
			int hitpoints = 75;
			string anim = "batterymed_kanim";
			float construction_time = 140f;
			float[] construction_mass = new float[]
			{
				(float)ConfigFile.config.heavyBatteryCost
			};
			string[] all_METALS = MATERIALS.ALL_METALS;
			float melting_point = 800f;
			float exhaust_temperature_active = (float)ConfigFile.config.heavyBatteryHeatExhaust;
			float self_heat_kilowatts_active = (float)ConfigFile.config.heavyBatterySelfHeat;
			EffectorValues tier = NOISE_POLLUTION.NOISY.TIER1;
			BuildingDef result = base.CreateBuildingDef(id, width, height, hitpoints, anim, construction_time, construction_mass, all_METALS, melting_point, exhaust_temperature_active, self_heat_kilowatts_active, BUILDINGS.DECOR.PENALTY.TIER3, tier);
			SoundEventVolumeCache.instance.AddVolume("batterymed_kanim", "Battery_med_rattle", NOISE_POLLUTION.NOISY.TIER2);
			return result;
		}

		// Token: 0x06000035 RID: 53 RVA: 0x000029EC File Offset: 0x00000BEC
		public override void DoPostConfigureComplete(GameObject go)
		{
			Battery battery = go.AddOrGet<Battery>();
			battery.capacity = (float)ConfigFile.config.heavyBatteryCapacity;
			battery.joulesLostPerSecond = battery.capacity * 0.005f / 600f;
			base.DoPostConfigureComplete(go);
		}

		// Token: 0x04000014 RID: 20
		public const string ID = "HeavyBattery";
	}
}
