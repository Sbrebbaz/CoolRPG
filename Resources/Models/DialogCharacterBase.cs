using Godot;
using System;
using static System.Net.Mime.MediaTypeNames;

[GlobalClass]
public partial class DialogCharacterBase : Resource
{
	[Export] public string Title { get; set; } = string.Empty;
	[Export] public Texture Sprite { get; set; }
	[Export] public Font Font { get; set; }
	[Export] public int FontSize { get; set; } = 20;
	[Export] public Color FontColor { get; set; } = Colors.White;

	public DialogCharacterBase() { }

	public DialogCharacterBase(string title, Texture texture, Font font, int fontSize, Color fontColor)
	{
		Title = title;
		Sprite = texture;
		Font = font;
		FontSize = fontSize;
		FontColor = fontColor;
	}
}
