using UnityEngine;
using System.Collections;

public class ScannerInfoLevel1 : MonoBehaviour 
{

	public bool guiEnabeled = true;
	private string info = "If you want to print data to the screen, two of the methods available" +
						  "\nin java are the System.out.print() and System.out.println(). If you use the print() method it will " +
						  "\nprint the variables with out making a new line. For example:" +
			"\n\n\t int i = 1;" +
			"\n\tSystem.out.print("+"This is a example using the number: "+");"+
			"\n\tSystem.out.print(i);" +
			"\n\nThe output for this example will be" +
			"\nThis is a example using the number: 1" +
			"\n\nIf we use the prinln() method our output will be different, for example:" +
			"\n\n\t int i = 1;" +
			"\n\tSysytem.out.println("+"This is a example using the number: "+");" +
			"\n\tSystem.out.println(i);" +
			"\n\nThe output for this example will be " +
			"\nThis is a example using the number:" +
			"\n1" +
			"\n\n\n\nPress E to continue";
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
