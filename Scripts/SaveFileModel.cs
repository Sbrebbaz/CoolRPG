using Newtonsoft.Json;
using System.IO;
using System.Security.Cryptography.X509Certificates;
using static CoolRPG.Scripts.Constants;

namespace CoolRPG.Scripts
{
	internal class SaveFileModel
	{
		[JsonIgnore]
		public string FullFilePath
		{
			get
			{
				return Path.Join(PersistentDataPath, FileName) + SaveFileExtention;
			}
		}

		public string FileName { get; set; }

		//TODO manage all the data that is required to be saved

		public SaveFileModel(string fileName)
		{
			FileName = fileName;
		}

		public bool SaveFile()
		{
			bool toReturn = true;

			try
			{
				File.WriteAllText(FullFilePath, JsonConvert.SerializeObject(this, Formatting.Indented));
			}
			catch { toReturn = false; }

			return toReturn;
		}

		public bool LoadFile()
		{
			bool toReturn = true;

			try
			{
				if (!File.Exists(FullFilePath))
				{
					SaveFile();
				}

				JsonConvert.DeserializeObject<SaveFileModel>(File.ReadAllText(FullFilePath));
			}
			catch { toReturn = false; }

			return toReturn;
		}
	}
}
