using Godot;
using System.Threading;
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
		_gameManager.PlaySound(SoundEffects.cursor_back);
		_gameManager.NavigateToGameState(GameState.ContinueGame);
	}

	private void _on_new_game_button_pressed()
	{
		_gameManager.PlaySound(SoundEffects.cursor_move);
		_gameManager.NavigateToGameState(GameState.NewGameCreation);
	}

	private void _on_options_button_pressed()
	{
		_gameManager.PlaySound(SoundEffects.cursor_select);
		_gameManager.NavigateToGameState(GameState.Options);
	}

	private void _on_quit_button_pressed()
	{
		_gameManager.PlaySound(SoundEffects.failed);
		Thread.Sleep(1000);
		_gameManager.NavigateToGameState(GameState.Quit);
	}

	private void _on_debug_button_pressed()
	{
		_gameManager.PlaySound(SoundEffects.success);
		_gameManager.NavigateToScene("res://Scenes/Battle/Battle.tscn");
	}

}
