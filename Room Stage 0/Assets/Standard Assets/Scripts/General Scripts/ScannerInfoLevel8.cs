using UnityEngine;
using System.Collections;

public class ScannerInfoLevel8 : MonoBehaviour 
{
	public bool guiEnabeled = true;
	private string info ="Arrays are containers that hold a fixed number of values of a single type. The length of" +
		" the array is assigned when the aray is created, and the length is fixed one created. Each item in the array is called an" +
			" element and it can be accessed with their numerical index. The index ranges from a value of 0 to n-1, where n " +
			" is the number of items. This means that the first item will be in index 0 and the nth item will be in index n-1. In Java, there" +
			"  an Array Class that can help get useful information about arrays, or manipulate arrays. For example the length method would tell you the " +
			" the size if the array and the copyFromRange method lets you copy item from a certain range."+
			"\n\nPress E to continue...";

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
		GUI.skin.label.fontSize = 16;
		if (guiEnabeled)
		{
			GUI.Box(new Rect(0, 0, Screen.width, Screen.height), "");
			GUI.Box(new Rect(0, 0, Screen.width, Screen.height), "");
			GUI.Label(new Rect(Screen.width * 0.45f, Screen.height * 0.01f, Screen.width * 0.1f, Screen.height * 0.05f),"Arrays");
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
