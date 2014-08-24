using UnityEngine;
using System.Collections;

public class PlayerSound : MonoBehaviour
{
	public AudioClip yeehaw1;
	public AudioClip yeehaw2;

	float cooldown = 0f;

	void Update()
	{
		if(cooldown > 0)
		{
			cooldown -= Time.deltaTime;
		}

		if(Input.GetMouseButtonDown(1) && cooldown <= 0)
		{
			if(Random.Range(0, 2) == 0)
			{
				this.audio.clip = yeehaw1;
				this.audio.Play();
			}
			else
			{
				this.audio.clip = yeehaw2;
				this.audio.Play();
			}

			cooldown = 1.5f;
		}
	}

	void OnCollisionEnter2D(Collision2D coll)
	{
		if(cooldown > 0)
		{
			return;
		}

		if(Random.Range(0, 2) == 0)
		{
			this.audio.clip = yeehaw1;
			this.audio.Play();
		}
		else
		{
			this.audio.clip = yeehaw2;
			this.audio.Play();
		}
		
		cooldown = 1.5f;
	}
}
