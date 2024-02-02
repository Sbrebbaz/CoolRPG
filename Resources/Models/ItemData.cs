using Godot;

[GlobalClass]
public partial class ItemDataBase : Resource
{
	[Export] public string ItemName { get; set; } = string.Empty;
	[Export] public string Description { get; set; } = string.Empty;
	[Export] public bool IsKey { get; set; } = false;
}
