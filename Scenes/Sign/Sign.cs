using Godot;
using System;

public partial class Sign : CharacterBody2D
{
    [Export] public DialogBase Dialog { get; set; }

    private GameManager _gameManager;
    private bool isPlayerCloseEnough = false;
    private bool isDialogDisplayed = false;

    public override void _Ready()
    {
        _gameManager = GetNode<GameManager>("/root/GameManager");
        isPlayerCloseEnough = false;
        isDialogDisplayed = false;
        Dialog.DialogEndedEVT += Dialog_DialogEnded;
    }

    private void Dialog_DialogEnded(object sender, EventArgs e)
    {
        isDialogDisplayed = false;
    }

    // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(double delta)
    {
        if (isPlayerCloseEnough &&
            !isDialogDisplayed &&
            Input.IsActionJustPressed("ui_accept"))
        {
            isDialogDisplayed = true;
            Dialog.ResetDialog();
            _gameManager.ShowDialog(Dialog);
        }
        if (!isPlayerCloseEnough &&
            isDialogDisplayed)
        {
            _gameManager.EndDialog();
		}
    }

    public void _on_area_2d_body_entered(Node2D body)
    {
        if (body is Player)
        {
            isPlayerCloseEnough = true;
        }
    }

    public void _on_area_2d_body_exited(Node2D body)
    {
        if (body is Player)
        {
            isPlayerCloseEnough = false;
        }
    }

}
