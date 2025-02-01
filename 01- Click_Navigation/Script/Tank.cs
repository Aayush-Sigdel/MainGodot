using Godot;

public partial class Tank : CharacterBody2D
{
	private float _speed = 300f;
   [Export] NavigationAgent2D _navigationAgent;
    
   	public override void _Process(double delta)
	{
		//player rotation
		Vector2 targetPosition = _navigationAgent.GetNextPathPosition();
		Vector2 direction = (targetPosition - GlobalPosition).Normalized();
		float targetRotation = direction.Angle();
		Rotation = Mathf.LerpAngle(Rotation, targetRotation, 10.0f * (float)delta);
		
		// navigating through navigation field
		if (Input.IsActionJustPressed("mouse.left"))
		{
			var map = _navigationAgent.GetNavigationMap();
			Vector2 p = GetGlobalMousePosition(); 
			Vector2 closestPoint = NavigationServer2D.MapGetClosestPoint(map, p);
			_navigationAgent.TargetPosition = closestPoint;	
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
	}
}
