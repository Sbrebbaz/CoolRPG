using System.Collections.Generic;

public interface IPlayerManager
{
	public List<ItemBase> GetItems();
	public List<SkillBase> GetSkills();
}