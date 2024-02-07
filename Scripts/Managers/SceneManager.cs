using Godot;
using System;
using static Enumerators;

public partial class SceneManager : Node, ISceneManager
{
	private PauseMenu _pauseMenu;
	private GameState _currentGameState;

	public override void _Ready()
	{
		_currentGameState = GameState.MainMenu;
		_pauseMenu = ResourceLoader.Load<PackedScene>("res://Scenes/PauseMenu/PauseMenu.tscn").Instantiate<PauseMenu>();
	}

	public void NavigateToGameState(GameState gameStateToNavigateTo)
	{
		if (gameStateToNavigateTo != _currentGameState)	
		{
			_currentGameState = gameStateToNavigateTo;
			switch (gameStateToNavigateTo)
			{
				case GameState.MainMenu:
					{
						GetTree().ChangeSceneToFile("res://Scenes/MainMenu/MainMenu.tscn");
						break;
					}
				case GameState.Options:
					{
						GetTree().ChangeSceneToFile("res://Scenes/Options/Options.tscn");
						break;
					}
				case GameState.NewGameCreation:
					{
						GetTree().ChangeSceneToFile("res://Scenes/NewGame/NewGame.tscn");
						break;
					}
				case GameState.ContinueGame:
					{
						GetTree().ChangeSceneToFile("res://Scenes/TestLevel/TestLevel.tscn");
						break;
					}
				case GameState.InGame:
					{
						GetTree().ChangeSceneToFile("");
						break;
					}
				case GameState.Pause:
					{
						AddChild(_pauseMenu);
						break;
					}
				case GameState.Unpause:
					{
						RemoveChild(_pauseMenu);
						break;
					}
				case GameState.Quit:
					{
						GetTree().Quit();
						break;
					}
			}
		}
	}

	public void NavigateToScene(string scenePath)
	{
		GetTree().ChangeSceneToFile(scenePath);
	}
}
