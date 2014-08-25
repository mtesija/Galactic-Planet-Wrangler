using UnityEngine;
using System.Collections;

public class InitialZoom : MonoBehaviour {

	public Camera c;
	public float zoomSpeed;
	public float zoomTo;
	public float zoomTime;
	float timer;

	// Use this for initialization
	void Start () {
		timer = 0;
	}
	
	// Update is called once per frame
	void Update () {

		float zoom = Input.GetAxis("Mouse ScrollWheel");
		c.orthographicSize += zoom * -1.0f;
		if(c.orthographicSize >= 30.0f)
		{
			c.orthographicSize = 30.0f;
		}
		if(c.orthographicSize <= 3.0f)
		{
			c.orthographicSize = 3.0f;
		}
		
		if(zoom >= 0.1f || zoom <= -0.1f)
		{
			timer = zoomTime;
		}
		timer += Time.deltaTime;
		if(timer >= zoomTime)
		{
			return;
		}
		c.orthographicSize = Mathf.Lerp(c.orthographicSize, zoomTo, zoomSpeed * Time.deltaTime);
	}
}
