extends CharacterBody2D

@onready var sprite_2d: Sprite2D = $Sprite2D

# Called when the node enters the scene tree for the first time.
func _ready() -> void:
	velocity.y += 600 

# Called every frame. 'delta' is the elapsed time since the previous frame.
func _process(delta: float) -> void:
	
	var collision_info = move_and_collide(velocity * delta)
	if collision_info:
		if collision_info.get_collider().has_method("paddleRefrenceMethod"):
			apply_random_bounce(collision_info)
		else:
			velocity = velocity.bounce(collision_info.get_normal())
			
		if collision_info.get_collider().has_method("normalHit"):
			collision_info.get_collider().normalhit()
		
		if collision_info.get_collider().has_method("plusThreeHit"):
			collision_info.get_collider().plusThreehit()
	
func apply_random_bounce(collision):
	var normal = collision.get_normal()
	var rng = RandomNumberGenerator.new()
	var random_angle = deg_to_rad(rng.randf_range(-20, 20))
	normal = normal.rotated(random_angle)
	velocity = velocity.bounce(normal).normalized() * 600
