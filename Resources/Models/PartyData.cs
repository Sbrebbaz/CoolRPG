using Godot;
using Godot.Collections;

[GlobalClass]
public partial class PartyData : Resource
{
	[Export] public Array<PlayerBase> Players { get; set; }
	[Export] public InventoryData Inventory { get; set; }
}
