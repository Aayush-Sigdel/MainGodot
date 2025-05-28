extends Node2D

var obs = preload("res://05-FlappyBird/scenes/obstacles_up.tscn")
@onready var timer: Timer = $"../Timer"

# Called when the node enters the scene tree for the first time.
func _ready() -> void:
	spawn_pipe()


# Called every frame. 'delta' is the elapsed time since the previous frame.
func spawn_pipe():
	var obs_ins = obs.instantiate()
	add_child(obs_ins)
	
func _on_timer_timeout() -> void:
	spawn_pipe()
	timer.wait_time = randf_range(1,2)
	
	
