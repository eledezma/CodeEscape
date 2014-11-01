using UnityEngine;
using System.Collections;

public class panel_collider : MonoBehaviour {
	void OnTriggerEnter(Collider col2){
		GameObject.Find ("Arm Camera").camera.enabled = false;
		Debug.Log ("DISENGAGE ARMS");
	}
	
	void OnTriggerExit(Collider col2){
		GameObject.Find ("Arm Camera").camera.enabled = true;
		Debug.Log ("ENGAGE ARMS");
	}

}
