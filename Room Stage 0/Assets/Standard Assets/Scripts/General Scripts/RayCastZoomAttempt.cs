using UnityEngine;
using System.Collections;

[RequireComponent (typeof(AudioSource))]

public class RayCastZoomAttempt : MonoBehaviour {

	public AudioClip yahoo;
	public GameObject cam;
	public GameObject redEye1;
	public GameObject redEye2;
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
			//GameObject.Find ("First Person Controller").GetComponent<CharacterMotor>().canControl = false;
			Screen.showCursor = false;
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
		//GameObject.Find ("First Person Controller").GetComponent<CharacterMotor>().canControl = true;
		cam.SetActive (false);
		redEye1.SetActive (false);
		redEye2.SetActive (false);
		Screen.showCursor = true;
		GameObject.Find ("OscarColid").GetComponent<CursorTime> ().showCursor = true;
		Destroy (this);
	}
}
