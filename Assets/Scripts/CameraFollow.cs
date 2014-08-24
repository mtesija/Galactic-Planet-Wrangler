using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CameraFollow : MonoBehaviour {

	public List<GameObject> followObjects;
	public float minCameraSize;
	public float extraCameraSpace;
	public float followSpeed;
	public float zoomSpeed;
	public Camera c;

	int numLivingPlayers;
	Vector2 furthestPlayer;
	Vector3 lastKnownPlayer;
	Vector3 cameraPosition;
	Camera mainCamera;
	float aspectRatio;
	Vector3 cameraTo;
	float zoomTo;

	// Use this for initialization
	void Start () {
		furthestPlayer = Vector2.zero;
		cameraPosition = Vector3.zero;
		numLivingPlayers = 0;
		mainCamera = c;
		aspectRatio = mainCamera.aspect;
		cameraTo = mainCamera.transform.position;
		zoomTo = mainCamera.orthographicSize;
	}
	
	// Update is called once per frame
	void Update () {
		furthestPlayer = Vector2.zero;
		cameraPosition = Vector3.zero;
		numLivingPlayers = 0;

		//Get the midpoint of the players
		foreach(GameObject player in followObjects)
		{
			if(player)
			{
				cameraPosition += player.transform.position;
				lastKnownPlayer = cameraPosition;
				numLivingPlayers++;
			}
		}

		//If there are players center the camera on their midpoint, otherwise leave at the last known player position
		if(numLivingPlayers == 0)
		{
			cameraPosition.z = transform.position.z;
			cameraPosition = lastKnownPlayer;
		}
		else if(numLivingPlayers == 1)
		{
			cameraPosition /= numLivingPlayers;
			cameraPosition.z = transform.position.z;
			cameraTo = cameraPosition;
			zoomTo = minCameraSize;
		}
		else
		{
			cameraPosition /= numLivingPlayers;
			cameraPosition.z = transform.position.z;
			cameraTo = cameraPosition;

			//Find the furthest x / y distance of the players
			furthestPlayer = cameraPosition;
			foreach(GameObject player in followObjects)
			{
				if(player)
				{
					if(Mathf.Abs(player.transform.position.x) > furthestPlayer.x)
						furthestPlayer.x = player.transform.position.x;
					if(Mathf.Abs(player.transform.position.y) > furthestPlayer.y)
						furthestPlayer.y = player.transform.position.y;
				}
			}

			float yDifference = Mathf.Abs(furthestPlayer.y - cameraPosition.y) + extraCameraSpace;
			float xDifference = (Mathf.Abs(furthestPlayer.x - cameraPosition.x)+ extraCameraSpace) / aspectRatio;

			//Zoom if players are off screen
			float difference = yDifference > xDifference ? yDifference : xDifference;
			if(difference >= minCameraSize)
				zoomTo = difference;
		}

		//Smoothly move the camera towards cameraTo
		transform.position = Vector3.Lerp(transform.position, cameraTo, followSpeed * Time.deltaTime);

		//Smoothly zoom the camera to zoomTo
		mainCamera.orthographicSize = Mathf.Lerp(mainCamera.orthographicSize, zoomTo, zoomSpeed * Time.deltaTime);
	}
}
