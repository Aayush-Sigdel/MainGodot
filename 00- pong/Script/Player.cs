using Godot;

public partial class Player : CharacterBody2D
{
	private const float PlayerVelocity = 100.0f;
	[Export] public int PlayerId;
	public int Score;
	[Export] private Label _scoreLabel;
	

	public override void _PhysicsProcess(double delta)
	{
		Vector2 velocity = Velocity;

		if (Input.IsActionPressed($"up{PlayerId}"))
		{
			velocity.Y -= PlayerVelocity;
		}else if (Input.IsActionPressed($"down{PlayerId}"))
		{
			velocity.Y += PlayerVelocity;
		}
		else
		{
			velocity.Y = 0;
		}

		Velocity = velocity;
		MoveAndSlide();
		
		
	}

	public void IncreaseScore()
	{
		Score++;
		_scoreLabel.Text = Score.ToString().PadLeft(2,'0');
	}
}
