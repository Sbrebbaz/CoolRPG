using Godot;
using System;

public partial class DialogLineBase : Resource
{
	[Export] public string Title { get; set; } = string.Empty;
	[Export] public string Text { get; set; } = string.Empty;

	public DialogLineBase()
	{

	}

	public DialogLineBase(string title, string text)
	{
		Title = title;
		Text = text;
	}

}
