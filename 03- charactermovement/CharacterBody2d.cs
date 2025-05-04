using Godot;
using System;

public partial class CharacterBody2d : CharacterBody2D
{
	[Export] float moveSpeed = 50f;
	[Export] float jumpForce = 800f;
	[Export] private AnimatedSprite2D _animatedSprite;

	public float Gravity = 960.0f;
	
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _PhysicsProcess(double delta)
	{
		var direction = Velocity;

		if (!IsOnFloor())
		{
			direction.Y += Gravity *(float)delta;
		}

		if (IsOnFloor() && Input.IsActionPressed("ui_up"))
		{
			direction.Y = -jumpForce;
		}
		
		if (Input.IsActionPressed("ui_right"))
		{
			direction.X = moveSpeed;
			_animatedSprite.Play("run");
			_animatedSprite.FlipH = false;
		} else if (Input.IsActionPressed("ui_left"))
		{
			direction.X = -moveSpeed;
			_animatedSprite.Play("run");
			_animatedSprite.FlipH = true;
		}
		else
		{
			direction.X = 0f;
			_animatedSprite.Play("idel");
		}
		
		Velocity = direction;
		
		MoveAndSlide();
	}
}
