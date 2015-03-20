using UnityEngine;
using System.Collections;

public class ShotMovement : MonoBehaviour 
{
	public int color;

	// Use this for initialization
	void Start ()
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z - 0.5F);
		if (transform.position.z < -44F)
		{
			Destroy (this.gameObject);
		}
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "Player" && GameObject.Find("First Person Controller").GetComponent<CurrentShield>().shield != color)
		{
			Application.LoadLevel(Application.loadedLevel);
		}
	}
}
