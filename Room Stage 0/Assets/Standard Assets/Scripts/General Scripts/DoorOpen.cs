using UnityEngine;
using System.Collections;

public class DoorOpen : MonoBehaviour {

	public AnimationClip doorOpen;
	public bool open = false; //needs to start off as false
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		if (open){
			animation.Play (doorOpen.name);
			open = false;
		}
	}
}
