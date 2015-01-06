using UnityEngine;
using System.Collections;

public class IndianaTrigger : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter (Collider other){
		if (other.gameObject.tag == "Player"){
			GameObject.Find ("Initialization").GetComponent<AudioSource> ().audio.Stop ();
			GameObject.Find ("IndianaJones").GetComponent<IndianaTime> ().playVideo = true;
			GameObject.Find ("Initialization").GetComponent<CursorTime> ().showCursor = false;
			Screen.lockCursor = true;
			Screen.showCursor = false;
			Destroy (this);
		}
	}
}
