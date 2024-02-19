using Godot;
using static Enumerators;

public partial class Battle : Node2D
{
	private BattleMenuSelection _currentBattleMenuSelection = BattleMenuSelection.Idle;

	private BattleMenu BattleMenu;
	private BattleItemMenu BattleItemMenu;
	private BattleAttackMenu BattleAttackMenu;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		BattleMenu = GetNode<BattleMenu>("BattleMenu");

		BattleItemMenu = GetNode<BattleItemMenu>("BattleItemMenu");
		BattleItemMenu.Visible = false;

		BattleAttackMenu = GetNode<BattleAttackMenu>("BattleAttackMenu");
		BattleAttackMenu.Visible = false;

		BattleMenu.BattleMenuConfirmEVT += BattleMenu_BattleMenuConfirmEVT;
	}

	private void BattleMenu_BattleMenuConfirmEVT(object sender, BattleMenuSelection e)
	{
		_currentBattleMenuSelection = e;
		switch (_currentBattleMenuSelection)
		{
			case BattleMenuSelection.Idle:
			case BattleMenuSelection.Examine:
			case BattleMenuSelection.Defend:
				{
					BattleItemMenu.Visible = false;
					BattleAttackMenu.Visible = false;
					break;
				}
			case BattleMenuSelection.Item:
				{
					BattleItemMenu.Visible = true;
					BattleAttackMenu.Visible = false;
					break;
				}
			case BattleMenuSelection.Attack:
				{
					BattleItemMenu.Visible = false;
					BattleAttackMenu.Visible = true;
					break;
				}
		}
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		if (Input.IsActionJustPressed("ui_cancel"))
		{
			BattleMenu.CancelSelection();
		}
	}
}
