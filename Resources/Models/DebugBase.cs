using Godot;
using Godot.Collections;


[GlobalClass] 
public partial class DebugBase : Resource
{

    [Export] public bool IsDebug = true;
    [Export] public Array<PlayerBase> DebugPlayers;
    [Export] public Array<PlayerBase> DebugEnemies;
    [Export] public Array<ItemBase> DebugInventory;



 
}
