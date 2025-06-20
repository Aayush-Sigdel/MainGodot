extends Control

@export var ball : PackedScene

func _ready() -> void:
	var plusThreebrickIns = get_node("res://06-BrickBraker/Scenes/pluse3multipilerbox.tscn")
	plusThreebrickIns.connect("plusThreeHit", Callable(self, "plusThree"))

func plusThree():
	var ballInstace = ball.instantiate()
	add_child(ballInstace)
