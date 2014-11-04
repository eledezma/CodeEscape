using UnityEngine;
using System.Collections;

[RequireComponent (typeof(AudioSource))]

public class RayCastZoomAttempt : MonoBehaviour {

	public AudioClip yahoo;
	public GameObject cam;
	public GameObject redEye1;
	public GameObject redEye2;
	public GameObject armCam;
	bool colliderHit;
	//public bool ray;
	// Use this for initialization
	void Start () {

		colliderHit = true;
		audio.clip = yahoo;
	}
	
	// Update is called once per frame
	void Update () {
		RaycastHit hit;
		Vector3 forward = transform.TransformDirection(Vector3.forward) * 1000;
		Physics.Raycast (transform.position, forward, out hit);
		Debug.DrawRay(transform.position, forward, Color.green);


		if (hit.collider.tag == "Respawn" && colliderHit) {
			colliderHit = false;
			Debug.Log ("I did it");
			GameObject.Find ("Main Camera").GetComponent<MouseLook> ().enabled = false;
			GameObject.Find ("First Person Controller").GetComponent<MouseLook> ().enabled = false;
			armCam.SetActive (false);
			Screen.lockCursor = true;
			//Screen.showCursor = false;
			GameObject.Find("Initialization").GetComponent<CursorTime>().showCursor=false;
			cam.SetActive (true);
			redEye1.SetActive (true);
			redEye2.SetActive (true);
			StartCoroutine (Playback ());
			//Destroy (this);
		}
	}
	

	IEnumerator Playback(){
		audio.Play ();
		yield return new WaitForSeconds(audio.clip.length);
		GameObject.Find ("Main Camera").GetComponent<MouseLook> ().enabled = true;
		GameObject.Find ("First Person Controller").GetComponent<MouseLook> ().enabled = true;
		armCam.SetActive (true);
		Screen.lockCursor = false;
		cam.SetActive (false);
		redEye1.SetActive (false);
		redEye2.SetActive (false);
		//Screen.showCursor = true;
		GameObject.Find ("Initialization").GetComponent<CursorTime> ().showCursor = true;
		Destroy (this);
	}
}
