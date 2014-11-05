using UnityEngine;
using System.Collections;

public class ButtonTriggerStage4 : MonoBehaviour {

	public AudioClip ButtonClick;
	public GameObject button;
	//public GameObject door; //Abel's Door
	public AnimationClip PushDown;
	public AnimationClip PushUp;
	//public bool k;
	private bool buttondown;
	
	// Use this for initialization
	void Start () {
		buttondown = false;
	}
	
	// Update is called once per frame
	void Update () {
		/*if (k)
			button.animation.Play (PushDown.name);*/
	}

	IEnumerator OnTriggerEnter (Collider other){
		
		if (other.gameObject.tag == "Player" && !buttondown){
			buttondown = true;
			if (button.animation.isPlaying)
				yield return new WaitForSeconds (0.5f);
			Debug.Log("Object Entered the trigger");
			audio.PlayOneShot(ButtonClick);
			button.animation.Play (PushDown.name);
			GameObject.Find ("d67").GetComponent<BlockRotate>().rot = true;
			GameObject.Find ("d67").GetComponent<BlockRotate>().delay = true;
			GameObject.Find ("d6").GetComponent<BlockRotate>().rot = true;
			GameObject.Find ("d6").GetComponent<BlockRotate>().delay = true;
			//yield return new WaitForSeconds (PushDown.length);
		}
		
		
	}

	public void PushItUp(){
		button.animation.Play (PushUp.name);
		Debug.Log ("PUSH ME UP");
		buttondown = false;


	}

	IEnumerator OnTriggerStay (Collider other){
		if (other.gameObject.tag == "Player" && !buttondown){
			buttondown = true;
			if (button.animation.isPlaying)
				yield return new WaitForSeconds (0.5f);
			Debug.Log("Object Stayed in the trigger");
			audio.PlayOneShot(ButtonClick);
			button.animation.Play (PushDown.name);
			GameObject.Find ("d67").GetComponent<BlockRotate>().rot = true;
			GameObject.Find ("d67").GetComponent<BlockRotate>().delay = true;
			GameObject.Find ("d6").GetComponent<BlockRotate>().rot = true;
			GameObject.Find ("d6").GetComponent<BlockRotate>().delay = true;
			//yield return new WaitForSeconds (PushDown.length);
		}

	}

	/*IEnumerator OnTriggerExit (Collider other){
		
		if (other.gameObject.tag == "Player"){
			if (button.animation.isPlaying)
				yield return new WaitForSeconds (0.5f);
			//Debug.Log("Object Exited the trigger");	
			button.animation.Play (PushUp.name);
		}
	}*/


}
