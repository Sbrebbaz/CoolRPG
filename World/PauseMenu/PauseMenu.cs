using Godot;
using System;
using static Enumerators;

public partial class PauseMenu : CanvasLayer
{
	private GameManager _gameManager;

	public override void _Ready()
	{
		_gameManager = GetNode<GameManager>("/root/GameManager");
	}

	private void _on_resume_button_pressed()
	{
		_gameManager.NavigateToGameState(GameState.Unpause);
	}

	private void _on_exit_button_pressed()
	{
		_gameManager.NavigateToGameState(GameState.Unpause);
		_gameManager.NavigateToGameState(GameState.MainMenu);
	}
}
