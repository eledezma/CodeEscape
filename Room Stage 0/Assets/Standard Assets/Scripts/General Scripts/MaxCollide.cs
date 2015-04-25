using UnityEngine;
using System.Collections;

[RequireComponent (typeof (AudioSource))]

public class MaxCollide : MonoBehaviour {

	public GameObject wings;
	public GameObject sphere;
	public AudioClip clip1, clip2;
	public Camera cam;
	bool drop;
	// Use this for initialization
	void Start () {
		drop = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (drop)
			transform.position = new Vector3(transform.position.x, transform.position.y - 0.5F, transform.position.z);
	}

	void OnTriggerEnter (Collider other){

		if (other.gameObject.tag == "Bullet") {
			Debug.Log ("Hi");
			audio.PlayOneShot(clip1, 1);
			Destroy (wings);
			Destroy (sphere);
			StartCoroutine(fall());
		}

		if (other.gameObject.tag == "Player" && GameObject.Find("First Person Controller").GetComponent<GreenAndBlue4Eva>().discoParty) {
			//play video

			GameObject.Find("First Person Controller").GetComponent<GreenAndBlue4Eva>().discoParty = false;
			GameObject.Find ("Star").GetComponent<StarPanel> ().dark ();
			Destroy (this.gameObject);

			//audio.PlayOneShot(clip1, 1);
		}

	}

	IEnumerator fall(){
		yield return new WaitForSeconds (2);
		drop = true;
		audio.PlayOneShot(clip2, 1);
		yield return new WaitForSeconds (5);
		drop = false;
		transform.position = new Vector3(152.6644F, -5.639513F, 283.6994F);
		transform.Rotate(new Vector3(90,270,0));
		cam.depth = -1;
		GameObject.Find ("First Person Controller").GetComponent<Level10Health> ().guiEnabled = true;
		Screen.lockCursor = false;
		GameObject.Find ("Star").GetComponent<StarPanel> ().yellow ();
		GameObject.Find ("Initialization").GetComponent<CursorTime> ().showCursor = true;
	}
}
