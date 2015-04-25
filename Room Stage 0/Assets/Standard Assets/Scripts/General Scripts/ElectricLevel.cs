using UnityEngine;
using System.Collections;

public class ElectricLevel : MonoBehaviour
{
	public AudioClip zap;
	private bool immunity;
	// Use this for initialization
	void Start ()
	{
		immunity = false;
	}
	
	// Update is called once per frame
	void Update () 
	{

	}

	void OnTriggerStay(Collider other)
	{
		if (other.gameObject.tag == "Player" && !immunity && !GameObject.Find("First Person Controller").GetComponent<GreenAndBlue4Eva>().green)
		{
			immunity = true;
			audio.PlayOneShot(zap, 1);
			GameObject.Find("First Person Controller").GetComponent<Level10Health>().health -= 25;
			StartCoroutine(Invincible());
		}

	}

	IEnumerator Invincible()
	{
		yield return new WaitForSeconds (3);
		immunity = false;
	}
}
