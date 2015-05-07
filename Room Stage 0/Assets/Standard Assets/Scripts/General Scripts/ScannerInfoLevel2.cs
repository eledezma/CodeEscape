using UnityEngine;
using System.Collections;

public class ScannerInfoLevel2 : MonoBehaviour
{
    public bool guiEnabeled = true;
	private string info = "Indenting is used to make your code more readable." +
		"\nHaving the correct indentation makes it easier to debug your code if a bug appears." +
			"\nThey also make your code look professional and not messy. So make life easier" +
			"\n for the person that is going to read your code and indent it correctly." +
			"\n\n\n\n\nPress E to continue";

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
		//GameObject.Find("First Person Controller").GetComponent<Level10Health>().enabled = true;
		GameObject.Find("First Person Controller").GetComponent<MouseLook>().enabled = true;
		GameObject.Find("Initialization").GetComponent<CursorTime>().enabled = true;
		GameObject.Find ("Robo_Arm10").GetComponent<ArmAnimation2> ().enabled = true;
		GameObject.Find("First Person Controller").GetComponent<CharacterMotor>().enabled = true;
	}
}

