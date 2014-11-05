using UnityEngine;
using System.Collections;

public class BlockRotate : MonoBehaviour {

	public bool rot;
	public bool delay;
	public bool loaded;
	private bool wasLoaded;
	public GameObject dice;
	// Use this for initialization

	void Start(){
		wasLoaded = false;
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
		//yield return new WaitForSeconds (10f);
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
		if (loaded)
			StartCoroutine (Get6 ());
		else if (!loaded && wasLoaded)
			GameObject.Find ("ButtonTrigger").GetComponent<ButtonTriggerStage4> ().PushItUp ();
	}
	
	
	IEnumerator Get6(){	
		while (dice.GetComponent<Die_d6>().value != 6) {
			int sw = Random.Range (1, 5);
			switch (sw) {
			case 1: 
				transform.Rotate (new Vector3 (90, 0, 0));
				break;
			case 2: 
				transform.Rotate (new Vector3 (-90, 0, 0));
				break;
			case 3: 
				transform.Rotate (new Vector3 (0, 90, 0));
				break;
			case 4: 
				transform.Rotate (new Vector3 (0, -90, 0));
				break;
			}
			
			yield return new WaitForSeconds (0.5f);
			Debug.Log("Wait for 0.5 seconds");
			
		}
		wasLoaded = true;
		GameObject.Find ("ButtonTrigger").GetComponent<ButtonTriggerStage4> ().PushItUp ();

	}
}