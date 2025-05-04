using Godot;
using System;
using System.Text.RegularExpressions;

public partial class Boat : CharacterBody3D
{
	const float BOAT_SPEED = 2.5f;
	
	bool mouseInput = false;
	float rotationInput = 0.0f; 
	float rotationSpeed = BOAT_SPEED;
	private float tiltSpeed = 0.0f;
	Vector2 mouse_rotation;
	Vector3 playerRotation;
	Vector3 cameraRotation; 
	float currentRotation = 0.0f;
	Vector2 perviousCameraPosition = Vector2.Zero;
	Vector2 cameraPosition;
	
	[Export] Node3D arm;
	
	// Called when the node enters the scene tree for the first time.
	public override void _Ready(){
		Input.MouseMode = Input.MouseModeEnum.Captured;
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		UpdateCamera((float)delta);
		var velocity = Velocity;
		if (Input.IsActionPressed("up"))
		{
			velocity.X += BOAT_SPEED;
		}
		else if(Input.IsActionPressed("right"))
		{
			velocity.Z += BOAT_SPEED;
		}
		else if (Input.IsActionPressed("down"))
		{
			velocity.X -= BOAT_SPEED;
		}
		else if (Input.IsActionPressed("left"))
		{
			velocity.Z -= BOAT_SPEED;
		}
		else
		{
			velocity.X = 0;
			velocity.Z = 0;
		}
		Velocity = velocity;
		MoveAndSlide();
	}
	
	private Vector2 mouseRotation = Vector2.Zero;
    
	public override void _Input(InputEvent @event)
	{
		if (@event is InputEventMouseMotion eventMouseMotion)
		{
			mouseRotation = eventMouseMotion.Relative;
		}
	}

	public void UpdateCamera(float delta)
	{
		Vector3 playerRotation = RotationDegrees;

		if (mouseRotation != Vector2.Zero)
		{
			// Rotate Yaw (left/right) using mouse X
			playerRotation.Y -= mouseRotation.X * tiltSpeed;

			// Rotate Pitch (up/down) using mouse Y (clamped to avoid flipping)
			playerRotation.X = Mathf.Clamp(playerRotation.X - mouseRotation.Y * tiltSpeed, -89, 89);
		}

		RotationDegrees = playerRotation;
		mouseRotation = Vector2.Zero; // Reset mouse input after applying rotation
	}
}

