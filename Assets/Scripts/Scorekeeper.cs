using UnityEngine;
using System.Collections;

public class Scorekeeper : MonoBehaviour
{
	bool Endgame = false;
	bool displayGUI = false;
	float EndTimer = 3f;

	float Score = 0;
	float NumberPlanets = 0;
	float NumberAsteroids = 0;
	float TotalAsteroidMass = 0;
	float TotalPlanetMass = 0;
	float Speed = 0;

	public AudioClip hit1;
	public AudioClip hit2;
	public GameObject blackHole;

	float cooldown = 0;

	void Update()
	{
		if(cooldown > 0)
		{
			cooldown -= Time.deltaTime;
		}

		if(Endgame && !displayGUI)
		{
			if(EndTimer > 0)
			{
				EndTimer -= Time.deltaTime;

				Vector3 t = transform.localScale / 1.004f;
				transform.localScale = t;
			}
			else
			{
				//Hack, drop the blackhole
				Instantiate(blackHole, transform.position, Quaternion.identity);
				displayGUI = true;
			}
		}
	}

	void Sound()
	{
		if(cooldown <= 0)
		{
			cooldown = 1.5f;

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
	}

	void OnTriggerEnter2D(Collider2D coll)
	{
		if(coll.transform.name == "Player")
		{
			Speed = coll.rigidbody2D.velocity.magnitude;
			Endgame = true;
			Sound();
			Destroy(coll.gameObject, .1f);

			GameObject[] Objects = GameObject.FindGameObjectsWithTag("Gravity") as GameObject[];
			foreach(GameObject obj in Objects)
			{
				if(!obj.GetComponent<Gravity>())
				{
					continue;
				}

				obj.GetComponent<Gravity>().enabled = true;
			}
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
			if(!displayGUI)
			{
				NumberPlanets++;
				TotalPlanetMass += Random.Range(10000f, 1000000f);
			}
			Sound();
			Destroy(coll.gameObject, .1f);
		}
		else if(coll.transform.name == "Asteroid0"
		        || coll.transform.name == "Asteroid1"
		        || coll.transform.name == "Asteroid2")
		{
			if(!displayGUI)
			{
				NumberAsteroids++;
				TotalAsteroidMass += Random.Range(1000f, 10000f);
			}
			Sound();
			Destroy(coll.gameObject, .1f);
		}
	}

	void OnGUI()
	{
		if(displayGUI)
		{
			GUILayout.BeginArea(new Rect(0, 0, Screen.width, Screen.height));
			GUILayout.BeginHorizontal();
			GUILayout.FlexibleSpace();
			GUILayout.BeginVertical();
			GUILayout.FlexibleSpace();
			
			GUILayout.Label("You fed the Sun " + TotalPlanetMass + "kg from " + NumberPlanets + " Planets!");
			GUILayout.Label("You fed the Sun " + TotalAsteroidMass + "kg from " + NumberAsteroids + " Asteroids!");
			GUILayout.Label("You were going " + Speed + "m/s when you hit the Sun!");

			if(GUILayout.Button("Retry!"))
			{
				Application.LoadLevel("Main");
			}
			
			GUILayout.FlexibleSpace();
			GUILayout.EndVertical();
			GUILayout.FlexibleSpace();
			GUILayout.EndHorizontal();
			GUILayout.EndArea();
		}
	}
}
