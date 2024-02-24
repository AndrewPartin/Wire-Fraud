using Godot;
using System;

public partial class World : Node3D
{
	public DirectionalLight3D Sun;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		Sun = GetNode<DirectionalLight3D>("Sun");
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		Sun.RotateX((float)delta / 100);
	}
}
