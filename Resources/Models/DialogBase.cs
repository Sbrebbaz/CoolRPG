using Godot;
using Godot.Collections;
using System;

[GlobalClass]
public partial class DialogBase : Resource
{
	[Export] public Array<DialogLineBase> DialogLines { get; set; }
	private int _dialogLineIndex = 0;

	public event EventHandler<DialogLineBase> DialogLineChanged;
	public event EventHandler DialogEnded;

	public DialogBase()
	{
		DialogLines = new Array<DialogLineBase>();
	}

	public void ResetDialog()
	{
		_dialogLineIndex = 0;
	}

	public int GetNextIndex()
	{
		_dialogLineIndex++;
		if (_dialogLineIndex >= DialogLines.Count)
		{
			_dialogLineIndex = -1;
			DialogEnded?.Invoke(this, EventArgs.Empty);
		}
		else
		{
			DialogLineChanged?.Invoke(this, GetCurrentLine());
		}
		return _dialogLineIndex;
	}

	public DialogLineBase GetCurrentLine()
	{
		return DialogLines[_dialogLineIndex];
	}

	public DialogLineBase GetNextLine()
	{
		int nextIndex = GetNextIndex();
		if (nextIndex > 0)
		{
			return DialogLines[nextIndex];
		}
		else
		{
			return null;
		}
	}

}
