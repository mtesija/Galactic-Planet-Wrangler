using UnityEngine;
using System.Collections;

public class IncreaseMass : MonoBehaviour {

	public float startTime;
	float timer;
	public float massIncrease;


	// Use this for initialization
	void Start () {
		timer = 0.0f;
	}
	
	// Update is called once per frame
	void Update () {
		timer += Time.deltaTime;
		if(timer < startTime)
		{
			return;
		}
		rigidbody2D.mass += massIncrease * Time.deltaTime;
	}
}
