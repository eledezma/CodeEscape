using UnityEngine;
using System.Collections;

[RequireComponent (typeof (AudioSource))]

public class ShotMovement : MonoBehaviour 
{
	public int color;
	public AudioClip hit;

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

	IEnumerator OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "Player" && GameObject.Find("First Person Controller").GetComponent<CurrentShield>().shield != color)
		{
			audio.PlayOneShot(hit, 1);
			yield return new WaitForSeconds(0.2F);
			Application.LoadLevel(Application.loadedLevel);
		}
	}
}
