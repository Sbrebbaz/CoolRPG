using Godot;
using System;

public partial class SceneLoader : Node2D
{
	[Export] public PackedScene SceneToLoad;

	private void _on_area_2d_body_entered(Node2D body)
	{
		if (body is BasePlayer)
		{
			GetTree().ChangeSceneToPacked(SceneToLoad);
		}
	}
}

