using UnityEngine;
using System.Collections;

public class Level10Video : MonoBehaviour {

	public Camera cam;
	public AudioClip scary;
	MovieTexture movie;

	// Use this for initialization
	void Start()
	{
		movie = renderer.material.mainTexture as MovieTexture;
		StartCoroutine(Initial());
	}
	
	// Update is called once per frame
	void Update()
	{
		
	}
	
	IEnumerator Initial()
	{
		movie.Play();
		audio.Play();
		yield return new WaitForSeconds(0.2F);
		movie.Pause();
		audio.Pause();
	}
	
	public IEnumerator PlayVideo()
	{
		GameObject.Find ("First Person Controller").GetComponent<Level10Health> ().guiEnabled = false;
		cam.depth = 2;
		GameObject.Find("Initialization").GetComponent<AudioSource>().audio.Stop();
		GameObject.Find("Initialization").GetComponent<CursorTime>().showCursor = false;
		GameObject.Find("Initialization").GetComponent<AudioSource>().volume = 1;
		Screen.lockCursor = true;
		//Screen.showCursor = false;
		//GameObject.Find("Main Camera").GetComponent<MouseLook>().enabled = false;
		//GameObject.Find("First Person Controller").GetComponent<MouseLook>().enabled = false;
		movie = renderer.material.mainTexture as MovieTexture;
		audio.clip = movie.audioClip;
		audio.Play();
		movie.Play();
		yield return new WaitForSeconds(audio.clip.length);
		movie.Stop();
		movie.Play();
		audio.Play();
		yield return new WaitForSeconds(0.2F);
		movie.Pause();
		audio.Pause();
		Screen.lockCursor = false;
		GameObject.Find("Initialization").GetComponent<AudioSource>().audio.clip = scary;
		GameObject.Find("Initialization").GetComponent<AudioSource>().audio.Play ();
		GameObject.Find("Initialization").GetComponent<CursorTime>().showCursor = true;
		cam.depth = -2;
		GameObject.Find ("First Person Controller").GetComponent<Level10Health> ().guiEnabled = true;
		//Application.LoadLevel(Application.loadedLevel);
	}
}
