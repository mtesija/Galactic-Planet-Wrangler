﻿using UnityEngine;
using System.Collections;

public class PlayerMove : MonoBehaviour
{
	Transform sun;

	void Awake()
	{
		sun = GameObject.Find("Sun").transform;
	}

	void Update()
	{
			float distance = Vector2.Distance(sun.position, this.transform.position);
			Vector2 direction = sun.position - this.transform.position;
			direction.Normalize();
			
			direction *= 10 * this.rigidbody2D.mass * sun.rigidbody2D.mass / (distance * distance);
			
			this.rigidbody2D.AddForce(direction);

			if(Input.GetMouseButton(0))
			{
				this.rigidbody2D.mass = 1;
				
				direction = GameObject.Find("Main Camera").camera.ScreenToWorldPoint(Input.mousePosition) - this.transform.position;
				direction.Normalize();
				
				direction *= 8;
				
				this.rigidbody2D.velocity = direction;
			}

	}
}
