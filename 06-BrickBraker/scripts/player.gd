extends CharacterBody2D

@export var player_speed : float = 500.0

func _process(delta: float) -> void:
	if Input.is_action_pressed("left"):
		velocity.x = -player_speed
	elif Input.is_action_pressed("right"):
		velocity.x = player_speed
	else:
		velocity.x = 0
		
	move_and_slide()

func paddleRefrenceMethod():
	pass
