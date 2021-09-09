using System.Runtime.InteropServices;

namespace CaiLib.Utils
{
	// Token: 0x02000012 RID: 18
	[ComVisible(false)]
	public static class GameStrings
	{
		// Token: 0x02000020 RID: 32
		public static class PlanMenuCategory
		{
			// Token: 0x0400001F RID: 31
			public const string Base = "Base";

			// Token: 0x04000020 RID: 32
			public const string Oxygen = "Oxygen";

			// Token: 0x04000021 RID: 33
			public const string Power = "Power";

			// Token: 0x04000022 RID: 34
			public const string Food = "Food";

			// Token: 0x04000023 RID: 35
			public const string Plumbing = "Plumbing";

			// Token: 0x04000024 RID: 36
			public const string Ventilation = "HVAC";

			// Token: 0x04000025 RID: 37
			public const string Refinement = "Refining";

			// Token: 0x04000026 RID: 38
			public const string Medicine = "Medical";

			// Token: 0x04000027 RID: 39
			public const string Furniture = "Furniture";

			// Token: 0x04000028 RID: 40
			public const string Stations = "Equipment";

			// Token: 0x04000029 RID: 41
			public const string Utilities = "Utilities";

			// Token: 0x0400002A RID: 42
			public const string Automation = "Automation";

			// Token: 0x0400002B RID: 43
			public const string Shipping = "Conveyance";

			// Token: 0x0400002C RID: 44
			public const string Rocketry = "Rocketry";
		}

		// Token: 0x02000021 RID: 33
		public static class Technology
		{
			// Token: 0x02000027 RID: 39
			public static class Food
			{
				// Token: 0x04000039 RID: 57
				public const string BasicFarming = "FarmingTech";

				// Token: 0x0400003A RID: 58
				public const string MealPreparation = "FineDining";

				// Token: 0x0400003B RID: 59
				public const string Agriculture = "Agriculture";

				// Token: 0x0400003C RID: 60
				public const string Ranching = "Ranching";

				// Token: 0x0400003D RID: 61
				public const string AnimalControl = "AnimalControl";

				// Token: 0x0400003E RID: 62
				public const string GourmetMealPrep = "FinerDining";
			}

			// Token: 0x02000028 RID: 40
			public static class Power
			{
				// Token: 0x0400003F RID: 63
				public const string PowerRegulation = "PowerRegulation";

				// Token: 0x04000040 RID: 64
				public const string InternalCombustion = "Combustion";

				// Token: 0x04000041 RID: 65
				public const string FossilFuels = "ImprovedCombustion";

				// Token: 0x04000042 RID: 66
				public const string SoundAmplifiers = "Acoustics";

				// Token: 0x04000043 RID: 67
				public const string AdvancedPowerRegulation = "AdvancedPowerRegulation";

				// Token: 0x04000044 RID: 68
				public const string PlasticManufacturing = "Plastics";

				// Token: 0x04000045 RID: 69
				public const string LowResistanceConductors = "PrettyGoodConductors";

				// Token: 0x04000046 RID: 70
				public const string ValveMiniaturization = "ValveMiniaturization";

				// Token: 0x04000047 RID: 71
				public const string RenewableEnergy = "RenewableEnergy";
			}

			// Token: 0x02000029 RID: 41
			public static class SolidMaterial
			{
				// Token: 0x04000048 RID: 72
				public const string BruteForceRefinement = "BasicRefinement";

				// Token: 0x04000049 RID: 73
				public const string RefinedRenovations = "RefinedObjects";

				// Token: 0x0400004A RID: 74
				public const string SmartStorage = "SmartStorage";

				// Token: 0x0400004B RID: 75
				public const string Smelting = "Smelting";

				// Token: 0x0400004C RID: 76
				public const string SolidTransport = "SolidTransport";

				// Token: 0x0400004D RID: 77
				public const string SuperheatedForging = "HighTempForging";
			}

			// Token: 0x0200002A RID: 42
			public static class ColonyDevelopment
			{
				// Token: 0x0400004E RID: 78
				public const string Employment = "Jobs";

				// Token: 0x0400004F RID: 79
				public const string AdvancedResearch = "AdvancedResearch";
			}

			// Token: 0x0200002B RID: 43
			public static class Medicine
			{
				// Token: 0x04000050 RID: 80
				public const string Pharmacology = "MedicineI";

				// Token: 0x04000051 RID: 81
				public const string MedicalEquipment = "MedicineII";

				// Token: 0x04000052 RID: 82
				public const string PathogenDiagnostics = "MedicineIII";

