using Godot;
using System;
using static Enumerators;

public partial class Options : MarginContainer
{
	private GameManager _gameManager;

	public override void _Ready()
	{
		_gameManager = GetNode<GameManager>("/root/GameManager");
	}

	private void _on_button_pressed()
	{
		_gameManager.NavigateToGameState(GameState.MainMenu);
	}
}
