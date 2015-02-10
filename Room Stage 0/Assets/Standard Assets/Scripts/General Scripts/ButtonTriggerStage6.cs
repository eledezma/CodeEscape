﻿using UnityEngine;
using System.Collections;

public class ButtonTriggerStage6 : MonoBehaviour {

	public AudioClip ButtonClick;
	public GameObject button;
	public GameObject turret;
	public AnimationClip PushDown;
	public AnimationClip PushUp;
	public bool buttondown;
	public int max;
	string objectName;
	
	// Use this for initialization
	void Start () {
		buttondown = false;
		objectName = this.gameObject.name;
		max = 1;
	}
	
	// Update is called once per frame
	void Update () {;
	}
	
	IEnumerator OnTriggerEnter (Collider other){
		if (other.gameObject.tag == "Player" && !buttondown && !turret.GetComponent<TurretTurn>().turretActive){
			turret.GetComponent<TurretTurn>().turretActive = true;
			buttondown = true;
			if (button.animation.isPlaying)
				yield return new WaitForSeconds (0.5f);
			audio.PlayOneShot(ButtonClick);
			button.animation.Play (PushDown.name);
			if (objectName == "ResetTrigger")
				turret.GetComponent<TurretTurn>().reset = true;
			else{
				for (int i = 0; i < max; i++){
					StartCoroutine (turret.GetComponentInChildren<TurretShoot>().shoot(i+1));
					float wait = (i+1) * 0.5f + 1.5f;
					yield return new WaitForSeconds(wait);
				}
			}
			button.animation.Play (PushUp.name);
			buttondown = false;
			yield return new WaitForSeconds (1f);
			turret.GetComponent<TurretTurn>().turretActive = false;
			
		}	
	}
	

	IEnumerator OnTriggerStay (Collider other){
		if (other.gameObject.tag == "Player" && !buttondown && !turret.GetComponent<TurretTurn>().turretActive){
			turret.GetComponent<TurretTurn>().turretActive = true;
			buttondown = true;
			if (button.animation.isPlaying)
				yield return new WaitForSeconds (0.5f);
			audio.PlayOneShot(ButtonClick);
			button.animation.Play (PushDown.name);
			if (objectName == "ResetTrigger")
				turret.GetComponent<TurretTurn>().reset = true;
			else{
				for (int i = 0; i < max; i++){
					StartCoroutine (turret.GetComponentInChildren<TurretShoot>().shoot(i+1));
					float wait = (i+1) * 0.5f + 1.5f;
					yield return new WaitForSeconds(wait);
				}
			}
			button.animation.Play (PushUp.name);
			buttondown = false;
			yield return new WaitForSeconds (1f);
			turret.GetComponent<TurretTurn>().turretActive = false;
			
		}	
	}
}
