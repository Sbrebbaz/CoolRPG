using Godot;
using System;
using System.Collections.Generic;

public partial class BattleAttackMenu : CanvasLayer
{
	private GameManager _gameManager;
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

		_gameManager = GetNode<GameManager>("/root/GameManager");

		LoadSkills(_gameManager.GetSkills());
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
	private void _on_item_list_visibility_changed()
	{
		if (_itemList != null && _itemList.Visible)
		{
			_itemList.GrabFocus();
		}
	}
}
