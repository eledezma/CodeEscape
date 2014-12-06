using UnityEngine;
using System.Collections;

public class Timer : MonoBehaviour {
	
	
	float timer = 10.0f;
	public AudioClip suck;
	public AudioClip cough;
	bool guiPlay;

	void Start(){
		guiPlay = true;
		audio.clip = cough;
		audio.loop = true;
		audio.Play ();
	}
	
	void  Update (){
		timer -= Time.deltaTime;
		//Debug.Log (timer);
		if(timer < 0.0F){
			guiPlay = false;
			timer = 5000.0F;
			StartCoroutine(LoadLevel ());
		}

	}

	IEnumerator LoadLevel(){
		GameObject.Find ("Initialization").audio.Stop ();
		audio.clip = suck;
		audio.Play ();
		yield return new WaitForSeconds (audio.clip.length);
		Application.LoadLevel (3);
	}
	
	void  OnGUI (){

		if (guiPlay)
			GUI.Box(new Rect(650, 40, 80, 40), "" + timer.ToString("0"));
	}

}