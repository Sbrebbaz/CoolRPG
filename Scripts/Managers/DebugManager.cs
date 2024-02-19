
using Godot;
using System.Collections.Generic;
using System.Linq;

public partial class DebugManager : Node, IDebugManager
{
    private DebugBase _debugBase;
    public List<PlayerBase> GetDebugPlayers()
    {
        return _debugBase.DebugPlayers.ToList();
    }
    public List<PlayerBase> GetDebugEnemies()
    {
        return _debugBase.DebugEnemies.ToList();
    }
    public List<ItemBase> GetDebugItems()
    {
        return _debugBase.DebugInventory.ToList();
    }
    public bool IsDebugEnabled()
    {
        return _debugBase.IsDebug;
    }

    public override void _Ready()
    {
        _debugBase = ResourceLoader.Load<DebugBase>("res://Resources/Instances/DebugData.tres");
    }

}

