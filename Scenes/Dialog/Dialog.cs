using Godot;
using System;

public partial class Dialog : CanvasLayer
{
	private Label _title;
	private RichTextLabel _message;
	private Sprite2D _sprite;

	public void SetDialog(DialogLineBase dialogLine)
	{
		_title = GetNode<Label>("Panel/TitleLabel");
		_message = GetNode<RichTextLabel>("Panel/TextLabel");
		_sprite = GetNode<Sprite2D>("Panel/Sprite");

		_title.Text = dialogLine.Title;
		_title.AddThemeFontOverride("font", dialogLine.Font);
		_title.AddThemeFontSizeOverride("font_size", dialogLine.FontSize);

		_message.Text = dialogLine.Text;
		_message.AddThemeFontOverride("normal_font", dialogLine.Font);
		_message.AddThemeFontSizeOverride("normal_font_size", dialogLine.TitleFontSize);

		_sprite.Texture = (Texture2D)dialogLine.Sprite;
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
