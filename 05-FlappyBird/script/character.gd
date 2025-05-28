extends CharacterBody2D

@export var moveSpeed: float = 600.0
var gravity = 1200
# Called when the node enters the scene tree for the first time.
func _ready() -> void:
	print(gravity)
	Scoremanager.flappybirdScore = 0


# Called every frame. 'delta' is the elapsed time since the previous frame.
func _process(delta: float) -> void:
	if Input.is_action_just_pressed("mouse.left"):
		velocity.y = 0
		velocity.y -= moveSpeed
	else:
		velocity.y += gravity * delta
		
	move_and_slide()


func _on_static_body_2d_body_entered(body: Node2D) -> void:
	if body is CharacterBody2D:
		print("you died")
		get_tree().reload_current_scene()
