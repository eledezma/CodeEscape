using UnityEngine;
using System.Collections;

public class ScannerInfoLevel3 : MonoBehaviour 
{

	public bool guiEnabeled = true;
	private string info = "Ints and doubles are two out of the eight primitive types, supported in Java." +
		"\nInts are a 32-bit signed two's complements integer, which just means that it can range from a" +
			"\n minimum value of -2^31 to a maximum value of ((2^31)-1). Ints are also used to represent whole numbers" +
			"\nwith no decimal places. Doubles are double precision 64-bit floating point. Doubles are used to" +
			"\n represent whole numbers followed by decimal values in Java." +
			"\n\n\n\n\nPress E to coninue";
	// Use this for initialization
	void Start()
	{
		Screen.showCursor = false;
		GameObject.Find("Main Camera").GetComponent<MouseLook>().enabled = false;
		GameObject.Find("First Person Controller").GetComponent<Player>().enabled = false;
		GameObject.Find("First Person Controller").GetComponent<MouseLook>().enabled = false;
		GameObject.Find("Initialization").GetComponent<CursorTime>().enabled = false;
		GameObject.Find("First Person Controller").GetComponent<CharacterMotor>().enabled = false;
		GameObject.Find("Robo_Arm10").GetComponent<ArmAnimation2>().enabled = false;
	}
	
	// Update is called once per frame
	void Update()
	{
		
	}
	public void OnGUI()
	{
		if (guiEnabeled)
		{
			GUILayout.Box("Info");
			GUILayout.TextArea(info);
			//if(GUILayout.Button("Submit")){
			if (Input.GetKeyDown("e"))
			{
				resume();
				//CursorTime.showCursor = false;
			}
		}
	}
	public void resume()
	{
		Time.timeScale = 1.0f;
		guiEnabeled = false;
		Screen.showCursor = true;
		GameObject.Find("Main Camera").GetComponent<MouseLook>().enabled = true;
		GameObject.Find("First Person Controller").GetComponent<Player>().enabled = true;
		GameObject.Find("First Person Controller").GetComponent<MouseLook>().enabled = true;
		GameObject.Find("Initialization").GetComponent<CursorTime>().enabled = true;
		GameObject.Find ("Robo_Arm10").GetComponent<ArmAnimation2> ().enabled = true;
		GameObject.Find("First Person Controller").GetComponent<CharacterMotor>().enabled = true;
	}
}
