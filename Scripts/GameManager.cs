using Godot;
using System;
using System.Collections.Generic;
using static Enumerators;

public partial class GameManager : Node, IDialogManager, ISceneManager, IPlayerManager
{
	private SceneManager _sceneNavigator;
	private DialogManager _dialogManager;
	private PlayerManager _playerManager;

	public override void _Ready()
	{
		_sceneNavigator = GetNode<SceneManager>("/root/SceneNavigator");
		_dialogManager = GetNode<DialogManager>("/root/DialogManager");
		_playerManager = GetNode<PlayerManager>("/root/PlayerManager");
	}

	public void NavigateToScene(string scenePath)
	{
		_sceneNavigator.NavigateToScene(scenePath);
	}

	public void NavigateToGameState(GameState gameState)
	{
		_sceneNavigator.NavigateToGameState(gameState);
	}

	public void ShowDialog(DialogBase dialog)
	{
		_dialogManager.ShowDialog(dialog);
	}

	public void ShowDialog(DialogLineBase dialog)
	{
		_dialogManager.ShowDialog(dialog);
	}

	public List<ItemDataBase> GetItems()
	{
		return _playerManager.GetItems();
	}

	public List<SkillBase> GetSkills()
	{
		return _playerManager.GetSkills();
	}
}
