using Godot;
using System;
using System.ComponentModel;

[GlobalClass]
public partial class DialogLineBase : Resource
{
	[Export] public DialogCharacterBase DialogBaseData { get; set; }
	[Export] public string Text { get; set; } = string.Empty;
	[Export] public int FontSize { get; set; } = 18;

	public string Title { get { return DialogBaseData.Title; } }
	public Texture Sprite { get { return DialogBaseData.Sprite; } }
	public Font Font { get { return DialogBaseData.Font; } }
	public int TitleFontSize { get { return DialogBaseData.FontSize; } }

	public DialogLineBase() { }

	public DialogLineBase(string text, DialogCharacterBase dialogBaseData)
	{
		Text = text;
		DialogBaseData = dialogBaseData;
	}

}
