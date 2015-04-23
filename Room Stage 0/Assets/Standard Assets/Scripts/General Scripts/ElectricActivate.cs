using UnityEngine;
using System.Collections;

public class ElectricActivate : MonoBehaviour 
{
	public Camera cam;
	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		/*
		if (Input.GetKeyDown (KeyCode.Y))
		{
			cam.depth = 2;
			GameObject.Find("MAX").GetComponent<TimetoFly>().enabled = true;
			GameObject.Find("MAXCAM").GetComponent<TimetoFly>().enabled = true;
			GameObject.Find("Initialization").GetComponent<CursorTime>().showCursor = false;
			Screen.lockCursor = true;
			GameObject.Find("Main Camera").GetComponent<MouseLook>().enabled = false;
			GameObject.Find("First Person Controller").GetComponent<MouseLook>().enabled = false;
			GameObject.Find("First Person Controller").GetComponent<CharacterMotor>().canControl = false;
		}
		*/
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "Player")
		{
			cam.depth = 2;
			GameObject.Find("MAX").GetComponent<TimetoFly>().enabled = true;
			GameObject.Find("MAXCAM").GetComponent<TimetoFly>().enabled = true;
			GameObject.Find("Initialization").GetComponent<CursorTime>().showCursor = false;
			Screen.lockCursor = true;
			GameObject.Find("Main Camera").GetComponent<MouseLook>().enabled = false;
			GameObject.Find("First Person Controller").GetComponent<MouseLook>().enabled = false;
			GameObject.Find("First Person Controller").GetComponent<CharacterMotor>().canControl = false;
		}





	}
}
