using Godot;
using System;

public partial class Gun : Node3D
{
	[Export] private PackedScene Bullet;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		if (Input.IsActionJustPressed("shoot")) {
			Bullet b = Bullet.Instantiate<Bullet>();
			GetParent().GetParent().GetParent().AddChild(b);
			b.GlobalPosition = GetNode<Node3D>("BulletSpawn").GlobalPosition;
			b.LinearVelocity = -50*GlobalTransform.Basis.Z;
		}
	}
}
