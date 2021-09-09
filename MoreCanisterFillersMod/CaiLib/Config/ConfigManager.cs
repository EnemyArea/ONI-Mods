using System;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;
using Newtonsoft.Json;

namespace CaiLib.Config
{
	// Token: 0x02000017 RID: 23
	[ComVisible(false)]
	public class ConfigManager<T> where T : class, new()
	{
		// Token: 0x17000002 RID: 2
		// (get) Token: 0x06000041 RID: 65 RVA: 0x000030D8 File Offset: 0x000012D8
		// (set) Token: 0x06000042 RID: 66 RVA: 0x000030E0 File Offset: 0x000012E0
		public T Config { get; set; }

		// Token: 0x06000043 RID: 67 RVA: 0x000030EC File Offset: 0x000012EC
		public ConfigManager(string executingAssemblyPath = null, string configFileName = "Config.json")
		{
			if (executingAssemblyPath == null)
			{
				executingAssemblyPath = Assembly.GetExecutingAssembly().Location;
			}
			this._executingAssemblyPath = executingAssemblyPath;
			this._configFileName = configFileName;
		}

		// Token: 0x06000044 RID: 68 RVA: 0x00003114 File Offset: 0x00001314
		public T ReadConfig(System.Action postReadAction = null)
		{
			this.Config = Activator.CreateInstance<T>();
			var directoryName = Path.GetDirectoryName(this._executingAssemblyPath);
			if (directoryName == null)
			{
				CaiLib.Logger.Logger.Log(string.Concat(new string[]
				{
					"Error reading config file ",
					this._configFileName,
					" - cannot get directory name for executing assembly path ",
					this._executingAssemblyPath,
					"."
				}));
				return this.Config;
			}
			var path = Path.Combine(directoryName, this._configFileName);
			T config;
			try
			{
				using (var streamReader = new StreamReader(path))
				{
					config = JsonConvert.DeserializeObject<T>(streamReader.ReadToEnd());
				}
			}
			catch (Exception ex)
			{
				CaiLib.Logger.Logger.Log("Error reading config file " + this._configFileName + " with exception: " + ex.Message);
				return this.Config;
			}
			this.Config = config;
			if (postReadAction != null)
			{
				postReadAction();
			}
			return this.Config;
		}

		// Token: 0x06000045 RID: 69 RVA: 0x00003220 File Offset: 0x00001420
		public bool SaveConfigToFile()
		{
			var directoryName = Path.GetDirectoryName(this._executingAssemblyPath);
			if (directoryName == null)
			{
				CaiLib.Logger.Logger.Log(string.Concat(new string[]
				{
					"Error reading config file ",
					this._configFileName,
					" - cannot get directory name for executing assembly path ",
					this._executingAssemblyPath,
					"."
				}));
				return false;
			}
			var path = Path.Combine(directoryName, this._configFileName);
			try
			{
				using (var streamWriter = new StreamWriter(path))
				{
					var value = JsonConvert.SerializeObject(this.Config, Formatting.Indented);
					streamWriter.Write(value);
				}
			}
			catch (Exception ex)
			{
				CaiLib.Logger.Logger.Log("Error writing to config file " + this._configFileName + " with exception: " + ex.Message);
				return false;
			}
			return true;
		}

		// Token: 0x04000012 RID: 18
		private readonly string _executingAssemblyPath;

		// Token: 0x04000013 RID: 19
		private readonly string _configFileName;
	}
}
