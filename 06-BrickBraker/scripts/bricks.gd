extends RigidBody2D

@export var isPlusThreeBox: bool
@export var isNormalBlock: bool

signal plusThreeHit
# Called when the node enters the scene tree for the first time.
func _ready() -> void:
	pass # Replace with function body.


# Called every frame. 'delta' is the elapsed time since the previous frame.
func _process(delta: float) -> void:
	pass


func normalHit():
	if isNormalBlock:
		await get_tree().create_timer(0.05).timeout
		queue_free()
	
func plusThreehit():
	if isPlusThreeBox:
		plusThreeHit.emit()
		await get_tree().create_timer(0.05).timeout
		queue_free()
