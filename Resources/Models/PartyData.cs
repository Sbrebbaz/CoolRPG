using Godot;
using Godot.Collections;

namespace CoolRPG.Scripts
{
	public partial class PartyData : Resource
	{
		[Export] public Array<PlayerBase> Players { get; set; }
		[Export] public InventoryData Inventory { get; set; }
	}
}
