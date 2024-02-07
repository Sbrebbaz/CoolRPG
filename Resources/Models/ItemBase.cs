using Godot;

[GlobalClass]
public partial class ItemBase : Resource
{
	[Export] public string ItemName { get; set; } = string.Empty;
	[Export] public string Description { get; set; } = string.Empty;
	[Export] public Texture Sprite { get; set; }

	public ItemBase() { }

	public ItemBase(string itemName, Texture sprite)
	{
		ItemName = itemName;
		Sprite = sprite;
	}

	public ItemBase(string itemName, string description, Texture sprite)
	{
		ItemName = itemName;
		Description = description;
		Sprite = sprite;
	}
}
