using UnityEngine;
using System.Collections;

public class ScannerInfoLevel10: MonoBehaviour 
{

	public bool guiEnabeled = true;
	private string info = "This is it, it's the final level of the game!! If you want to get the guy who" +
		"took your arms, this is the time. Go to the room and answer at least 7 out of the 10 questions about the" +
			"previous levels. I hope you were paying attention to what you did in the previous levels, it all comes down " +
			"to the next quiz. Be careful, and answer the quiz correctly, there's a cost if you answer a question" +
			" wrong." +
			"\n\n\n\n\nPress H to continue";
	// Use this for initialization
	void Start()
	{
		Screen.showCursor = false;
		GameObject.Find("Main Camera").GetComponent<MouseLook>().enabled = false;
		GameObject.Find("First Person Controller").GetComponent<Level10Health>().enabled = false;
		GameObject.Find("First Person Controller").GetComponent<MouseLook>().enabled = false;
		GameObject.Find("Initialization").GetComponent<CursorTime>().enabled = false;
		GameObject.Find("First Person Controller").GetComponent<CharacterMotor>().enabled = false;
		GameObject.Find("First Person Controller/Main Camera/Robo_Arm10").GetComponent<ArmAnimation2>().enabled = false;
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

				GameObject.Find ("First Person Controller").GetComponent<Level10Health> ().guiEnabled = false;
				
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
			GUI.Box(new Rect(0, 0, Screen.width, Screen.height), "");
			GUI.Label(new Rect(Screen.width * 0.45f, Screen.height * 0.01f, Screen.width * 0.1f, Screen.height * 0.05f),"Info");
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
		GameObject.Find("Initialization").GetComponent<CursorTime>().showCursor = true;
		GameObject.Find("Main Camera").GetComponent<MouseLook>().enabled = true;
		GameObject.Find("First Person Controller").GetComponent<Level10Health>().enabled = true;
		GameObject.Find("First Person Controller").GetComponent<MouseLook>().enabled = true;
		GameObject.Find("Initialization").GetComponent<CursorTime>().enabled = true;
		GameObject.Find ("First Person Controller/Main Camera/Robo_Arm10").GetComponent<ArmAnimation2> ().enabled = true;
		GameObject.Find("First Person Controller").GetComponent<CharacterMotor>().enabled = true;
	}
}
