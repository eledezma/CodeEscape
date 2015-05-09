using UnityEngine;
using System.Collections;

public class ScannerInfoLevel3 : MonoBehaviour 
{
	Texture2D texture;
	public bool guiEnabeled = true;
	private string info = "Ints and doubles are two out of the eight primitive types, supported in Java." +
		" Ints are a 32-bit signed two's complements integer, which just means that it can range from a" +
			" minimum value of -2^31 to a maximum value of ((2^31)-1). Ints are also used to represent whole numbers" +
			" with no decimal places. Doubles are double precision 64-bit floating point. Doubles are used to" +
			" represent whole numbers followed by decimal values in Java." +
			"\n\nExamples of ints: 1, 4, 103, 888242"+
			"\nExamples of doubles: 1.0, 4.2, 103.5, 888242.23156"+

			"\n\n\n\n\nPress H to coninue...";
	// Use this for initialization
	void Start()
	{
		texture = new Texture2D(1, 1);
		Screen.showCursor = false;
		GameObject.Find("Main Camera").GetComponent<MouseLook>().enabled = false;
		GameObject.Find("First Person Controller").GetComponent<MouseLook>().enabled = false;
		GameObject.Find("Initialization").GetComponent<CursorTime>().enabled = false;
		GameObject.Find("First Person Controller").GetComponent<CharacterMotor>().enabled = false;
		GameObject.Find("Robo_Arm10").GetComponent<ArmAnimation2>().enabled = false;
	}
	
	// Update is called once per frame
	void Update()
	{
		if (Input.GetKeyDown ("h")) {
			if(guiEnabeled)
				resume ();
			else{
				guiEnabeled = true;
				GameObject.Find("First Person Controller").GetComponent<Player>().GuiEnabled = false;
				GameObject.Find("Main Camera").GetComponent<MouseLook>().enabled = false;
				GameObject.Find("First Person Controller").GetComponent<MouseLook>().enabled = false;
				GameObject.Find("First Person Controller").GetComponent<CharacterMotor>().enabled = false;
				GameObject.Find("Robo_Arm10").GetComponent<ArmAnimation2>().enabled = false;
				GameObject.Find("Initialization").GetComponent<CursorTime>().showCursor = false;
			}
		}
		
	}
	public void OnGUI()
	{
		GUI.skin.label.fontSize = 16;
		if (guiEnabeled)
		{

			GUI.Label(new Rect(Screen.width * 0.45f, Screen.height * 0.01f, Screen.width * 0.1f, Screen.height * 0.05f),"Ints and Doubles");
			GUI.Label(new Rect(Screen.width * 0.1f, Screen.height * 0.1f, Screen.width * 0.8f, Screen.height * 0.8f),info);
			//if (Input.GetKeyDown("e"))
			//{
				//resume();
			//}
			GUI.Box(new Rect(1, 1, Screen.width, Screen.height), "");
		//	GUI.Box(new Rect(0, 0, Screen.width, Screen.height), "");
		//	GUI.Box(new Rect(0, 0, Screen.width, Screen.height), "");
		}
	}
	public void resume()
	{
		Time.timeScale = 1.0f;
		guiEnabeled = false;
		Screen.showCursor = true;
		GameObject.Find("Main Camera").GetComponent<MouseLook>().enabled = true;
		GameObject.Find("First Person Controller").GetComponent<Player>().GuiEnabled = true;
		GameObject.Find("First Person Controller").GetComponent<MouseLook>().enabled = true;
		GameObject.Find("Initialization").GetComponent<CursorTime>().enabled = true;
		GameObject.Find ("Robo_Arm10").GetComponent<ArmAnimation2> ().enabled = true;
		GameObject.Find("First Person Controller").GetComponent<CharacterMotor>().enabled = true;
		GameObject.Find("Initialization").GetComponent<CursorTime>().showCursor = true;
	}
}
