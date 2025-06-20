extends RigidBody2D

@onready var animated_sprite_2d: AnimatedSprite2D = $AnimatedSprite2D

func _process(delta: float) -> void:
	if get_colliding_bodies():
		if get_colliding_bodies()[0] is StaticBody2D:
			animated_sprite_2d.play("default")
			await  get_tree().create_timer(0.4).timeout
			if get_parent().get_parent().has_method("gameover"):
				get_parent().get_parent().gameover()
			queue_free()
