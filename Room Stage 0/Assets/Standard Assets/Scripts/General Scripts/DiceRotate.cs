using UnityEngine;
using System.Collections;

public class DiceRotate : MonoBehaviour {

	public bool rot;
	public bool delay;
	//public GameObject dice;
	// Use this for initialization

	void Start(){
	}
	
	void Update(){
		if(rot) {
			RandomTime ();
		}
		
		if (delay){
			StartCoroutine (DelayTime ());
			delay = false;
		}

	}
	
	void RandomTime()
	{
		int sw = Random.Range (1, 5);
		switch (sw)
		{
		case 1: 
			transform.Rotate(new Vector3 (90, 0, 0));
			break;
		case 2: 
			transform.Rotate(new Vector3 (-90, 0, 0));
			break;
		case 3: 
			transform.Rotate(new Vector3 (0, 90, 0));
			break;
		case 4: 
			transform.Rotate(new Vector3 (0, -90, 0));
			break;
		}
		
		
	}
	
	IEnumerator DelayTime(){
		yield return new WaitForSeconds (5f);
		rot = false;
	}
}