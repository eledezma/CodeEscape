﻿using UnityEngine;
using System.Collections;

public class ColliderForSpider : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

	}

	void OnTriggerEnter(Collider other) {
		//Destroy(other.gameObject);
		if (other.gameObject.tag == "Spidey")
		{
			Debug.Log ("Dr Octopus");
			GameObject.Find("SPIDER").GetComponent<Enemy>().pushedBack = false;
		}

	}
}
