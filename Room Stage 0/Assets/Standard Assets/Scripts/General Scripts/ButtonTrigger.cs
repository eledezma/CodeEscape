using UnityEngine;
using System.Collections;

public class ButtonTrigger : MonoBehaviour {

	public AudioClip ButtonClick;
	public GameObject button;
	public bool puzzleComplete = false; //needs to start off as false
	public AnimationClip PushDown;
	public AnimationClip PushUp;
	
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	IEnumerator OnTriggerEnter (Collider other){

		if (puzzleComplete)	{
			if (other.gameObject.tag == "Player"){
				if (button.animation.isPlaying)
					yield return new WaitForSeconds (0.5f);
				//Debug.Log("Object Entered the trigger");
				audio.PlayOneShot(ButtonClick);
				button.animation.Play (PushDown.name);
			}
			puzzleComplete = false;
			GameObject.Find("Door").GetComponent<DoorOpen>().open = true;
		}
		
	}

	/*IEnumerator OnTriggerExit (Collider other){  //for button pushing down which we don't need
		
		if (other.gameObject.tag == "Player"){
			if (button.animation.isPlaying)
				yield return new WaitForSeconds (0.5f);
			//Debug.Log("Object Exited the trigger");	
			button.animation.Play (PushUp.name);
		}
	}*/	
}
