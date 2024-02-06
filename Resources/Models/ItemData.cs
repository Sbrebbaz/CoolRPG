using Godot;

[GlobalClass]
public partial class ItemDataBase : Resource
{
	[Export] public string ItemName { get; set; } = string.Empty;
	[Export] public string Description { get; set; } = string.Empty;
	[Export] public Texture Sprite { get; set; }

	public ItemDataBase() { }

	public ItemDataBase(string itemName, Texture sprite)
	{
		ItemName = itemName;
		Sprite = sprite;
	}

	public ItemDataBase(string itemName, string description, Texture sprite)
	{
		ItemName = itemName;
		Description = description;
		Sprite = sprite;
	}
}
