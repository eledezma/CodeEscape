using UnityEngine;
using System.Collections;

public class ColliderForSpider : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

	}

	void OnTriggerEnter(Collider other) {

		if (other.gameObject.tag == "Spidey")             // if spider hit wall, turn pushedBack to false to resume chasing
		{
			GameObject.Find("SPIDER").GetComponent<Enemy>().PushedBack = false;
		}

	}
}
