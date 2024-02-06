using System.Collections.Generic;

public interface IPlayerManager
{
	public List<ItemDataBase> GetItems();
	public List<SkillBase> GetSkills();
}