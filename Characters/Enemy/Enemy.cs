using Godot;
using System;
using System.Diagnostics;

public partial class Enemy : CharacterBody2D
{
	[Export] public float BaseSpeed = 300f;
	[Export] public float RoamingArea = 100f;
	[Export] public float PlayerDetectionArea = 200f;
	[Export] public float PlayerHitArea = 32f;

	[Signal] public delegate void PlayerHitDetectionEventHandler();
	[Signal] public delegate void PlayerCloseDetectionEventHandler();

	public Player PlayerDetected;
	public Vector2 StartingPosition;

	private AnimatedSprite2D _AnimatedSprite2D;
	private RandomNumberGenerator _RNG;

	public override void _Ready()
	{
		_RNG = new RandomNumberGenerator();

		StartingPosition = Position;

		Debug.WriteLine(StartingPosition);

		_AnimatedSprite2D = GetNode<AnimatedSprite2D>("AnimatedSprite2D");
		_AnimatedSprite2D.Play("idle");
		Velocity = Vector2.Left * BaseSpeed;

		((CircleShape2D)GetNode<Area2D>("PlayerDetection").GetNode<CollisionShape2D>("PlayerDetectionArea").Shape).Radius = PlayerDetectionArea;
		((CircleShape2D)GetNode<Area2D>("HitDetection").GetNode<CollisionShape2D>("HitDetectionArea").Shape).Radius = PlayerHitArea;

		base._Ready();
	}

	public override void _PhysicsProcess(double delta)
	{
		//Retrieve current direction
		Vector2 direction = Velocity / BaseSpeed;

		//Player detected
		//Move towards player
		if (PlayerDetected != null)
		{
			direction = (PlayerDetected.Position - Position).Normalized();
		}
		//Player not detected
		//Roam around
		else
		{
			if (Position.DistanceTo(StartingPosition) < 1
				|| Position.DistanceTo(StartingPosition) > RoamingArea
				|| GetSlideCollisionCount() > 0)
			{
				Vector2 newDirection = new Vector2(
					_RNG.RandfRange(0, RoamingArea) - RoamingArea / 2,
					_RNG.RandfRange(0, RoamingArea) - RoamingArea / 2);

				direction = (StartingPosition - Position + newDirection).Normalized();
			}
		}

		//Manage animations
		ManageMovementAnimation();

		//New direction and move management
		Velocity = direction * BaseSpeed;
		MoveAndSlide();
		base._PhysicsProcess(delta);
	}

	/// <summary>
	/// Method that manages the base movement animation
	/// </summary>
	private void ManageMovementAnimation()
	{
		if (Velocity.Abs().X > Velocity.Abs().Y)
		{
			_AnimatedSprite2D.Play(Velocity.X > 0 ? "walk_right" : "walk_left");
		}
		else if (Velocity.Abs().X < Velocity.Abs().Y)
		{
			_AnimatedSprite2D.Play(Velocity.Y > 0 ? "walk_down" : "walk_up");
		}
		else
		{
			_AnimatedSprite2D.Play("idle");
		}
	}

	/// <summary>
	/// Event handler for player detection area enter
	/// Player enter the Area and assign local variable
	/// </summary>
	/// <param name="body">Body that entered the area</param>
	private void _on_player_detection_body_entered(Node2D body)
	{
		if (body is Player)
		{
			PlayerDetected = (Player)body;
			EmitSignal(SignalName.PlayerCloseDetection);
		}
	}

	/// <summary>
	/// Event handler for player detection area exit
	/// Player exit the Area and reset local variable
	/// </summary>
	/// <param name="body">Body that exited the area</param>
	private void _on_player_detection_body_exited(Node2D body)
	{
		if (body is Player)
		{
			PlayerDetected = null;
		}
	}

	/// <summary>
	/// Event handler for player detection hit area enter
	/// Player enter the hit Area and raises the signal
	/// </summary>
	/// <param name="body">Body that entered the area</param>
	private void _on_hit_detection_body_entered(Node2D body)
	{
		EmitSignal(SignalName.PlayerHitDetection);
	}
}
