extends Node2D

@onready var spawnchicken: Timer = $spawnchicken
var chicken = preload("res://08-FallingObject/Scenes/chicken.tscn")
@onready var score: Label = $CanvasLayer/MarginContainer/VBoxContainer/HBoxContainer/Score
@onready var destroyedlabel: Label = $CanvasLayer/MarginContainer/VBoxContainer/HBoxContainer2/destroyed

var current_score = 0
var destroyed = 0

# Called every frame. 'delta' is the elapsed time since the previous frame.
func _process(delta: float) -> void:
	randomize()


func _on_spawnchicken_timeout() -> void:
	spawnchicken.wait_time = randi_range(20,50)
	var chickenIns = chicken.instantiate()
	add_child(chickenIns)


func _on_area_2d_body_entered(body: Node2D) -> void:
	if body is RigidBody2D:
		body.queue_free()
		current_score += 1
		score.text = str(current_score)
func gameover():
	if destroyed != 20:
		destroyed+=1
		destroyedlabel.text = str(destroyed)
		return
	get_tree().reload_current_scene()
		
