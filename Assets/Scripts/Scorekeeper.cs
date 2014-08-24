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

	void OnTriggerEnter2D(Collider2D coll)
	{
		if(coll.transform.name == "Player")
		{
			Speed = coll.rigidbody2D.velocity.magnitude;
			Endgame = true;
			
			Destroy(coll.gameObject, .1f);
		}
		else if(coll.transform.name == "Planet")
		{
			NumberPlanets++;
			TotalMass += coll.rigidbody2D.mass;

			Destroy(coll.gameObject, .1f);
		}
		else if(coll.transform.name == "Asteroid")
		{
			NumberAsteroids++;
			TotalMass += coll.rigidbody2D.mass;
			
			Destroy(coll.gameObject, .1f);
		}
	}
}
