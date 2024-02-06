using Godot;
using System;
using System.Collections.Generic;

public partial class BattleAttackMenu : CanvasLayer
{
	/// <summary>
	/// 
	/// </summary>
	private ItemList _itemList;
	/// <summary>
	/// 
	/// </summary>
	private List<SkillBase> _skills;
	/// <summary>
	/// 
	/// </summary>
	public event EventHandler<SkillBase> SelectedSkillEVT;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		_itemList = GetNode<ItemList>("Panel/ItemList");
		_itemList.ItemClicked += _itemList_ItemClicked;

		LoadSkills(new List<SkillBase> {
			new SkillBase("SKILL TEST 1", Enumerators.Element.Bland, "DESC SKILL 1", ResourceLoader.Load<Texture2D>("res://Assets/test images/1.png")),
			new SkillBase("SKILL TEST 2", Enumerators.Element.Salty, "DESC SKILL 2", ResourceLoader.Load<Texture2D>("res://Assets/test images/2.png")),
			new SkillBase("SKILL TEST 3", Enumerators.Element.Umami, "DESC SKILL 3", ResourceLoader.Load<Texture2D>("res://Assets/test images/3.png")),
			new SkillBase("SKILL TEST 4", Enumerators.Element.Sweet, "DESC SKILL 4", ResourceLoader.Load<Texture2D>("res://Assets/test images/4.png")),
			new SkillBase("SKILL TEST 5", Enumerators.Element.Bitter, "DESC SKILL 5", ResourceLoader.Load<Texture2D>("res://Assets/test images/5.png"))
			});

	}
	/// <summary>
	/// 
	/// </summary>
	/// <param name="index"></param>
	/// <param name="atPosition"></param>
	/// <param name="mouseButtonIndex"></param>
	private void _itemList_ItemClicked(long index, Vector2 atPosition, long mouseButtonIndex)
	{
		SelectedSkillEVT?.Invoke(this, _skills[(int)index]);
	}
	/// <summary>
	/// 
	/// </summary>
	/// <param name="items"></param>
	public void LoadSkills(List<SkillBase> skills)
	{
		int index = 0;
		_itemList.Clear();
		foreach (SkillBase skill in skills)
		{
			_itemList.AddItem($"[{skill.Element}] {skill.SkillName}", (Texture2D)skill.Sprite);
			_itemList.SetItemTooltip(index, skill.Description);
			index++;
		}
		_skills = skills;
	}
}
