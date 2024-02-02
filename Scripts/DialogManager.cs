using Godot;
using System;
using System.Threading;

public partial class DialogManager : Node
{
	private Dialog _dialog;
	private Camera2D _currentCamera;
	private DialogBase _currentDialog = null;

	public override void _Process(double delta)
	{
		if (Input.IsActionJustPressed("ui_text_delete"))
		{
			DialogBase dialog = new DialogBase();

			dialog.DialogLines.Add(new DialogLineBase("Painter beef", "Hello!"));
			dialog.DialogLines.Add(new DialogLineBase("Cool beef", "Ciao!"));
			dialog.DialogLines.Add(new DialogLineBase("Sbrebbaz", "Bonjour!"));

			ShowDialog(dialog);
		}
	}

	public void ShowDialog(DialogBase dialog)
	{
		_currentDialog = dialog;
		ShowDialog(_currentDialog.GetCurrentLine());
	}

	private void _dialog_TreeExited()
	{
		if (_currentDialog != null)
		{
			DialogLineBase nextLine = _currentDialog.GetNextLine();
			if (nextLine != null)
			{
				ShowDialog(nextLine);
			}
			else
			{
				_dialog.TreeExited -= _dialog_TreeExited;
				_currentDialog = null;
			}
		}
	}

	public void ShowDialog(DialogLineBase dialogLineData)
	{
		_currentCamera = GetViewport().GetCamera2D();
		if (_dialog != null)
		{
			_currentCamera.RemoveChild(_dialog);
		}
		_dialog = ResourceLoader.Load<PackedScene>("res://World/Dialog/Dialog.tscn").Instantiate<Dialog>();
		_dialog.SetText(dialogLineData);
		_currentCamera.AddChild(_dialog);
		_dialog.TreeExited += _dialog_TreeExited;
	}

}
