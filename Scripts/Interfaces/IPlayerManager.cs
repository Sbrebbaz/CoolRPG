using System.Collections.Generic;

public interface IPlayerManager
{
	public List<ItemBase> GetItems();
	public void SetItems(List<ItemBase> items);
	public List<SkillBase> GetSkills();
	public void SetSkills(List<SkillBase> skills);
	public List<PlayerBase> GetPlayers();
	public void SetPlayers(List<PlayerBase> players);
}