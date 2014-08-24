using UnityEngine;
using System.Collections;

public class Collision : MonoBehaviour
{
	public bool hitPlayer = false;
	
	void OnCollisionEnter2D(Collision2D coll)
	{
		if(this.GetComponent<DistanceJoint2D>())
		{
			return;
		}

		if(coll.transform.name == "Player")
		{
			hitPlayer = true;
			this.GetComponent<Gravity>().enabled = false;
			DistanceJoint2D joint = gameObject.AddComponent<DistanceJoint2D>() as DistanceJoint2D;
			joint.distance = Vector2.Distance(this.transform.position, coll.transform.position);
			joint.collideConnected = false;
			joint.connectedBody = coll.rigidbody;
		}
		else
		{
			Collision collision = coll.transform.GetComponent<Collision>();

			if(collision && collision.hitPlayer)
			{
				hitPlayer = true;
				this.GetComponent<Gravity>().enabled = false;
				DistanceJoint2D joint = gameObject.AddComponent<DistanceJoint2D>() as DistanceJoint2D;
				joint.distance = Vector2.Distance(this.transform.position, coll.transform.position);
				joint.collideConnected = false;
				joint.connectedBody = coll.rigidbody;
			}
		}
	}
}
