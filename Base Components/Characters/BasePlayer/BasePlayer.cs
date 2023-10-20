using Godot;
using System;
using System.Diagnostics;

public partial class BasePlayer : CharacterBody2D
{
	public const float BaseSpeed = 300.0f;
	public const float RunningMultiplier = 1.5f;
	public const float JumpVelocity = -400.0f;

	public AnimatedSprite2D AnimatedSprite2D { get; set; }

	public override void _Ready()
	{
		AnimatedSprite2D = GetNode<AnimatedSprite2D>("AnimatedSprite2D");
		base._Ready();
	}

	public override void _PhysicsProcess(double delta)
	{
		Vector2 velocity = Velocity;
		Vector2 direction = Input.GetVector("ui_left", "ui_right", "ui_up", "ui_down");
		float movementSpeed = BaseSpeed;
		AnimatedSprite2D.SpeedScale = 1f;

		if (Input.IsActionPressed("ui_run"))
		{
			movementSpeed *= RunningMultiplier;
			AnimatedSprite2D.SpeedScale *= RunningMultiplier;
		}

		ManageMovementAnimation(direction);
		Console.WriteLine(direction);

		if (direction != Vector2.Zero)
		{
			velocity.X = direction.X * movementSpeed;	
			velocity.Y = direction.Y * movementSpeed;
			Velocity = velocity;
		}
		else
		{
			Velocity = direction;
		}

		MoveAndSlide();
	}

	private void ManageMovementAnimation(Vector2 direction)
	{
		if (direction.X != 0)
		{
			AnimatedSprite2D.Play((direction.X > 0) ? "walk_right" : "walk_left");
		}
		else if (direction.Y != 0)
		{
			AnimatedSprite2D.Play((direction.Y > 0) ? "walk_down" : "walk_up");
		}
		else
		{
			AnimatedSprite2D.Play("idle");
		}
	}

}
