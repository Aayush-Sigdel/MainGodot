extends CharacterBody2D

@onready var ray_cast_2d: RayCast2D = $RayCast2D
@onready var animated_sprite_2d: AnimatedSprite2D = $AnimatedSprite2D
@onready var ray_cast_2d_2: RayCast2D = $RayCast2D2
@onready var layegg: Timer = $layegg
var eggScene = preload("res://08-FallingObject/Scenes/egg.tscn")

func _ready() -> void:
	var spawnposition = Vector2(randi_range(370,770),70)
	position = spawnposition
	var randomnum = randi_range(0,1)
	if randomnum == 1:
		velocity.x = 50
	else:
		animated_sprite_2d.flip_h = true
		velocity.x = -50
		
	layegg.wait_time = randf_range(2.0, 15.0)
	layegg.start()

func _physics_process(delta: float) -> void:
	var speed = randi_range(50,150)
	if ray_cast_2d.is_colliding():
		velocity.x = -speed
		animated_sprite_2d.flip_h = true
	
	if ray_cast_2d_2.is_colliding():
		velocity.x = speed
		animated_sprite_2d.flip_h = false
		
	move_and_slide()
	


func _on_layegg_timeout() -> void:
	var eggIns = eggScene.instantiate()
	add_child(eggIns)
	
	layegg.wait_time = randf_range(2.0, 15.0)
	layegg.start()
