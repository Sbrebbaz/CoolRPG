using Godot;
using System;
using static Enumerators;

public partial class BattleMenu : CanvasLayer
{
	private AnimatedSprite2D _sprite;
	private BattleMenuSelection _currentBattleMenu = BattleMenuSelection.Idle;
	public BattleMenuSelection CurrentBattleMenu
	{
		get { return _currentBattleMenu; }
		set
		{
			if (value != _currentBattleMenu)
			{
				_currentBattleMenu = value;
				UpdateUI();
			}
		}
	}
	private BattleMenuSelection _currentBattleMenuActive = BattleMenuSelection.Idle;

	public event EventHandler<BattleMenuSelection> BattleMenuConfirmEVT;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		_currentBattleMenuActive = BattleMenuSelection.Idle;
		_sprite = GetNode<AnimatedSprite2D>("MarginContainer/AnimatedSprite2D");
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		if (_currentBattleMenuActive == BattleMenuSelection.Idle)
		{
			if (Input.IsActionJustPressed("ui_up"))
			{
				CurrentBattleMenu = BattleMenuSelection.Item;
			}
			else if (Input.IsActionJustPressed("ui_down"))
			{
				CurrentBattleMenu = BattleMenuSelection.Examine;
			}
			else if (Input.IsActionJustPressed("ui_left"))
			{
				CurrentBattleMenu = BattleMenuSelection.Defend;
			}
			else if (Input.IsActionJustPressed("ui_right"))
			{
				CurrentBattleMenu = BattleMenuSelection.Attack;
			}
			else if (Input.IsActionJustPressed("ui_select"))
			{
				_currentBattleMenuActive = _currentBattleMenu;
				BattleMenuConfirmEVT?.Invoke(this, _currentBattleMenu);
			}
		}
	}

	public void CancelSelection()
	{
		_currentBattleMenuActive = BattleMenuSelection.Idle;
		CurrentBattleMenu = BattleMenuSelection.Idle;
		BattleMenuConfirmEVT?.Invoke(this, _currentBattleMenuActive);
	}

	private void UpdateUI()
	{
		switch (_currentBattleMenu)
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
