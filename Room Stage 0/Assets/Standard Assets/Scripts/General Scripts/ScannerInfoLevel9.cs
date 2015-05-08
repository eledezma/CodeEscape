using UnityEngine;
using System.Collections;

public class ScannerInfoLevel9 : MonoBehaviour 
{

	public bool guiEnabeled = true;
	private string info = "Classes can be used to make objects and give them properties or characteristics. " +
		"Public variables can be acessed and changed freely by other classes while private variables can " +
			"only be acessed by the class that they are decleared in. Constructors are used to instantiate the class/object. " +
			"Set methods are used to change the private variables " +
			"through the class and get methods are used to access the variables. For example:" +
			"\n\nPublic class Name{" +
			"\n\tprivate name;" +
			"\n\tpublic Name(n){" +
			"\n\t\tname = n;" +
			"\n\t}" +
			"\n\tpublic setName(cool){" +
			"\n\t\tname = cool;" +
			"\n\t}" +
			"\n\tpublic getName(){" +
			"\n\t\treturn name;" +
			"\n\t}" +
			"\n}" +
			"\n\n In this example, Name(n) is the constructor, and will set the variable name to n. SetName will change the name " +
			"variable to the value of cool. The getName method will simply return the value of name." +
			"\n\n\n\n\nPress H to continue...";
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
		if (guiEnabeled) {
			GUI.Box (new Rect (0, 0, Screen.width, Screen.height), "");
			GUI.Label (new Rect (Screen.width * 0.45f, Screen.height * 0.01f, Screen.width * 0.1f, Screen.height * 0.05f), "Info");
			GUI.Label (new Rect (Screen.width * 0.1f, Screen.height * 0.1f, Screen.width * 0.8f, Screen.height * 0.8f), info);
		//	if (Input.GetKeyDown ("h")) {
		//		resume ();
		//	}
		//} else {

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
