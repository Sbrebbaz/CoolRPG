using Godot;
using System;
using System.Diagnostics;

public partial class BaseEnemy : CharacterBody2D
{
	public const float speed = 100.0f;
	public AnimatedSprite2D AnimatedSprite2D {get; set;}
	private Vector2 StartPos;
	public override void _Ready()
	{
		StartPos = Position;
		Velocity = Vector2.Left * speed;
		GD.Print(StartPos);
		AnimatedSprite2D = GetNode<AnimatedSprite2D>("AnimatedSprite2D");
		base._Ready();
	}

	public override void _PhysicsProcess(double delta)
	{
		Vector2 velocity = Velocity;
		RandomNumberGenerator rand = new RandomNumberGenerator();
		if(Position.DistanceTo(StartPos) > 100 || GetSlideCollisionCount() != 0)
		{
			velocity = (StartPos - Position + new Vector2(rand.RandfRange(-50, 50), rand.RandfRange(-50, 50))).Normalized() * speed;
		}
		ManageMovementAnimation();

		Velocity = velocity;

		// if(GetSlideCollisionCount() != 0)
		// {
		// 	GD.Print("I HIT SOMETHING");
		// 	Velocity = Vector2.Right;
		// }
		MoveAndSlide();

		base._PhysicsProcess(delta);
	}

	private void ManageMovementAnimation()
	{
		if(Velocity.Abs().X > Velocity.Abs().Y)
		{
			AnimatedSprite2D.Play(Velocity.X > 0? "walk_right" : "walk_left");
		}
		else if(Velocity.Abs().X < Velocity.Abs().Y)
		{
			AnimatedSprite2D.Play(Velocity.Y > 0? "walk_down" : "walk_up");
		}
		else
		{
			AnimatedSprite2D.Play("idle");
		}
	}
}
