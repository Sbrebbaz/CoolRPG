using Godot;
using Godot.Collections;
using static Flags;

[GlobalClass]
public partial class EnemyBase : Resource
{
	[Export] public float BaseSpeed = 300f;
	[Export] public float RoamingArea = 100f;
	[Export] public float PlayerDetectionArea = 200f;
	[Export] public float PlayerHitArea = 32f;
	[Export] public PartyData EnemyParty { get; set; }



	[Signal] public delegate void PlayerHitDetectionEventHandler();
	[Signal] public delegate void PlayerCloseDetectionEventHandler();
}
