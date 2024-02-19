using Godot;
using System.Collections.Generic;

public interface IBattleManager
{
	public void BuildBattle(List<PlayerBase> playerParty, List<PlayerBase> enemyParty);
	public void BuildBattle(PartyData playerParty, PartyData enemyParty);
	public void EndBattle();
}