using Godot;
using static Flags;

[GlobalClass]
public partial class SkillBase : Resource
{
	[Export] public string SkillName { get; set; } = string.Empty;
	[Export] public string Description { get; set; } = string.Empty;
	[Export(PropertyHint.Flags)] public Element Element { get; set; }
	[Export] public Texture Sprite { get; set; }

	public SkillBase() { }

	public SkillBase(string skillName, Element element, string description, Texture sprite)
	{
		SkillName = skillName;
		Description = description;
		Element = element;
		Sprite = sprite;
	}
}
