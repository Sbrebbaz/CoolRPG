using Godot;
using System;
using System.Collections.Generic;
using static Flags;

public partial class PlayerManager : Node, IPlayerManager
{
	private List<ItemDataBase> _items = new List<ItemDataBase>();
	public List<ItemDataBase> GetItems()
	{
		return _items;
	}

	private List<SkillBase> _skills = new List<SkillBase>();
	public List<SkillBase> GetSkills()
	{
		return _skills;
	}

	public override void _Ready()
	{
		_items = new List<ItemDataBase>();
		_skills = new List<SkillBase>();

		_items.Add(new ItemDataBase("1", "DESC 1", ResourceLoader.Load<Texture2D>("res://Assets/test images/1.png")));
		_items.Add(new ItemDataBase("2", "DESC 2", ResourceLoader.Load<Texture2D>("res://Assets/test images/2.png")));
		_items.Add(new ItemDataBase("3", "DESC 3", ResourceLoader.Load<Texture2D>("res://Assets/test images/3.png")));
		_items.Add(new ItemDataBase("4", "DESC 4", ResourceLoader.Load<Texture2D>("res://Assets/test images/4.png")));
		_items.Add(new ItemDataBase("5", "DESC 5", ResourceLoader.Load<Texture2D>("res://Assets/test images/5.png")));
		_items.Add(new ItemDataBase("6", "DESC 6", ResourceLoader.Load<Texture2D>("res://Assets/test images/1.png")));
		_items.Add(new ItemDataBase("7", "DESC 7", ResourceLoader.Load<Texture2D>("res://Assets/test images/2.png")));
		_items.Add(new ItemDataBase("8", "DESC 8", ResourceLoader.Load<Texture2D>("res://Assets/test images/3.png")));
		_items.Add(new ItemDataBase("9", "DESC 9", ResourceLoader.Load<Texture2D>("res://Assets/test images/4.png")));
		_items.Add(new ItemDataBase("0", "DESC 0", ResourceLoader.Load<Texture2D>("res://Assets/test images/5.png")));

		_skills.Add(new SkillBase("1", Element.Bland, "DESC 1", ResourceLoader.Load<Texture2D>("res://Assets/test images/1.png")));
		_skills.Add(new SkillBase("2", Element.Salty, "DESC 2", ResourceLoader.Load<Texture2D>("res://Assets/test images/2.png")));
		_skills.Add(new SkillBase("3", Element.Bitter, "DESC 3", ResourceLoader.Load<Texture2D>("res://Assets/test images/3.png")));
		_skills.Add(new SkillBase("4", Element.Sour, "DESC 4", ResourceLoader.Load<Texture2D>("res://Assets/test images/4.png")));
		_skills.Add(new SkillBase("5", Element.Umami, "DESC 5", ResourceLoader.Load<Texture2D>("res://Assets/test images/5.png")));
		_skills.Add(new SkillBase("6", Element.Sweet, "DESC 6", ResourceLoader.Load<Texture2D>("res://Assets/test images/1.png")));
		_skills.Add(new SkillBase("7", Element.Sour, "DESC 7", ResourceLoader.Load<Texture2D>("res://Assets/test images/2.png")));
		_skills.Add(new SkillBase("8", Element.Bitter, "DESC 8", ResourceLoader.Load<Texture2D>("res://Assets/test images/3.png")));
		_skills.Add(new SkillBase("9", Element.Bland, "DESC 9", ResourceLoader.Load<Texture2D>("res://Assets/test images/4.png")));
		_skills.Add(new SkillBase("0", Element.Bitter, "DESC 0", ResourceLoader.Load<Texture2D>("res://Assets/test images/5.png")));
	}


}