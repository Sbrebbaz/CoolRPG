using Godot;
using Godot.Collections;
using static Flags;

[GlobalClass]
public partial class PlayerBase : Resource
{
	[Export] public string CharacterName { get; set; } = string.Empty;
	[ExportCategory("Stats")]
	[Export] public int Health { get; set; } = 100;
	[Export] public int CurrentHealth { get; set; } = 100;
	[Export] public float Speed { get; set; } = 300f;
	[Export] public float RunningMultiplier { get; set; } = 1.5f;
	[Export] public int Mana { get; set; } = 10;
	[Export] public int CurrentMana { get; set; } = 10;
	[Export] public int Attack { get; set; } = 10;
	[Export] public int Defense { get; set; } = 10;
	[Export(PropertyHint.Flags)] public Element Type { get; set; } = Element.Bland;
	[Export] public Array<SkillBase> Skills { get; set; }

}
