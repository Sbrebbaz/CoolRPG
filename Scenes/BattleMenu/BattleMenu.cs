using Godot;
using System;
using static Enumerators;

public partial class BattleMenu : CanvasLayer
{
	private AnimatedSprite2D _sprite;
	private BattleMenuSelection _currentBattleMenuSelection = BattleMenuSelection.Idle;
	public BattleMenuSelection CurrentBattleMenuSelection
	{
		get { return _currentBattleMenuSelection; }
		set
		{
			if (value != _currentBattleMenuSelection)
			{
				_currentBattleMenuSelection = value;
				UpdateUI();
			}
		}
	}

	public event EventHandler<BattleMenuSelection> BattleMenuConfirmEVT;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		_currentBattleMenuSelection = BattleMenuSelection.Idle;
		_sprite = GetNode<AnimatedSprite2D>("MarginContainer/AnimatedSprite2D");
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		if (Input.IsActionJustPressed("ui_up"))
		{
			CurrentBattleMenuSelection = BattleMenuSelection.Item;
		}
		else if (Input.IsActionJustPressed("ui_down"))
		{
			CurrentBattleMenuSelection = BattleMenuSelection.Examine;
		}
		else if (Input.IsActionJustPressed("ui_left"))
		{
			CurrentBattleMenuSelection = BattleMenuSelection.Defend;
		}
		else if (Input.IsActionJustPressed("ui_right"))
		{
			CurrentBattleMenuSelection = BattleMenuSelection.Attack;
		}
		else if (Input.IsActionJustPressed("ui_select"))
		{
			BattleMenuConfirmEVT?.Invoke(this, CurrentBattleMenuSelection);
		}
	}

	private void UpdateUI()
	{
		switch (_currentBattleMenuSelection)
		{
			case BattleMenuSelection.Idle:
				{
					_sprite.Animation = "idle";
					_sprite.Play("idle");
					break;
				}
			case BattleMenuSelection.Item:
				{
					_sprite.Animation = "top";
					_sprite.Play("top");
					break;
				}
			case BattleMenuSelection.Attack:
				{
					_sprite.Animation = "right";
					_sprite.Play("right");
					break;
				}
			case BattleMenuSelection.Examine:
				{
					_sprite.Animation = "bottom";
					_sprite.Play("bottom");
					break;
				}
			case BattleMenuSelection.Defend:
				{
					_sprite.Animation = "left";
					_sprite.Play("left");
					break;
				}
		}
	}

}
