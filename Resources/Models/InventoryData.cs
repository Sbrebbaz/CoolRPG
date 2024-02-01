using Godot.Collections;
using Godot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoolRPG.Scripts
{
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
}
