using UnityEngine;
using System.Collections;

[RequireComponent (typeof(AudioSource))]

public class IndianaTime : MonoBehaviour {

	public bool playVideo;
	public Camera cam;
	MovieTexture movie;
	// Use this for initialization
	void Start () {
		playVideo = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (playVideo) {
			playVideo = false;
			cam.depth = 1;
			GameObject.Find ("Main Camera").GetComponent<MouseLook>().enabled = false;
			GameObject.Find ("First Person Controller").GetComponent<MouseLook>().enabled = false;
			GameObject.Find ("First Person Controller").GetComponent<CharacterMotor>().canControl = false;
			GameObject.Find ("First Person Controller").transform.rotation = Quaternion.Euler(-10, 180, 0);
			movie = renderer.material.mainTexture as MovieTexture;
			StartCoroutine (Playback ());
		}
	}

	IEnumerator Playback(){
		audio.clip = movie.audioClip;
		audio.Play ();
		movie.Play ();
		yield return new WaitForSeconds (audio.clip.length); 
		GameObject.Find ("Initialization").GetComponent<AudioSource> ().audio.Play ();
		GameObject.Find ("Initialization").GetComponent<CursorTime> ().showCursor = true;
		cam.depth = -2;
		movie.Stop ();
		GameObject.Find ("Main Camera").GetComponent<MouseLook>().enabled = true;
		GameObject.Find ("First Person Controller").GetComponent<MouseLook>().enabled = true;
		GameObject.Find ("First Person Controller").GetComponent<CharacterMotor>().canControl = true;
		GameObject.Find ("Object").GetComponent<Rollinrollinrollin>().roll = true;
	}
}
