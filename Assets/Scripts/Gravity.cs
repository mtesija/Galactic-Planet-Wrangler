using UnityEngine;
using System.Collections;

public class Gravity : MonoBehaviour
{
	float G = 10;

	void Update()
	{
		GameObject[] Objects = GameObject.FindGameObjectsWithTag("Gravity") as GameObject[];
		foreach(GameObject obj in Objects)
		{
			float distance = Vector2.Distance(obj.transform.position, this.transform.position);

			if(distance == 0)
			{
				continue;
			}

			Vector2 direction = obj.transform.position - this.transform.position;
			direction.Normalize();

			direction *= G * this.rigidbody2D.mass * obj.rigidbody2D.mass / (distance * distance);

			this.rigidbody2D.AddForce(direction);
		}
	}
}
