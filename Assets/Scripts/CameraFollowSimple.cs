using UnityEngine;
using System.Collections;

public class CameraFollowSimple : MonoBehaviour {

	public GameObject objectToFollow;
	public float smoothSpeed;
	public float lockTime;
	float timer;
	bool lockout;
	
	// Use this for initialization
	void Start () {
		if(!objectToFollow)
		{
			Debug.Log("Camera has no object to follow");
			return;
		}
		timer = 0.0f;
		lockout = false;
	}
	
	// Update is called once per frame
	void Update () {
		if(!objectToFollow)
		{
			Debug.Log("Camera has no object to follow");
			return;
		}
		timer += Time.deltaTime;
		if(timer >= lockTime && !lockout)
		{
			smoothSpeed += 1.0f * Time.deltaTime;
			if(smoothSpeed >= 50.0f)
				lockout = true;
		}

		Vector3 v = Vector3.Lerp(transform.position, objectToFollow.transform.position, smoothSpeed * Time.deltaTime);
		v.z = -10;
		transform.position = v;
	}
}
