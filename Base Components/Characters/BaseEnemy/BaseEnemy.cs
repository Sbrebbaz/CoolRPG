using Godot;
using System;
using System.Diagnostics;

public partial class BaseEnemy : CharacterBody2D
{
	[Export] public float PlayerDetectionArea = 200.0f;
	[Export] public float RoamingArea = 100.0f;
	[Export] public float Speed = 100.0f;
	[Export] public SpriteFrames enemySprite { get; set; }

	public BasePlayer PlayerDetected;
	public Vector2 StartingPosition;

	private AnimatedSprite2D _AnimatedSprite2D;
	private RandomNumberGenerator _RNG;

	public override void _Ready()
	{
		_RNG = new RandomNumberGenerator();

		StartingPosition = Position;

		Debug.WriteLine(StartingPosition);

		_AnimatedSprite2D = GetNode<AnimatedSprite2D>("AnimatedSprite2D");
		_AnimatedSprite2D.SpriteFrames = enemySprite;
		_AnimatedSprite2D.Play("idle");
		Velocity = Vector2.Left * Speed;


		((CircleShape2D)GetNode<Area2D>("Area2D").GetNode<CollisionShape2D>("CollisionShape2D").Shape).Radius = PlayerDetectionArea;

		base._Ready();
	}

	public override void _PhysicsProcess(double delta)
	{
		Vector2 direction = new Vector2();

		if (PlayerDetected != null)
		{
			direction = (PlayerDetected.Position - Position).Normalized();
		}
		else
		{
			if (StartingPosition == Position
				|| Position.DistanceTo(StartingPosition) > RoamingArea
				|| GetSlideCollisionCount() > 0)
			{
				Vector2 newDirection = new Vector2(_RNG.RandfRange(0, RoamingArea) - RoamingArea / 2, _RNG.RandfRange(0, RoamingArea) - RoamingArea / 2);

				direction = (Position - StartingPosition + newDirection).Normalized();
			}
		}
		ManageMovementAnimation();

		Velocity = direction * Speed;

		MoveAndSlide();

		base._PhysicsProcess(delta);
	}

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

	private void _on_player_detection_body_entered(Node2D body)
	{
		if (body is BasePlayer)
		{
			PlayerDetected = (BasePlayer)body;
		}
	}

	private void _on_player_detection_body_exited(Node2D body)
	{
		if (body is BasePlayer)
		{
			PlayerDetected = null;
		}
	}
}
