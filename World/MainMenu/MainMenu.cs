using Godot;
using static Enumerators;

public partial class MainMenu : MarginContainer
{
	private GameManager _gameManager;

	public override void _Ready()
	{
		_gameManager = GetNode<GameManager>("/root/GameManager");
	}

	private void _on_continue_button_pressed()
	{
		_gameManager.NavigateToGameState(GameState.ContinueGame);
	}

	private void _on_new_game_button_pressed()
	{
		_gameManager.NavigateToGameState(GameState.NewGameCreation);
	}

	private void _on_options_button_pressed()
	{
		_gameManager.NavigateToGameState(GameState.Options);
	}

	private void _on_quit_button_pressed()
	{
		_gameManager.NavigateToGameState(GameState.Quit);
	}

}
