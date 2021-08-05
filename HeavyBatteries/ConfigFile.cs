using System.IO;
using Newtonsoft.Json;

namespace HeavyBatteriesMod
{
	// Token: 0x02000002 RID: 2
	public class ConfigFile
	{
		// Token: 0x06000001 RID: 1 RVA: 0x00002050 File Offset: 0x00000250
		public static void loadFile(string modPath)
		{
			ConfigFile.config = ConfigFile.loadFile<ConfigFile>(Path.Combine(modPath, "Config.json"));
		}

		// Token: 0x06000002 RID: 2 RVA: 0x00002068 File Offset: 0x00000268
		protected static T loadFile<T>(string path)
		{
			JsonSerializer jsonSerializer = JsonSerializer.CreateDefault(new JsonSerializerSettings
			{
				Formatting = Formatting.Indented,
				ObjectCreationHandling = ObjectCreationHandling.Replace
			});
			T result;
			using (StreamReader streamReader = new StreamReader(path))
			{
				using (JsonTextReader jsonTextReader = new JsonTextReader(streamReader))
				{
					result = jsonSerializer.Deserialize<T>(jsonTextReader);
					jsonTextReader.Close();
				}
				streamReader.Close();
			}
			return result;
		}

		// Token: 0x17000001 RID: 1
		// (get) Token: 0x06000003 RID: 3 RVA: 0x000020F8 File Offset: 0x000002F8
		// (set) Token: 0x06000004 RID: 4 RVA: 0x00002100 File Offset: 0x00000300
		public int heavyBatteryCost { get; set; } = 800;

		// Token: 0x17000002 RID: 2
		// (get) Token: 0x06000005 RID: 5 RVA: 0x00002109 File Offset: 0x00000309
		// (set) Token: 0x06000006 RID: 6 RVA: 0x00002111 File Offset: 0x00000311
		public double heavyBatterySelfHeat { get; set; } = 0.5;

		// Token: 0x17000003 RID: 3
		// (get) Token: 0x06000007 RID: 7 RVA: 0x0000211A File Offset: 0x0000031A
		// (set) Token: 0x06000008 RID: 8 RVA: 0x00002122 File Offset: 0x00000322
		public double heavyBatteryHeatExhaust { get; set; } = 2.0;

		// Token: 0x17000004 RID: 4
		// (get) Token: 0x06000009 RID: 9 RVA: 0x0000212B File Offset: 0x0000032B
		// (set) Token: 0x0600000A RID: 10 RVA: 0x00002133 File Offset: 0x00000333
		public int heavyBatteryCapacity { get; set; } = 320000;

		// Token: 0x17000005 RID: 5
		// (get) Token: 0x0600000B RID: 11 RVA: 0x0000213C File Offset: 0x0000033C
		// (set) Token: 0x0600000C RID: 12 RVA: 0x00002144 File Offset: 0x00000344
		public int heavySmartBatteryCost { get; set; } = 650;

		// Token: 0x17000006 RID: 6
		// (get) Token: 0x0600000D RID: 13 RVA: 0x0000214D File Offset: 0x0000034D
		// (set) Token: 0x0600000E RID: 14 RVA: 0x00002155 File Offset: 0x00000355
		public double heavySmartBatterySelfHeat { get; set; } = 0.0;

		// Token: 0x17000007 RID: 7
		// (get) Token: 0x0600000F RID: 15 RVA: 0x0000215E File Offset: 0x0000035E
		// (set) Token: 0x06000010 RID: 16 RVA: 0x00002166 File Offset: 0x00000366
		public double heavySmartBatteryHeatExhaust { get; set; } = 0.8;

		// Token: 0x17000008 RID: 8
		// (get) Token: 0x06000011 RID: 17 RVA: 0x0000216F File Offset: 0x0000036F
		// (set) Token: 0x06000012 RID: 18 RVA: 0x00002177 File Offset: 0x00000377
		public int heavySmartBatteryCapacity { get; set; } = 160000;

		// Token: 0x17000009 RID: 9
		// (get) Token: 0x06000013 RID: 19 RVA: 0x00002180 File Offset: 0x00000380
		// (set) Token: 0x06000014 RID: 20 RVA: 0x00002188 File Offset: 0x00000388
		public bool emergencyBatteryEnabled { get; set; } = true;

		// Token: 0x1700000A RID: 10
		// (get) Token: 0x06000015 RID: 21 RVA: 0x00002191 File Offset: 0x00000391
		// (set) Token: 0x06000016 RID: 22 RVA: 0x00002199 File Offset: 0x00000399
		public int emergencyBatteryCostM { get; set; } = 700;

		// Token: 0x1700000B RID: 11
		// (get) Token: 0x06000017 RID: 23 RVA: 0x000021A2 File Offset: 0x000003A2
		// (set) Token: 0x06000018 RID: 24 RVA: 0x000021AA File Offset: 0x000003AA
		public int emergencyBatteryCostI { get; set; } = 200;

		// Token: 0x1700000C RID: 12
		// (get) Token: 0x06000019 RID: 25 RVA: 0x000021B3 File Offset: 0x000003B3
		// (set) Token: 0x0600001A RID: 26 RVA: 0x000021BB File Offset: 0x000003BB
		public int emergencyBatteryCostC { get; set; } = 150;

		// Token: 0x1700000D RID: 13
		// (get) Token: 0x0600001B RID: 27 RVA: 0x000021C4 File Offset: 0x000003C4
		// (set) Token: 0x0600001C RID: 28 RVA: 0x000021CC File Offset: 0x000003CC
		public int emergencyBatteryCapacity { get; set; } = 25000;

		// Token: 0x1700000E RID: 14
		// (get) Token: 0x0600001D RID: 29 RVA: 0x000021D5 File Offset: 0x000003D5
		// (set) Token: 0x0600001E RID: 30 RVA: 0x000021DD File Offset: 0x000003DD
		public int heavyTransformerCostM { get; set; } = 600;

		// Token: 0x1700000F RID: 15
		// (get) Token: 0x0600001F RID: 31 RVA: 0x000021E6 File Offset: 0x000003E6
		// (set) Token: 0x06000020 RID: 32 RVA: 0x000021EE File Offset: 0x000003EE
		public int heavyTransformerCostC { get; set; } = 100;

		// Token: 0x17000010 RID: 16
		// (get) Token: 0x06000021 RID: 33 RVA: 0x000021F7 File Offset: 0x000003F7
		// (set) Token: 0x06000022 RID: 34 RVA: 0x000021FF File Offset: 0x000003FF
		public int heavyTransformerCostI { get; set; } = 100;

		// Token: 0x04000001 RID: 1
		public static ConfigFile config;
	}
}
