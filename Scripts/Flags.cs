using Godot;
using System;

public partial class Flags : Node
{
	[Flags]
	public enum Element
	{
		Bland = 1,
		Salty = 2,
		Sour = 4,
		Sweet = 8,
		Bitter = 16,
		Umami = 32,
	}
}