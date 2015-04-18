using UnityEngine;
using System.Collections;

public class ThumbsTrigger : MonoBehaviour {

	// Use this for initialization
	void Start ()
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "Player")
		{
			StartCoroutine(GameObject.Find("ThumbsUp").GetComponent<MKPlay>().PlayVideo());
		}
	}
}
