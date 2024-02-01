using Godot;
using System;
using static Enumerators;

public partial class NewGame : MarginContainer
{
	private GameManager _gameManager;

	public override void _Ready()
	{
		_gameManager = GetNode<GameManager>("/root/GameManager");
	}

	private void _on_back_button_pressed()
	{
		_gameManager.NavigateToGameState(GameState.MainMenu);
	}

	private void _on_start_button_pressed()
	{
		_gameManager.NavigateToGameState(GameState.ContinueGame);
	}
}
