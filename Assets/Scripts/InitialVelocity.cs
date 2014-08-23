using UnityEngine;
using System.Collections;

public class InitialVelocity : MonoBehaviour
{
	float G = 10;

	void Start()
	{
		Transform sun = GameObject.Find("Sun").transform;

		Vector2 direction = this.transform.position - sun.position;
		direction.Normalize();
		direction = Quaternion.Euler(0, 0, 90) * direction;

		direction *= Mathf.Sqrt(G * sun.rigidbody2D.mass / Vector2.Distance(this.transform.position, sun.position));

		this.rigidbody2D.velocity = direction;
	}
}
