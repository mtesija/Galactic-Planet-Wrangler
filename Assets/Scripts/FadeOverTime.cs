using UnityEngine;
using System.Collections;

public class FadeOverTime : MonoBehaviour {

	public float fadeTime;
	float totalTime;
	SpriteRenderer spriteRenderer;
	bool stopTrying;

	// Use this for initialization
	void Start () {
		spriteRenderer = (SpriteRenderer)transform.GetComponent("SpriteRenderer");
		totalTime = 0.0f;
		stopTrying = false;
	}
	
	// Update is called once per frame
	void Update () {
		if(stopTrying)
		{
			return;
		}
		totalTime += Time.deltaTime;
		Color color = spriteRenderer.color;
		color.a = Mathf.Lerp(1f, 0f, totalTime / fadeTime);
		spriteRenderer.color = color;
		if(color.a <= 0)
		{
			stopTrying = true;
	
		}
	}
}
