using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : ComponentBase
{
	public Rigidbody2D Rigidbody2D;
	public InputBase InputBase;
	public float MoveSpeed;
	public float TorqueSpeed;

	Vector2 acceleration;


	void FixedUpdate()
	{
		Rigidbody2D.AddForce(CalculateMoveForce(), ForceMode2D.Impulse);
		Rigidbody2D.AddTorque(CalculateTorqueForce(), ForceMode2D.Impulse);
	}

	Vector2 CalculateMoveForce()
	{
		acceleration = new Vector2(0f, InputBase.Direction.y * MoveSpeed);
		acceleration = Rigidbody2D.transform.TransformVector(acceleration);

		return acceleration;
	}

	float CalculateTorqueForce()
	{
		return -InputBase.Direction.x * TorqueSpeed;
	}
}
