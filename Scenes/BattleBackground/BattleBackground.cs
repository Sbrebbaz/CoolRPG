using Godot;
using System;
using System.Collections.Generic;

public partial class BattleBackground : CanvasLayer
{
	private GameManager _gameManager;
	private HBoxContainer _enemiesContainer;
	private HBoxContainer _playersContainer;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		_gameManager = GetNode<GameManager>("/root/GameManager");

		_enemiesContainer = GetNode<HBoxContainer>("BattleContainer/EnemiesContainer");
		_playersContainer = GetNode<HBoxContainer>("BattleContainer/PlayersContainer");

		BuildPlayerImages(_gameManager.GetDebugPlayers(), _gameManager.GetDebugEnemies());
	}

	public void BuildPlayerImages(List<PlayerBase> players, List<PlayerBase> enemies)
	{
		_createPlayerImages(_playersContainer, players);
		_createPlayerImages(_enemiesContainer, enemies);
	}

	private void _createPlayerImages(HBoxContainer container, List<PlayerBase> playersToAdd)
	{
		foreach (Node child in container.GetChildren())
		{
			container.RemoveChild(child);
			child.QueueFree();
		}

		foreach (PlayerBase player in playersToAdd)
		{
			TextureRect playerTexture = new TextureRect();
			playerTexture.Texture = (Texture2D)player.PlayerBattleSprite;
			playerTexture.ExpandMode = TextureRect.ExpandModeEnum.FitWidthProportional;
			playerTexture.StretchMode = TextureRect.StretchModeEnum.KeepAspectCentered;
			playerTexture.CustomMinimumSize = new Vector2(200, 200);
			//playerTexture.SizeFlagsStretchRatio = Control.SizeFlags.Expand;

			container.AddChild(playerTexture);
		}
	}

}
