using Godot;
using System;
using static Enumerators;

public partial class GameManager : Node
{
	private SceneNavigator _sceneNavigator;

	public override void _Ready()
	{
		_sceneNavigator = GetNode<SceneNavigator>("/root/SceneNavigator");
	}

	public void NavigateToGameState(GameState gameState)
	{
		_sceneNavigator.NavigateToGameState(gameState);
	}
}
