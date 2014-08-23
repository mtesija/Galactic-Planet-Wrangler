using UnityEngine;
using System.Collections;

public class FallingObjectScript : MonoBehaviour
{
	Transform player;
	bool isFalling = false;

	void Start()
	{
		player = GameObject.FindGameObjectWithTag("Player").transform;	
	}

	void Update()
	{
		if(!isFalling && Mathf.Abs(this.transform.position.x - player.position.x) < 3)
		{
			isFalling = true;
			this.rigidbody2D.gravityScale = 2.5f;
		}
	}

	void OnCollisionEnter2D(Collision2D coll)
	{
		if(!coll.transform.CompareTag("Player"))
		{
			this.GetComponent<BoxCollider2D>().enabled = false;
			this.rigidbody2D.gravityScale = 0;




			//Play animation




			Destroy(this.gameObject, .5f);
		}
	}


}
