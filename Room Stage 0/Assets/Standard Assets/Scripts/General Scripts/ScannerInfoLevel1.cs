using UnityEngine;
using System.Collections;

public class ScannerInfoLevel1 : MonoBehaviour 
{
	public bool guiEnabeled = true;
	private string info = "When you first start learning a programming language, the first program you learn to write is " +
						  "the \"Hello World\" program. Which displays the words hello world on the screen.\n\n"+
						  "If you want to print data to the screen, two of the methods available " +
						  "in java are the System.out.print() and System.out.println(). If you use the print() method it will " +
						  "print the variables with out making a new line. For example:" +

			"\n\tSystem.out.print("+"This is a example using the number: "+");"+
			"\n\tSystem.out.print(\"Java\");" +
			"\n\nThe output for this example will be" +
			"\nThis is a example using the number: Java" +
			"\n\nIf we use the prinln() method our output will be different, for example:"+
			"\n\tSysytem.out.println("+"This is a example using the number: "+");" +
			"\n\tSystem.out.println(\"Java\");" +
			"\n\nThe output for this example will be " +
			"\nThis is a example using the number:" +
			"\nJava" +
			"\n\n\n\nPress H to continue ... ";
			
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
			GUI.Box(new Rect(0, 0, Screen.width, Screen.height), "");
			GUI.Label(new Rect(Screen.width * 0.45f, Screen.height * 0.01f, Screen.width * 0.1f, Screen.height * 0.05f),"Hello World");
			GUI.Label(new Rect(Screen.width * 0.1f, Screen.height * 0.1f, Screen.width * 0.8f, Screen.height * 0.8f),info);
			//if (Input.GetKeyDown("e"))
			//{
				//resume();
			//}
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
		GameObject.Find("Initialization").GetComponent<CursorTime>().showCursor = true;

	}
}
