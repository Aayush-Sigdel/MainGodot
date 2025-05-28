extends Node2D

@onready var tile_map_layer: TileMapLayer = $TileMapLayer
@onready var score: Label = $CanvasLayer/Control/MarginContainer/MarginContainer/VBoxContainer/HBoxContainer/score
@onready var Highscore: Label = $CanvasLayer/Control/MarginContainer/MarginContainer/VBoxContainer/HBoxContainer2/score

# Called when the node enters the scene tree for the first time.
func _ready() -> void:
	var offset = randf_range(-140,140.0)
	position.y = offset

func _process(delta: float) -> void:
	position.x -= 2
	
	if position.x < -2000:
		queue_free()
	score.text = str(Scoremanager.flappybirdScore)
	Highscore.text = str(Scoremanager.TotalCoin)
	
	

func _on_obs_body_entered(body: Node2D) -> void:
	if body is CharacterBody2D:
		print("you Died")
		get_tree().reload_current_scene()


func _on_score_body_entered(body: Node2D) -> void:
	if body is CharacterBody2D:
		Scoremanager.flappybirdScore += 1
		Scoremanager.TotalCoin += 1
		print(Scoremanager.TotalCoin)
