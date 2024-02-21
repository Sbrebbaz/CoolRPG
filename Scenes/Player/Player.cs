using Godot;
using System;
using static Enumerators;

public partial class Player : CharacterBody2D
{
    [Export] public MovementBase MovementBase;

    private AnimatedSprite2D _animatedSprite2D;
    private GameManager _gameManager;
    private Label _narrativeLabel;

    public bool NarrativeLabelVisible
    {
        get
        {
            return _narrativeLabel.Visible;
        }
        set
        {
            _narrativeLabel.Visible = value;
        }
    }

    public string NarrativeLabelText
    {
        get
        {
            return _narrativeLabel.Text;
        }
        set
        {
            _narrativeLabel.Text = value;
        }
    }


    public override void _Ready()
    {
        base._Ready();
        _animatedSprite2D = GetNode<AnimatedSprite2D>("AnimatedSprite2D");
        _gameManager = GetNode<GameManager>("/root/GameManager");
        _narrativeLabel = GetNode<Label>("NarrativeLabel");

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
        float movementSpeed = MovementBase.Speed;
        _animatedSprite2D.SpeedScale = 1f;

        if (Input.IsActionPressed("ui_run"))
        {
            movementSpeed *= MovementBase.RunningMultiplier;
            _animatedSprite2D.SpeedScale *= MovementBase.RunningMultiplier;
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
            _animatedSprite2D.Play((direction.X > 0) ? "walk_right" : "walk_left");
        }
        else if (direction.Y != 0)
        {
            _animatedSprite2D.Play((direction.Y > 0) ? "walk_down" : "walk_up");
        }
        else
        {
            _animatedSprite2D.Play("idle");
        }
    }


}
