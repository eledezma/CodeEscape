using UnityEngine;
using System.Collections;

public class ButtonTrigger : MonoBehaviour {

	public GameObject button;
	public GameObject door; //Abel's Door
	public AnimationClip PushDown;
	public AnimationClip PushUp;
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	IEnumerator OnTriggerEnter (Collider other){
		
		if (other.gameObject.tag == "Player"){
			if (button.animation.isPlaying)
				yield return new WaitForSeconds (0.5f);
			Debug.Log("Object Entered the trigger");
			button.animation.Play (PushDown.name);
		}
		
		
	}

	IEnumerator OnTriggerExit (Collider other){
		
		if (other.gameObject.tag == "Player"){
			if (button.animation.isPlaying)
				yield return new WaitForSeconds (0.5f);
			Debug.Log("Object Exited the trigger");	
			button.animation.Play (PushUp.name);
		}
	}	
}

