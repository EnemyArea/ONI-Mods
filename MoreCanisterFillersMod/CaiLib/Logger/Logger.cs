using System;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;

namespace CaiLib.Logger
{
	// Token: 0x02000016 RID: 22
	[ComVisible(false)]
	public static class Logger
	{
		// Token: 0x0600003C RID: 60 RVA: 0x00002F88 File Offset: 0x00001188
		public static void LogInit()
		{
			Console.WriteLine(string.Format("{0} <<-- CaiLib -->> Loaded [ {1} ] with version {2}", Logger.Timestamp(), Logger.GetModName(), Assembly.GetExecutingAssembly().GetName().Version));
		}

		// Token: 0x0600003D RID: 61 RVA: 0x00002FB4 File Offset: 0x000011B4
		public static void Log(string message)
		{
			Console.WriteLine(string.Concat(new string[]
			{
				Logger.Timestamp(),
				" <<-- ",
				Logger.GetModName(),
				" -->> ",
				message
			}));
		}

		// Token: 0x0600003E RID: 62 RVA: 0x00002FEC File Offset: 0x000011EC
		private static string Timestamp()
		{
			return System.DateTime.UtcNow.ToString("[HH:mm:ss.fff]");
		}

		// Token: 0x0600003F RID: 63 RVA: 0x00003010 File Offset: 0x00001210
		private static string GetModName()
		{
			if (Logger._modName != string.Empty)
			{
				return Logger._modName;
			}
			var executingAssembly = Assembly.GetExecutingAssembly();
			var name = executingAssembly.GetName().Name;
			var type = executingAssembly.GetExportedTypes().FirstOrDefault((Type p) => p.GetInterfaces().Contains(typeof(IModInfo)));
			if (type == null)
			{
				return name;
			}
			var obj = Activator.CreateInstance(type);
			var property = type.GetProperty("Name");
			var obj2 = (property != null) ? property.GetValue(obj, null) : null;
			Logger._modName = ((obj2 == null) ? name : obj2.ToString());
			return Logger._modName;
		}

		// Token: 0x04000010 RID: 16
		private static string _modName = string.Empty;
	}
}
