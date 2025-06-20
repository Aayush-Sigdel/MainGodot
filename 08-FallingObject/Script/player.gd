extends CharacterBody2D
@onready var animated_sprite_2d: AnimatedSprite2D = $AnimatedSprite2D

var SPEED = 600
var gravity = ProjectSettings.get_setting("physics/2d/default_gravity")
# Called when the node enters the scene tree for the first time.
func _ready() -> void:
	pass # Replace with function body.


# Called every frame. 'delta' is the elapsed time since the previous frame.
func _physics_process(delta: float) -> void:
	
	velocity.y += gravity * delta
	
	if Input.is_action_just_pressed("up") and is_on_floor():
		velocity.y -= SPEED
	
	var dir = Input.get_axis("left","right")
	if dir == -1:
		animated_sprite_2d.flip_h = true
	elif dir == 1:
		animated_sprite_2d.flip_h = false
		
	velocity.x = dir * SPEED
	
	if !is_on_floor():
		animated_sprite_2d.play("jump")
	elif is_on_floor() and dir!= 0:
		animated_sprite_2d.play("run")
	else :
		animated_sprite_2d.play("idel")
		
		
	dir = 0
	move_and_slide()
