using CoolRPG.Scripts;
using System.IO;

namespace CoolRPG.Scripts
{
	public static class Requirements
	{
		public static void CreateBaseFolders()
		{
			if (!Directory.Exists(Constants.PersistentDataPath))
			{
				Directory.CreateDirectory(Constants.PersistentDataPath);
			}
		}
	}
}