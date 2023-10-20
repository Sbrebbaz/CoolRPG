using Godot;
using System;
using System.Diagnostics;

public partial class BaseDialog : RichTextLabel
{
	public string Dialog;
	private Stopwatch CharacterTimer = new Stopwatch();
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		CharacterTimer.Start();
		Dialog = Text;
		Text = "";
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		// if(Text != Dialog && CharacterTimer.Elapsed.Milliseconds > 10)
		// {
		// 	Text += Dialog[Text.Length];
		// 	CharacterTimer.Restart();
		// }

		if(Text != Dialog && CharacterTimer.Elapsed.Milliseconds > 100)
		{
			for(int i = Text.Length; Dialog[i] != ' '; i++)
			{
				Text += Dialog[i];
			}
			Text += ' ';
			CharacterTimer.Restart();
		}
	}
}
