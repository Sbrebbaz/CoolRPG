using Godot;
using System;
using static Enumerators;

public partial class Player : CharacterBody2D
{
	[Export] public PlayerBase PlayerBase;

	private AnimatedSprite2D AnimatedSprite2D { get; set; }
	private GameManager _gameManager;

	public override void _Ready()
	{
		base._Ready();
		AnimatedSprite2D = GetNode<AnimatedSprite2D>("AnimatedSprite2D");
		_gameManager = GetNode<GameManager>("/root/GameManager");
	}

	public override void _Process(double delta)
	{
		if (Input.IsActionPressed("ui_cancel"))
		{
			_gameManager.NavigateToGameState(GameState.Pause);
		}
	}

	public override void _PhysicsProcess(double delta)
	{
		Vector2 velocity = Velocity;
		Vector2 direction = Input.GetVector("ui_left", "ui_right", "ui_up", "ui_down");
		float movementSpeed = PlayerBase.Speed;
		AnimatedSprite2D.SpeedScale = 1f;

		if (Input.IsActionPressed("ui_run"))
		{
			movementSpeed *= PlayerBase.RunningMultiplier;
			AnimatedSprite2D.SpeedScale *= PlayerBase.RunningMultiplier;
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
