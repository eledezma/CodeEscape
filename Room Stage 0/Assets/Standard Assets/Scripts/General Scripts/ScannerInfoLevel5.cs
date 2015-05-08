using UnityEngine;
using System.Collections;

public class ScannerInfoLevel5 : MonoBehaviour 
{

	public bool guiEnabeled = true;
	private string info = "If you want your program to execute a certain part of the code only if a certain value is true, then the " +
		"If-Else statement is one of the ways that Java lets you do this. The If-Else Statement has the following structure:" +
			"\n\n if(boolean expression){" +
			"\n\tstatements;" +
			"\n}" +
			"\nelse{" +
			"\n\tstatements;" +
			"\n}" +
			"\n\nThe boolean expression will be the value or values, that your program will check if it's true. If this values is true" +
			"it will execute the statements inside the if statement. If the value is false then your program will execute the staments in" +
			"the else block. For example:" +
			"\n\nif(age>12 || age<20){" +
			"\n\tSystem.out.println("+"I am a teenager"+");" +
			"\n}" +
			"\nelse{" +
			"\n\tSystem.out.println(" +"I am not a teenager :(" + ");" +
			"\n}" +
			"\n\nIn this example the program will print out 'I am a teenager' only if the variable age is between 12 and 20. If the" +
			"age is not between 12 or 20 it will print out 'I am not a teenager'." +
			"\n\n\n\n\nPress H to continue";
	// Use this for initialization
	void Start()
	{
		Screen.showCursor = false;
		GameObject.Find("Main Camera").GetComponent<MouseLook>().enabled = false;
		//GameObject.Find("First Person Controller").GetComponent<Level10Health>().enabled = false;
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
				GameObject.Find("Main Camera").GetComponent<MouseLook>().enabled = false;
				GameObject.Find("First Person Controller").GetComponent<MouseLook>().enabled = false;
				GameObject.Find("First Person Controller").GetComponent<CharacterMotor>().enabled = false;
				guiEnabeled = true;
				GameObject.Find("Initialization").GetComponent<CursorTime>().showCursor = false;
				
			}
		}
	}
	public void OnGUI()
	{
		GUI.skin.label.fontSize = 16;
		if (guiEnabeled)
		{
			GUI.Box(new Rect(0, 0, Screen.width, Screen.height), "");
			GUI.Label(new Rect(Screen.width * 0.45f, Screen.height * 0.01f, Screen.width * 0.1f, Screen.height * 0.05f),"Info");
			GUI.Label(new Rect(Screen.width * 0.1f, Screen.height * 0.1f, Screen.width * 0.8f, Screen.height * 0.8f),info);
			if (Input.GetKeyDown("e"))
			{
				resume();
			}
		}
	}
	public void resume()
	{
		Time.timeScale = 1.0f;
		guiEnabeled = false;
		Screen.showCursor = true;
		GameObject.Find("Main Camera").GetComponent<MouseLook>().enabled = true;
		//GameObject.Find("First Person Controller").GetComponent<Level10Health>().enabled = true;
		GameObject.Find("First Person Controller").GetComponent<MouseLook>().enabled = true;
		GameObject.Find("Initialization").GetComponent<CursorTime>().enabled = true;
		GameObject.Find ("Robo_Arm10").GetComponent<ArmAnimation2> ().enabled = true;
		GameObject.Find("First Person Controller").GetComponent<CharacterMotor>().enabled = true;
	}
}
