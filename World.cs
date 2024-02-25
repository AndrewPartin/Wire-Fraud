using Godot;
using System;

public partial class World : Node3D
{
	[Export] private PackedScene playerScene;

	public DirectionalLight3D Sun;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		Sun = GetNode<DirectionalLight3D>("Sun");

		int index = 0;
		foreach (var player in GameManager.Players) {
			Player currentPlayer = playerScene.Instantiate<Player>();
			currentPlayer.Name = player.Id.ToString();
			currentPlayer.SetPlayerUsername(player.Name);
			AddChild(currentPlayer);

			foreach (Node3D spawnPoint in GetTree().GetNodesInGroup("SpawnPoint")) {
				if (int.Parse(spawnPoint.Name) == index) {
					currentPlayer.GlobalPosition = spawnPoint.GlobalPosition;
				}
			}
			index++;
		}
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		Sun.RotateX((float)delta / 100);
	}
}
