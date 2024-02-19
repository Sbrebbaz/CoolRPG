using Godot;
using System.Collections.Generic;
using System.Linq;

public partial class BattleManager : Node, IBattleManager
{
	public void BuildBattle(List<PlayerBase> playerParty, List<PlayerBase> enemyParty)
	{
		GD.PrintErr("BUILD BATTLE");
	}

	public void BuildBattle(PartyData playerParty, PartyData enemyParty)
	{
		BuildBattle(playerParty.Players.ToList(), enemyParty.Players.ToList());
	}

	public void EndBattle()
	{
		GD.PrintErr("END BATTLE");
	}
}