using Godot;
using static Enumerators;

[GlobalClass]
public partial class SkillBase : Resource
{
	[Export] public string SkillName { get; set; } = string.Empty;
	[Export] public string Description { get; set; } = string.Empty;
	[Export] public int Value { get; set; }
	[Export(PropertyHint.Flags)] public Element Type { get; set; }
}
