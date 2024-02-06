using Godot;
using System;
using System.Collections.Generic;
using System.Diagnostics;

public partial class BattleItemMenu : CanvasLayer
{
	/// <summary>
	/// 
	/// </summary>
	private ItemList _itemList;
	/// <summary>
	/// 
	/// </summary>
	private List<ItemDataBase> _items;
	/// <summary>
	/// 
	/// </summary>
	public event EventHandler<ItemDataBase> SelectedItemEVT;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		_itemList = GetNode<ItemList>("Panel/ItemList");
		_itemList.ItemClicked += _itemList_ItemClicked;

		//LoadItems(new List<ItemDataBase> { new ItemDataBase("1", "DESC 1", ResourceLoader.Load<Texture2D>("res://Assets/test images/1.png")), new ItemDataBase("2", "DESC 2", ResourceLoader.Load<Texture2D>("res://Assets/test images/2.png")) });

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
		_items = items;
	}
}
