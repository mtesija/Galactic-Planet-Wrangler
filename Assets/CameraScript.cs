using UnityEngine;
using System.Collections;

public class CameraScript : MonoBehaviour
{
	Transform player;
	Vector3 velocity = Vector3.zero;
	float dampTime = .2f;

	void Start()
	{
		player = GameObject.FindGameObjectWithTag("Player").transform;
	}

	void Update()
	{
		Vector3 destination = transform.position + player.position - camera.ViewportToWorldPoint(new Vector3(0.5f, 0.4f, camera.WorldToViewportPoint(player.position).z));
		transform.position = Vector3.SmoothDamp(transform.position, destination, ref velocity, dampTime);
	}
}
