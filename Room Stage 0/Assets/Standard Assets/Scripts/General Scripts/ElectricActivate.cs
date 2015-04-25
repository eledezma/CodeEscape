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

		if (Input.GetKeyDown (KeyCode.Y))
		{
			GameObject.Find("DoorInitial").transform.position = new Vector3(-29.59206F, 15.04549F, 111.5887F);
			GameObject.Find("DoorInitial").transform.Rotate (new Vector3(0,270,0));
		}

	}

	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "Player")
		{
			Debug.Log ("agagad");
			GameObject.Find("First Person Controller").GetComponent<Level10Health>().guiEnabled = false;
			cam.depth = 2;
			GameObject.Find("DoorInitial").transform.position = new Vector3(-29.59206F, 15.04549F, 111.5887F);
			GameObject.Find("DoorInitial").transform.Rotate (new Vector3(0,270,0));
			GameObject.Find("MAX").GetComponent<TimetoFly>().enabled = true;
			GameObject.Find("MAXCAM").GetComponent<TimetoFly>().enabled = true;
			GameObject.Find("Initialization").GetComponent<CursorTime>().showCursor = false;
			Screen.lockCursor = true;
			GameObject.Find("Main Camera").GetComponent<MouseLook>().enabled = false;
			GameObject.Find("First Person Controller").GetComponent<MouseLook>().enabled = false;
			GameObject.Find("First Person Controller").GetComponent<CharacterMotor>().canControl = false;
			Destroy (this);
		}





	}
}
