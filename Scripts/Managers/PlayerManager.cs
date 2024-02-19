using Godot;
using System;
using System.Collections.Generic;
using static Flags;

public partial class PlayerManager : Node, IPlayerManager
{
	private List<ItemBase> _items = new List<ItemBase>();
	public List<ItemBase> GetItems()
	{
		return _items;
	}
	public void SetItems(List<ItemBase> items)
	{
		_items = items;	
	}

	private List<SkillBase> _skills = new List<SkillBase>();
	public List<SkillBase> GetSkills()
	{
		return _skills;
	}
	public void SetSkills(List<SkillBase> skills)
	{
		_skills = skills;
	}

	private List<PlayerBase> _players = new List<PlayerBase>();
	public List<PlayerBase> GetPlayers()
	{
		return _players;
	}

	public void SetPlayers(List<PlayerBase> players)
	{
		_players = players;
	}

	public override void _Ready()
	{
		_items = new List<ItemBase>();
		_skills = new List<SkillBase>();
	}


}