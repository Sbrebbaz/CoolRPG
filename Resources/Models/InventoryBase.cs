using Godot.Collections;
using Godot;

[GlobalClass]
public partial class InventoryBase : Resource
{
    [Export] public Array<ItemBase> Inventory { get; set; }


}
