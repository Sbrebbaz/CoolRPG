using Godot;
using System;
using System.Collections.Generic;
using static Enumerators;

public partial class GameManager 
	: Node, 
	IDialogManager, 
	ISceneManager, 
	IPlayerManager, 
	ISoundManager,
	IMusicManager
{
	private SceneManager _sceneManager;
	private DialogManager _dialogManager;
	private PlayerManager _playerManager;
	private SoundManager _soundManager;
	private MusicManager _musicManager;

	public override void _Ready()
	{
		_sceneManager = GetNode<SceneManager>("/root/SceneManager");
		_dialogManager = GetNode<DialogManager>("/root/DialogManager");
		_playerManager = GetNode<PlayerManager>("/root/PlayerManager");
		_soundManager = GetNode<SoundManager>("/root/SoundManager");
		_musicManager = GetNode<MusicManager>("/root/MusicManager");
	}

	public void NavigateToScene(string scenePath)
	{
		_sceneManager.NavigateToScene(scenePath);
	}

	public void NavigateToGameState(GameState gameState)
	{
		_sceneManager.NavigateToGameState(gameState);
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

	public void PlaySound(SoundEffects soundEffectToPlay)
	{
		_soundManager.PlaySound(soundEffectToPlay);
	}
}
