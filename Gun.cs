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
	}

	private void _on_player_shoot()
	{
		Bullet b = Bullet.Instantiate<Bullet>();
		GetParent().GetParent().GetParent().AddChild(b);
		b.GlobalPosition = GetNode<Node3D>("BulletSpawn").GlobalPosition;
		b.GlobalRotation = GlobalTransform.Basis.Z;
		b.LinearVelocity = -50*GlobalTransform.Basis.Z;
	}
}
