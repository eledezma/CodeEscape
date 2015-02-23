using UnityEngine;
using System.Collections;

public class BoulderTriggerZone : MonoBehaviour {

	// Use this for initialization
	void Start () {
		particleSystem.Stop();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider other){
		//blah blah
		if (other.tag == "test Ball") {
			particleSystem.Play ();
			Debug.Log("it hit us");
			audio.Play();
		}
	}
	void OnTriggerExit(Collider other){
		if (other.tag == "test Ball")
			particleSystem.Stop ();
	}
}
