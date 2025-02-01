using Godot;

public partial class Ball : CharacterBody2D
{
    private float _speed = 250f;
    private Vector2 _direction = Vector2.Zero;
    [Export] private Player _player1;
    [Export] private Player _player2;
    
    public override void _Ready()
    {
        Initilize();
    }

    public override void _PhysicsProcess(double delta)
    {
        
        var collision = MoveAndCollide(Velocity * (float)delta);
        if (collision != null)
        {
            if (collision.GetCollider() is Player)
            {
                ApplyRandomBounce(collision);
            }
            else
            {
                Velocity = Velocity.Bounce(collision.GetNormal());
            }
        }
        
        Vector2 velocity = Velocity;
        if (velocity <Vector2.Zero)
        {
            velocity.X = -_speed;
        }
        else
        {
            velocity.X = _speed;
        }
        
        Velocity = velocity;
        MoveAndSlide();
    }

    private void Initilize()
    {
        var velocity = Vector2.Zero;
        velocity.X = new RandomNumberGenerator().RandfRange(-_speed, _speed);
        velocity.Y = new RandomNumberGenerator().RandfRange(-_speed, _speed);
        Position = GetViewportRect().Size / 2;
        Velocity = velocity;
    }
    
    private async void _on_screen_exited()
    {
        switch (Position.X)
        {
            // Score
            case > 0f:
                _player1.IncreaseScore();
                break;
            case < 0f:
                _player2.IncreaseScore();
                break;
        }
        if (_player1.Score == 10 || _player2.Score == 10)
        {
            GetTree().Quit();
        }
        
        await ToSignal(GetTree().CreateTimer(1.0f), "timeout");
        Initilize();
    }

    private void ApplyRandomBounce(KinematicCollision2D collision)
    {

        var getNormal = collision.GetNormal();
        var randomAngle = Mathf.DegToRad(new RandomNumberGenerator().RandfRange(-45, 45));
        getNormal = getNormal.Rotated(randomAngle);
        Velocity = Velocity.Bounce(getNormal).Normalized() * _speed;
    }
    
}
