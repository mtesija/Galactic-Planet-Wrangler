using UnityEngine;
using System.Collections;


public class PlayerScript : MonoBehaviour
{
	KeyCode keyJump = KeyCode.Space;
	KeyCode keyRun = KeyCode.LeftShift;

	bool isGrounded = true;

	bool changedDirection = false;
	
	float walkVelocity = 6f;
	float runVelocity = 9f;
	float airVelocityModifier = .55f;
	float jumpVelocity = 10f;
	float jumpVelocityModifier = .15f;

	void Awake()
	{
		DontDestroyOnLoad(this.gameObject);
	}

	void Update()
	{
		Move();
		Jump();
	}

	void Move()
	{
		float xVelocity = Input.GetAxis("Horizontal");
		
		if(Input.GetKey(keyRun))
		{
			xVelocity *= runVelocity;
		}
		else
		{
			xVelocity *= walkVelocity;
		}
		
		if(isGrounded)
		{
			changedDirection = false;
		}

		if(changedDirection || !isGrounded && Mathf.Sign(this.rigidbody2D.velocity.x) != Mathf.Sign(xVelocity))
		{
			changedDirection = true;
			xVelocity *= airVelocityModifier;
		}

		this.rigidbody2D.velocity = new Vector2(xVelocity, this.rigidbody2D.velocity.y);
	}

	void Jump()
	{
		
		float yVelocity = this.rigidbody2D.velocity.y;
		
		if(isGrounded && Input.GetKeyDown(keyJump) && this.rigidbody2D.velocity.y == 0)
		{
			yVelocity = jumpVelocity;
			isGrounded = false;
		}

		if(!isGrounded && Input.GetKey(keyJump) && this.rigidbody2D.velocity.y > 1.5f)
		{
			yVelocity += jumpVelocityModifier;
		}
				
		this.rigidbody2D.velocity = new Vector2(this.rigidbody2D.velocity.x, yVelocity);
	}

	void OnCollisionEnter2D(Collision2D coll)
	{
		if(coll.collider.CompareTag("Enemy"))
		{



			//DEAD



		}
	}

	void OnTriggerEnter2D(Collider2D coll)
	{
		if(coll.CompareTag("Terrain"))
		{
			isGrounded = true;
		}
	}
}
