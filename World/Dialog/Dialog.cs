using Godot;
using System;

public partial class Dialog : CanvasLayer
{
	private Label _title;
	private RichTextLabel _message;

	public void SetText(DialogLineBase dialogLine)
	{
		_title = GetNode<Label>("Panel/VBoxContainer/Label");
		_message = GetNode<RichTextLabel>("Panel/VBoxContainer/RichTextLabel");

		_title.Text = dialogLine.Title;
		_message.Text = dialogLine.Text;
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		if (Input.IsActionJustPressed("ui_accept"))
		{
			QueueFree();
		}
	}
}
