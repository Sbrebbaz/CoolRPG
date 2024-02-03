using Godot;
using System;
using System.ComponentModel;

[GlobalClass]
public partial class DialogLineBase : Resource
{
	[Export] public DialogCharacterBase DialogBaseData { get; set; }
	[Export] public string Text { get; set; } = string.Empty;
	[Export] public int FontSize { get; set; } = 18;
	[Export] public bool UseCharacterFontColor { get; set; } = true;
	[Export] public Color FontColor { get; set; } = Colors.White;

	public string Title { get { return DialogBaseData.Title; } }
	public Texture Sprite { get { return DialogBaseData.Sprite; } }
	public Font Font { get { return DialogBaseData.Font; } }
	public int TitleFontSize { get { return DialogBaseData.FontSize; } }
	public Color TitleFontColor { get { return DialogBaseData.FontColor; } }

	public DialogLineBase() { }

	public DialogLineBase(string text, int fontSize, Color fontColor, DialogCharacterBase dialogBaseData)
	{
		Text = text;
		FontSize = fontSize;
		FontColor = fontColor;
		DialogBaseData = dialogBaseData;
	}

}
