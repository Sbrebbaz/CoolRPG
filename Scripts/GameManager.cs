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
    IMusicManager,
    IBattleManager,
    IDebugManager

{
    private SceneManager _sceneManager;
    private DialogManager _dialogManager;
    private PlayerManager _playerManager;
    private SoundManager _soundManager;
    private MusicManager _musicManager;
    private BattleManager _battleManager;
    private DebugManager _debugManager;

    public override void _Ready()
    {
        _sceneManager = GetNode<SceneManager>("/root/SceneManager");
        _dialogManager = GetNode<DialogManager>("/root/DialogManager");
        _playerManager = GetNode<PlayerManager>("/root/PlayerManager");
        _soundManager = GetNode<SoundManager>("/root/SoundManager");
        _musicManager = GetNode<MusicManager>("/root/MusicManager");
        _battleManager = GetNode<BattleManager>("/root/BattleManager");
        _debugManager = GetNode<DebugManager>("/root/DebugManager");

    }

    #region DialogManager

    public void ShowDialog(DialogBase dialog)
    {
        _dialogManager.ShowDialog(dialog);
    }

    public void ShowDialog(DialogLineBase dialog)
    {
        _dialogManager.ShowDialog(dialog);
    }

	public void CloseDialog()
	{
		_dialogManager.CloseDialog();
	}

	public void EndDialog()
	{
		_dialogManager.EndDialog();
	}
	
    #endregion

	#region SceneManager

	public void NavigateToGameState(GameState gameState)
    {
        _sceneManager.NavigateToGameState(gameState);
    }

    public void NavigateToScene(string scenePath)
    {
        _sceneManager.NavigateToScene(scenePath);
    }

    #endregion

    #region PlayerManager

    public List<ItemBase> GetItems()
    {
        if (_debugManager.IsDebugEnabled())
        {
            return _debugManager.GetDebugItems();
        }
        else
        {
            return _playerManager.GetItems();
        }

    }

    public void SetItems(List<ItemBase> items)
    {
        _playerManager.SetItems(items);
    }

    public List<SkillBase> GetSkills()
    {
        return _playerManager.GetSkills();
    }

    public void SetSkills(List<SkillBase> skills)
    {
        _playerManager.SetSkills(skills);
    }

    public List<PlayerBase> GetPlayers()
    {
        return _playerManager.GetPlayers();
    }

    public void SetPlayers(List<PlayerBase> players)
    {
        _playerManager.SetPlayers(players);
    }

    #endregion

    #region SoundManager

    public void PlaySound(SoundEffects soundEffectToPlay)
    {
        _soundManager.PlaySound(soundEffectToPlay);
    }

    #endregion

    #region MusicManager

    #endregion

    #region BattleManager

    public void BuildBattle(List<PlayerBase> playerParty, List<PlayerBase> enemyParty)
    {
        _battleManager.BuildBattle(playerParty, enemyParty);
    }

    public void BuildBattle(PartyData playerParty, PartyData enemyParty)
    {
        _battleManager.BuildBattle(playerParty, enemyParty);
    }

    public void EndBattle()
    {
        _battleManager.EndBattle();
    }

    #endregion

    #region DebugManager 
    public List<PlayerBase> GetDebugPlayers()
    {
        return _debugManager.GetDebugPlayers();
    }

    public List<PlayerBase> GetDebugEnemies()
    {
        return _debugManager.GetDebugEnemies();
    }

    public List<ItemBase> GetDebugItems()
    {
        return _debugManager.GetDebugItems();
    }

    public bool IsDebugEnabled()
    {
        return _debugManager.IsDebugEnabled();
    }
    #endregion

}
