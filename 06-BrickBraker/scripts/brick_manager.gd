extends Node2D

@export var row :int =  10
@export var colum : int = 7
@export var gap : float = 50

@export var GridMeshScene: PackedScene = preload("res://06-BrickBraker/Scenes/bricks.tscn")

func _ready() -> void:
	for i in row:
		for j in colum:
			var GridMesh = GridMeshScene.instantiate()
			add_child(GridMesh)
			GridMesh.position = Vector2(gap+(65 * j),gap+(20 * i))
