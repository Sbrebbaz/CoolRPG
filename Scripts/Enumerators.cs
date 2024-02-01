using Godot;
using System;

public partial class Enumerators : Node
{
	[Flags]
	public enum GameState
	{
		MainMenu,
		Options,
		NewGameCreation,
		ContinueGame,
		InGame,
		Pause,
		Unpause,
		Quit
	}
	[Flags]
	public enum Element
	{
		Bland = 1,
		Salty = 2,
		Sour = 4,
		Sweet = 8,
		Bitter = 16,
		Umami = 32,
	}
}