				// Token: 0x04000053 RID: 83
				public const string MicroTargetedMedicine = "MedicineIV";
			}

			// Token: 0x0200002C RID: 44
			public static class Liquids
			{
				// Token: 0x04000054 RID: 84
				public const string Plumbing = "LiquidPiping";

				// Token: 0x04000055 RID: 85
				public const string AirSystems = "ImprovedOxygen";

				// Token: 0x04000056 RID: 86
				public const string Sanitation = "SanitationSciences";

				// Token: 0x04000057 RID: 87
				public const string Filtration = "AdvancedFiltration";

				// Token: 0x04000058 RID: 88
				public const string LiquidBasedRefinementProcess = "LiquidFiltering";

				// Token: 0x04000059 RID: 89
				public const string Distillation = "Distillation";

				// Token: 0x0400005A RID: 90
				public const string ImprovedPlumbing = "ImprovedLiquidPiping";

				// Token: 0x0400005B RID: 91
				public const string LiquidTuning = "LiquidTemperature";

				// Token: 0x0400005C RID: 92
				public const string AdvancedCaffeination = "PrecisionPlumbing";
			}

			// Token: 0x0200002D RID: 45
			public static class Gases
			{
				// Token: 0x0400005D RID: 93
				public const string Ventilation = "GasPiping";

				// Token: 0x0400005E RID: 94
				public const string PressureManagement = "PressureManagement";

				// Token: 0x0400005F RID: 95
				public const string TemperatureModulation = "TemperatureModulation";

				// Token: 0x04000060 RID: 96
				public const string Decontamination = "DirectedAirStreams";

				// Token: 0x04000061 RID: 97
				public const string ImprovedVentilation = "ImprovedGasPiping";

				// Token: 0x04000062 RID: 98
				public const string HVAC = "HVAC";

				// Token: 0x04000063 RID: 99
				public const string Catalytics = "Catalytics";
			}

			// Token: 0x0200002E RID: 46
			public static class Exosuits
			{
				// Token: 0x04000064 RID: 100
				public const string HazardProtection = "Suits";

				// Token: 0x04000065 RID: 101
				public const string TransitTubes = "TravelTubes";

				// Token: 0x04000066 RID: 102
				public const string Jetpacks = "Jetpacks";
			}

			// Token: 0x0200002F RID: 47
			public static class Decor
			{
				// Token: 0x04000067 RID: 103
				public const string InteriorDecor = "InteriorDecor";

				// Token: 0x04000068 RID: 104
				public const string ArtisticExpression = "Artistry";

				// Token: 0x04000069 RID: 105
				public const string TextileProduction = "Clothing";

				// Token: 0x0400006A RID: 106
				public const string FineArt = "FineArt";

				// Token: 0x0400006B RID: 107
				public const string HomeLuxuries = "Luxury";

				// Token: 0x0400006C RID: 108
				public const string HighCulture = "RefractiveDecor";

				// Token: 0x0400006D RID: 109
				public const string GlassBlowing = "GlassFurnishings";

				// Token: 0x0400006E RID: 110
				public const string RenaissanceArt = "RenaissanceArt";
			}

			// Token: 0x02000030 RID: 48
			public static class Computers
			{
				// Token: 0x0400006F RID: 111
				public const string SmartHome = "LogicControl";

				// Token: 0x04000070 RID: 112
				public const string GenericSensors = "GenericSensors";

				// Token: 0x04000071 RID: 113
				public const string AdvancedAutomation = "LogicCircuits";

				// Token: 0x04000072 RID: 114
				public const string Computing = "DupeTrafficControl";
			}

			// Token: 0x02000031 RID: 49
			public static class Rocketry
			{
				// Token: 0x04000073 RID: 115
				public const string CelestialDetection = "SkyDetectors";

				// Token: 0x04000074 RID: 116
				public const string IntroductoryRocketry = "BasicRocketry";

				// Token: 0x04000075 RID: 117
				public const string SolidFuelCombustion = "EnginesI";

				// Token: 0x04000076 RID: 118
				public const string SolidCargo = "CargoI";

				// Token: 0x04000077 RID: 119
				public const string HydrocarbonCombustion = "EnginesII";

				// Token: 0x04000078 RID: 120
				public const string LiquidAndGasCargo = "CargoII";

				// Token: 0x04000079 RID: 121
				public const string CryofuelCombustion = "EnginesIII";

				// Token: 0x0400007A RID: 122
				public const string UniqueCargo = "CargoIII";
			}
		}
	}
}
