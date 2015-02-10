using UnityEngine;
using System.Collections;

public class ButtonTriggerStage6 : MonoBehaviour {

	public AudioClip ButtonClick;
	public GameObject button;
	public GameObject turret;
	public AnimationClip PushDown;
	public AnimationClip PushUp;
	public bool buttondown;
	string objectName;
	
	// Use this for initialization
	void Start () {
		buttondown = false;
		objectName = this.gameObject.name;
	}
	
	// Update is called once per frame
	void Update () {;
	}
	
	IEnumerator OnTriggerEnter (Collider other){
		
		if (other.gameObject.tag == "Player" && !buttondown){
			buttondown = true;
			if (button.animation.isPlaying)
				yield return new WaitForSeconds (0.5f);
			audio.PlayOneShot(ButtonClick);
			if (objectName == "ResetTrigger")
				turret.GetComponent<TurretTurn>().reset = true;
			else
				turret.GetComponent<TurretTurn>().turn = true;
			button.animation.Play (PushDown.name);
			yield return new WaitForSeconds (1f);
			button.animation.Play (PushUp.name);
			buttondown = false;
			yield return new WaitForSeconds (1f);
		}	
	}
	
	IEnumerator OnTriggerStay (Collider other){
		if (other.gameObject.tag == "Player" && !buttondown){
			buttondown = true;
			if (button.animation.isPlaying)
				yield return new WaitForSeconds (0.5f);
			audio.PlayOneShot(ButtonClick);
			if (objectName == "ResetTrigger")
				turret.GetComponent<TurretTurn>().reset = true;
			else
				turret.GetComponent<TurretTurn>().turn = true;
			button.animation.Play (PushDown.name);
			yield return new WaitForSeconds (1f);
			button.animation.Play (PushUp.name);
			buttondown = false;
			yield return new WaitForSeconds (1f);
		}
		
	}
}
