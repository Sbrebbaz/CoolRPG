using Godot;
using Godot.Collections;
using System;

public partial class DialogBase : Resource
{
	[Export] public Array<DialogLineBase> DialogLines { get; set; }
}
