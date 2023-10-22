using Godot;
using static CoolRPG.Scripts.Constants;
using static CoolRPG.Scripts.Requirements;

namespace CoolRPG.Scripts
{
	internal partial class GameManager : Node
	{
		public SaveFileModel SaveFile_1 { get; set; } = new SaveFileModel(SaveFileName_1);
		public SaveFileModel SaveFile_2 { get; set; } = new SaveFileModel(SaveFileName_2);
		public SaveFileModel SaveFile_3 { get; set; } = new SaveFileModel(SaveFileName_3);

		public override void _Ready()
		{
			CreateBaseFolders();
			LoadSaveData();
			base._Ready();
		}

		private void LoadSaveData()
		{
			SaveFile_1.LoadFile();
			SaveFile_2.LoadFile();
			SaveFile_3.LoadFile();
		}

	}
}
