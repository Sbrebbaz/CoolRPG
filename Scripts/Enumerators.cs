using Godot;
using System;

public partial class Enumerators : Node
{
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
	public enum BattleMenuSelection
	{
		Idle,
		Item,
		Attack,
		Examine,
		Defend
	}
	public enum SoundEffects
	{
		cursor_back,
		cursor_move,
		cursor_select,
		failed,
		success
	}
}
