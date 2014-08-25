using UnityEngine;
using System.Collections;

public class PlayerMove : MonoBehaviour
{
	bool started = false;
	Transform sun;

	void Awake()
	{
		sun = GameObject.Find("Sun").transform;
	}

	void Update()
	{
		if(started == true)
		{
			float distance = Vector2.Distance(sun.position, this.transform.position);
			Vector2 direction = sun.position - this.transform.position;
			print(direction);
			direction.Normalize();
			
			direction *= 10 * this.rigidbody2D.mass * sun.rigidbody2D.mass / (distance * distance);
			
			this.rigidbody2D.AddForce(direction);

			if(Input.GetMouseButton(0))
			{
				Vector2 velocity = this.rigidbody2D.velocity;
				velocity *= .8f;
				this.rigidbody2D.velocity = velocity;
			}
		}
		else
		{
			if(Input.GetMouseButtonDown(0))
			{
				started = true;
				this.rigidbody2D.mass = 1;

				Vector2 direction = GameObject.Find("Main Camera").camera.ScreenToWorldPoint(Input.mousePosition) - this.transform.position;
				direction.Normalize();

				direction *= 8;

				this.rigidbody2D.velocity = direction;
			}
		}
	}
}
