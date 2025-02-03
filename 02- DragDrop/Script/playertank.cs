using Godot;
using System;

public partial class playertank : CharacterBody2D
{
	private float _speed = 300f;
	[Export] NavigationAgent2D _navigationAgent;
	public Boolean _mouseOver = false;
	[Export] public CollisionShape2D _collisionShape;
    
	public override void _Process(double delta)
	{
		//player rotation
		Vector2 targetPosition = _navigationAgent.GetNextPathPosition();
		Vector2 direction = (targetPosition - GlobalPosition).Normalized();
		var targetRotation = direction.Angle();
		 Rotation = Mathf.LerpAngle(Rotation, targetRotation, 10.0f * (float)delta);
		
		// navigating through navigation field
		if (Input.IsActionJustPressed("mouse.left"))
		{
			var map = _navigationAgent.GetNavigationMap();
			Vector2 p = GetGlobalMousePosition(); 
			Vector2 closestPoint = NavigationServer2D.MapGetClosestPoint(map, p);
			_navigationAgent.TargetPosition = closestPoint;	
		}

		if (_mouseOver && Input.IsActionPressed("mouse.right") == true)
		{
			Position = GetGlobalMousePosition();
			_collisionShape.Scale = new Vector2(64f, 64f);
		}
		else
		{
			_collisionShape.Scale = new Vector2(6f, 6f);
		}
		
		
		
		
		MoveTowards();
		
	}

	//Character Movement
	private void MoveTowards()
	{
		if(_navigationAgent.IsNavigationFinished()) return;
		Vector2 diff = (_navigationAgent.GetNextPathPosition() - GlobalPosition);
		if (diff.Length() < 10) return;
		Vector2 direction = diff.Normalized();
		Velocity = direction * _speed;
		MoveAndSlide();
		GD.Print("Velocity: " + Velocity);
	}

	public void _on_mouse_entered()
	{
		GD.Print("Mouse entered");
		_mouseOver = true;
	}

	public void _on_mouse_exited()
	{	GD.Print("Mouse exited");
		_mouseOver = false;
	}
}
