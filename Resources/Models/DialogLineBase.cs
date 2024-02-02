using Godot;
using System;
using System.ComponentModel;

[GlobalClass]
public partial class DialogLineBase : Resource
{
	[Export] public string Title { get; set; } = string.Empty;
	[Export] public string Text { get; set; } = string.Empty;
	[Export] public Texture Sprite { get; set; }

	public DialogLineBase() { }

	public DialogLineBase(string title, string text)
	{
		Title = title;
		Text = text;
	}

	public DialogLineBase(string title, string text, Texture texture)
	{
		Title = title;
		Text = text;
		Sprite = texture;
	}

}
