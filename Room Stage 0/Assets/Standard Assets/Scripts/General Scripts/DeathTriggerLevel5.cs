using UnityEngine;
using System.Collections;

public class DeathTriggerLevel5 : MonoBehaviour {

	public AudioClip death;
	// Use this for initialization
	void Start () {
	
	}

	void Update () {
		
	}
	
	// Update is called once per frame
	IEnumerator OnTriggerEnter (Collider other){
		if (other.gameObject.tag == "Player") {
			Destroy (GameObject.Find ("Main Camera").GetComponent<MouseLook>());
			Destroy (GameObject.Find ("First Person Controller").GetComponent<MouseLook>());
			GameObject.Find ("First Person Controller").GetComponent<CharacterMotor>().canControl = false;
			Destroy (GameObject.Find ("Initialization").GetComponent<CursorTime>());
			Screen.lockCursor = true;
			GameObject.Find ("Main Camera").transform.rotation = Quaternion.Euler(90, 0, 0); 
			audio.clip = death;
			audio.Play ();
			yield return new WaitForSeconds (audio.clip.length);
			Application.LoadLevel(4);
		}
	}
}
