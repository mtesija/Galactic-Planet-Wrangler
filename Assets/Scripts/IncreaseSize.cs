using UnityEngine;
using System.Collections;

public class IncreaseSize : MonoBehaviour {	

	public Vector3 scaleAmount;

	void Update () {
		Vector3 newScale = transform.localScale + (scaleAmount * Time.deltaTime);

		transform.localScale = newScale;
	}
}
