using Godot;
using System;
using static Enumerators;

public partial class SceneNavigator : Node
{
	private SceneTree sceneTree;
	private PauseMenu _pauseMenu;
	private GameState _currentGameState;
	private Camera2D _currentCamera;

	public override void _Ready()
	{
		_currentGameState = GameState.MainMenu;
		_pauseMenu = ResourceLoader.Load<PackedScene>("res://World/PauseMenu/PauseMenu.tscn").Instantiate<PauseMenu>();
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
						GetTree().ChangeSceneToFile("res://World/MainMenu/MainMenu.tscn");
						break;
					}
				case GameState.Options:
					{
						GetTree().ChangeSceneToFile("res://World/Options/Options.tscn");
						break;
					}
				case GameState.NewGameCreation:
					{
						GetTree().ChangeSceneToFile("res://World/NewGame/NewGame.tscn");
						break;
					}
				case GameState.ContinueGame:
					{
						
						GetTree().ChangeSceneToFile("res://World/TestLevel/TestLevel.tscn");
						break;
					}
				case GameState.InGame:
					{
						GetTree().ChangeSceneToFile("");
						break;
					}
				case GameState.Pause:
					{
						_currentCamera = GetViewport().GetCamera2D();
						//_currentCamera.Enabled = false;
						AddChild(_pauseMenu);
						break;
					}
				case GameState.Unpause:
					{
						_currentCamera.Enabled = true;
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
}
