using UnityEngine;
using System.Collections;

public class ScannerInfoLevel10: MonoBehaviour 
{

	public bool guiEnabeled = true;
	public string info = "The Scanner class is part of the java.util package." +
		"\nScanner's in java are used to get user input, but" +
			"\n that is not their only purpose. The method nextLine()" +
			"\n is part of the Scanner class and is used to get the " +
			"\n next line the user enters as the input.";
	// Use this for initialization
	void Start()
	{
		Screen.showCursor = false;
		GameObject.Find("Main Camera").GetComponent<MouseLook>().enabled = false;
		GameObject.Find("First Person Controller").GetComponent<Level10Health>().enabled = false;
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
		GameObject.Find("First Person Controller").GetComponent<Level10Health>().enabled = true;
		GameObject.Find("First Person Controller").GetComponent<MouseLook>().enabled = true;
		GameObject.Find("Initialization").GetComponent<CursorTime>().enabled = true;
		GameObject.Find ("Robo_Arm10").GetComponent<ArmAnimation2> ().enabled = true;
		GameObject.Find("First Person Controller").GetComponent<CharacterMotor>().enabled = true;
	}
}
