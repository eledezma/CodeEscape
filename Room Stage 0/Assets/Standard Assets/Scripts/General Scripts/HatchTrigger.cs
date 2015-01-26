using UnityEngine;
using System.Collections;

public class HatchTrigger : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter (Collider other){

		if (other.gameObject.tag == "Boulder" && GameObject.Find ("Object").GetComponent<Rollinrollinrollin>().floorOpen) {
			GameObject.Find ("Object").GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
			Debug.Log("Yahoo");
			Destroy (this);
		}
	}
	void OnTriggerStay (Collider other){
		
		if (other.gameObject.tag == "Boulder" && GameObject.Find ("Object").GetComponent<Rollinrollinrollin>().floorOpen) {
			GameObject.Find ("Object").GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
			Debug.Log("Yahoo");
			Destroy (this);
		}
	}
}
