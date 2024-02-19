using Godot;

[GlobalClass]
public partial class MovementBase : Resource
{
	[Export] public float Speed { get; set; } = 300f;
	[Export] public float RunningMultiplier { get; set; } = 1.5f;
}