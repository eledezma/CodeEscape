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

		if (other.gameObject.tag == "Player") {
			//play video
			audio.PlayOneShot(clip1, 1);
		}

	}

	IEnumerator fall(){
		yield return new WaitForSeconds (2);
		drop = true;
		audio.PlayOneShot(clip2, 1);
		yield return new WaitForSeconds (5);
		transform.position = new Vector3(-29.58626F, 1.345127F, -141.5573F);
		transform.Rotate(new Vector3(90,0,0));
		drop = false;
		cam.depth = -1;
	}
}
