using Godot;
using System;
using static Enumerators;

public partial class GameManager : Node
{
	private SceneNavigator _sceneNavigator;
	private DialogManager _dialogManager;

	public override void _Ready()
	{
		_sceneNavigator = GetNode<SceneNavigator>("/root/SceneNavigator");
		_dialogManager = GetNode<DialogManager>("/root/DialogManager");
	}

	public void NavigateToGameState(GameState gameState)
	{
		_sceneNavigator.NavigateToGameState(gameState);
	}
}
