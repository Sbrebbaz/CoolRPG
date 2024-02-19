using Godot;
using System;
using System.Collections.Generic;

public partial class BattlePlayerMenu : CanvasLayer
{
	/// <summary>
	/// 
	/// </summary>
	private GameManager _gameManager;
	/// <summary>
	/// 
	/// </summary>
	private ItemList _itemList;
	/// <summary>
	/// 
	/// </summary>
	private List<PlayerBase> _players;
	/// <summary>
	/// 
	/// </summary>
	public event EventHandler<PlayerBase> SelectedPlayerEVT;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		_itemList = GetNode<ItemList>("Panel/ItemList");
		_itemList.ItemClicked += _itemList_ItemClicked;
	}
	/// <summary>
	/// 
	/// </summary>
	/// <param name="items"></param>
	public void LoadSkills(List<PlayerBase> players)
	{
		int index = 0;
		_itemList.Clear();
		foreach (PlayerBase player in players)
		{
			_itemList.AddItem($"{player.CharacterName}", (Texture2D)player.PlayerIcon);
			_itemList.SetItemTooltip(index, player.CharacterName);
			index++;
		}
		_players =players;
	}
	/// <summary>
	/// 
	/// </summary>
	/// <param name="index"></param>
	/// <param name="atPosition"></param>
	/// <param name="mouseButtonIndex"></param>
	private void _itemList_ItemClicked(long index, Vector2 atPosition, long mouseButtonIndex)
	{
		SelectedPlayerEVT?.Invoke(this, _players[(int)index]);
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
