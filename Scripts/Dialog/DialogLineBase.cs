using Godot;
using System;

public partial class DialogLineBase : Resource
{
	[Export] public string Title { get; set; } = string.Empty;
	[Export] public string Text { get; set; } = string.Empty;
	[Export] public Sprite2D Sprite { get; set; }
}
