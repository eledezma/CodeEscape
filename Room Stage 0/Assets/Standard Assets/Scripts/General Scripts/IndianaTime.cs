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
		GameObject.Find ("Object").GetComponent<Rollinrollinrollin>().roll = true;
	}
}
