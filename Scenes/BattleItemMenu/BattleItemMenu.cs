using Godot;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;

public partial class BattleItemMenu : CanvasLayer
{
	private GameManager _gameManager;
	/// <summary>
	/// 
	/// </summary>
	private ItemList _itemList;
	/// <summary>
	/// 
	/// </summary>
	private List<ItemBase> _items;
	/// <summary>
	/// 
	/// </summary>
	public event EventHandler<ItemBase> SelectedItemEVT;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		_itemList = GetNode<ItemList>("Panel/ItemList");
		_itemList.ItemClicked += _itemList_ItemClicked;

		_gameManager = GetNode<GameManager>("/root/GameManager");

		LoadItems(_gameManager.GetItems());
	}
	/// <summary>
	/// 
	/// </summary>
	/// <param name="items"></param>
	public void LoadItems(List<ItemBase> items)
	{
		int index = 0;
		_itemList.Clear();
		foreach (ItemBase item in items)
		{
			_itemList.AddItem(item.ItemName, (Texture2D)item.Sprite);
			_itemList.SetItemTooltip(index, item.Description);
			index++;
		}
		_items = items;
	}
	/// <summary>
	/// 
	/// </summary>
	/// <param name="index"></param>
	/// <param name="atPosition"></param>
	/// <param name="mouseButtonIndex"></param>
	private void _itemList_ItemClicked(long index, Vector2 atPosition, long mouseButtonIndex)
	{
		SelectedItemEVT?.Invoke(this, _items[(int)index]);
	}
	/// <summary>
	/// 
	/// </summary>
	private void _on_item_list_visibility_changed()
	{
		if (_itemList != null &&_itemList.Visible)
		{
			_itemList.GrabFocus();
		}
	}
}
