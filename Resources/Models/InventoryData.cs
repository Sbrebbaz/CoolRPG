using Godot.Collections;
using Godot;
using System.Collections.Generic;
using System.Linq;

[GlobalClass]
public partial class InventoryData : Resource
{
	[Export] public Array<ItemDataBase> Items { get; set; }

	public List<ItemDataBase> Consumables
	{
		get { return Items.Where(item => !item.IsKey).ToList(); }
	}

	public List<ItemDataBase> KeyItems
	{
		get { return Items.Where(item => item.IsKey).ToList(); }
	}

}
