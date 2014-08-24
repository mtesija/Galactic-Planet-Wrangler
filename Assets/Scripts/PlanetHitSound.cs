using UnityEngine;
using System.Collections;

public class PlanetHitSound : MonoBehaviour
{
	AudioClip hit1;
	AudioClip hit2;
	AudioClip hit3;

	float cooldown = 0f;

	void Start()
	{
		hit1 = Resources.Load<AudioClip>("planetHitMouthSounds01");
		hit2 = Resources.Load<AudioClip>("planetHitMouthSounds02");
		hit3 = Resources.Load<AudioClip>("planetHitMouthSounds03");
	}

	void Update()
	{
		if(cooldown > 0)
		{
			cooldown -= Time.deltaTime;
		}
	}

	void OnCollisionEnter2D(Collision2D coll)
	{
		if(cooldown > 0)
		{
			return;
		}

		float rand = Random.Range(0, 3);

		if(rand == 0)
		{
			this.audio.clip = hit1;
			this.audio.Play();
		}
		else if(rand == 1)
		{
			this.audio.clip = hit2;
			this.audio.Play();
		}
		else if(rand == 2)
		{
			this.audio.clip = hit3;
			this.audio.Play();
		}

		cooldown = 2f;
	}
}
