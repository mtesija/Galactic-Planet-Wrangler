using UnityEngine;
using System.Collections;

public class Scorekeeper : MonoBehaviour
{
	bool Endgame = false;
	float EndTimer = 3f;

	float Score = 0;
	float NumberPlanets = 0;
	float NumberAsteroids = 0;
	float TotalMass = 0;
	float Speed = 0;

	public AudioClip hit1;
	public AudioClip hit2;

	float cooldown = 0;

	void Update()
	{
		if(Endgame)
		{
			if(EndTimer > 0)
			{
				EndTimer -= Time.deltaTime;
			}
			else
			{


				//CALCULATE SCORE


			}
		}
	}

	void Sound()
	{
		if(Random.Range(0, 2) == 0)
		{
			this.audio.clip = hit1;
			this.audio.Play();
		}
		else
		{
			this.audio.clip = hit2;
			this.audio.Play();
		}
	}

	void OnTriggerEnter2D(Collider2D coll)
	{
		if(coll.transform.name == "Player")
		{
			Speed = coll.rigidbody2D.velocity.magnitude;
			Endgame = true;
			Sound();
			Destroy(coll.gameObject, .1f);
		}
		else if(coll.transform.name == "Planet0"
		        || coll.transform.name == "Planet1"
		        || coll.transform.name == "Planet2"
		        || coll.transform.name == "Planet3"
		        || coll.transform.name == "Planet4"
		        || coll.transform.name == "Planet5"
		        || coll.transform.name == "Planet6"
		        || coll.transform.name == "Planet7"
		        || coll.transform.name == "Planet8"
		        || coll.transform.name == "Planet9")
		{
			NumberPlanets++;
			TotalMass += coll.rigidbody2D.mass;
			Sound();
			Destroy(coll.gameObject, .1f);
		}
		else if(coll.transform.name == "Asteroid0"
		        || coll.transform.name == "Asteroid1"
		        || coll.transform.name == "Asteroid2")
		{
			NumberAsteroids++;
			TotalMass += coll.rigidbody2D.mass;
			Sound();
			Destroy(coll.gameObject, .1f);
		}
	}
}
