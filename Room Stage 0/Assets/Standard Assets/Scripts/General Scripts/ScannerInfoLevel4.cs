using UnityEngine;
using System.Collections;

public class ScannerInfoLevel4 : MonoBehaviour 
{

	public bool guiEnabeled = true;
	private string info = "The Scanner class is part of the java.util package. Scanner's in java are used to get user input to be used" +
		" by the program, but this is not their only purpose. Scanners are also used to read data from small text files, but" +
			" if you need to read from a big files, it's better to use one of the other method available.The method nextLine()" +
			" is part of the Scanner class and is used to get the next line the user enters as the input. It can also be used to" +
			" read the next line. Scanners can read specific values like Ints and Doubles and you can also give it a certain Delimiter" +
			" patern and it will tokenize the string based on the pattern." +
			"\n\nIf you want to use a scanner you will have to first have to create a Scanner variable and extantiate the Scanner Object" +
			"\nFor Example:" +
			"\nScanner scan;" +
			"\nThis will make a Scanner variable but it doesn't Instantiate the Scanner object yet.\n\n In order to Instantiate the Scanner" +
			" object you have to make a new Scanner. For Example:" +
			"\n\nscan = new Scanner(System.in);" +
			"\nAfter this is done you can now start to read the input from the user by using the nextLine() method like this" +
			"\n\nscan.nextLine();" +
			"\n\n\n\n\nPress H to continue";

	void Start()
	{
		Screen.showCursor = false;
		GameObject.Find("Main Camera").GetComponent<MouseLook>().enabled = false;
		GameObject.Find("First Person Controller").GetComponent<MouseLook>().enabled = false;
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
		Screen.showCursor = true;
		GameObject.Find("Main Camera").GetComponent<MouseLook>().enabled = true;
		GameObject.Find("Robo_Arm10").GetComponent<ArmAnimation2>().enabled = true;
		GameObject.Find("First Person Controller").GetComponent<MouseLook>().enabled = true;
		GameObject.Find("Initialization").GetComponent<CursorTime>().enabled = true;
		GameObject.Find("First Person Controller").GetComponent<MakeOrder>().enabled = true;
		GameObject.Find("First Person Controller").GetComponent<scannerUi>().enabled = true;
		GameObject.Find("Wall_Jack_S2").GetComponent<ToolTipTxt>().enabled = true;
		GameObject.Find("Terminal_Stage2").GetComponent<ToolTipTxt>().enabled = true;
		GameObject.Find("First Person Controller").GetComponent<CharacterMotor>().enabled = true;
		GameObject.Find("Initialization").GetComponent<CursorTime>().showCursor = true;
	}
}