using Godot;
using System;
using System.Collections.Generic;

public partial class BattleItemMenu : CanvasLayer
{
	private ItemList _itemList;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		_itemList = GetNode<ItemList>("Panel/ItemList");
	}
	/// <summary>
	/// 
	/// </summary>
	/// <param name="items"></param>
	public void LoadItems(List<ItemDataBase> items)
	{
		int index = 0;
		_itemList.Clear();
		foreach (ItemDataBase item in items)
		{
			_itemList.AddItem(item.ItemName, (Texture2D)item.Sprite);
			_itemList.SetItemTooltip(index, item.Description);
			index++;
		}
	}
}
