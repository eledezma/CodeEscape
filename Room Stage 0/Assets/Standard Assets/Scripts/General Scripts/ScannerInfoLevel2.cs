using UnityEngine;
using System.Collections;

public class ScannerInfoLevel2 : MonoBehaviour
{
    public bool guiEnabeled = true;
	private string info = "Indetaion is structering the code to make it more readable. " +
		    "The basic indentation convention is that every line that has an open brace, it's matching closing brace needs "+
			"to be aligned with the line that has the open brace. Every line in between the open and closed braces need to be tabbed. "+
			"\n\nExample of well indented code: "+
			"\npublic void method(){" +
			"\n\tcode;"+
			"\n\tif(something){"+
			"\n\t\tcode;"+
			"\n\t\tcode;"+
			"\n\t}"+
			"\n}"+
			"\n\nIndenting is used to make your code more readable." +
			"Having the correct indentation makes it easier to debug your code if a bug appears. " +
			"They also make your code look professional and not messy. So make life easier" +
			" for yourself and for the person that is going to read your code and indent it correctly." +
			"\n\n\n\nJumping is disabled in this level. Press H to continue";

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
			GUI.Box(new Rect(0, 0, Screen.width, Screen.height), "");
			GUI.Label(new Rect(Screen.width * 0.45f, Screen.height * 0.01f, Screen.width * 0.1f, Screen.height * 0.05f),"Indentation");
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

