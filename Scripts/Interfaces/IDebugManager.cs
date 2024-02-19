using System;
using System.Collections.Generic;

public interface IDebugManager
{
    public List<PlayerBase> GetDebugPlayers();
    public List<PlayerBase> GetDebugEnemies();
    public List<ItemBase> GetDebugItems();
        public bool IsDebugEnabled();
}

