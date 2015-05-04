using UnityEngine;
using System.Collections;

public class StarTrig : MonoBehaviour
{
	public AudioClip star;
	public bool isActive;
	// Use this for initialization
	void Start ()
	{
		isActive = false;
	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "Player" && isActive) 
		{
			GameObject.Find("First Person Controller").GetComponent<GreenAndBlue4Eva>().discoParty = true;
			GameObject.Find("Initialization").GetComponent<AudioSource>().audio.clip = star;
			GameObject.Find("Initialization").GetComponent<AudioSource>().audio.Play ();
		}
	}

}
