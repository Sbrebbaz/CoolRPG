using Godot;
using System;
using System.Threading;

public partial class DialogManager : Node, IDialogManager
{
	private Dialog _dialog;
	private Camera2D _currentCamera;
	private DialogBase _currentDialog = null;

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
		CloseDialog();
		_dialog = ResourceLoader.Load<PackedScene>("res://Scenes/Dialog/Dialog.tscn").Instantiate<Dialog>();
		_dialog.SetDialog(dialogLineData);
		_currentCamera.AddChild(_dialog);
		_dialog.TreeExited += _dialog_TreeExited;
	}

	public void CloseDialog()
	{
		if (_dialog != null && IsInstanceValid(_dialog))
		{
			_dialog.QueueFree();
		}
	}

	public void EndDialog()
	{
		if (_dialog != null && IsInstanceValid(_dialog))
		{
			_dialog.TreeExited -= _dialog_TreeExited;
			_currentDialog.ForceEndDialog();
			CloseDialog();
		}
	}
}
