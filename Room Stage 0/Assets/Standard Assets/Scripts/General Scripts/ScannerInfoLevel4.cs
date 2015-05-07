using UnityEngine;
using System.Collections;

public class ScannerInfoLevel4 : MonoBehaviour 
{

	public bool guiEnabeled = true;
	private string info = "The Scanner class is part of the java.util package. Scanner's in java are used to get user input to be used" +
		"\n by the program, but this is not their only functions. Scanners are also used to read data from small text files, but" +
			"\n if you need to read from a big files, it's better to use one of the other method available.The method nextLine()" +
			"\n is part of the Scanner class and is used to get the next line the user enters as the input. It can also be used to" +
			"\n read the next line. Scanners can read specific values like Ints and Doubles and you can also give it a certain Delimiter" +
			"\npatern and it will tokenize the string based on the pattern." +
			"\n\nIf you want to use a scanner you will have to first have to create a Scanner variable and extantiate the Scanner Object" +
			"\nFor Example:" +
			"\nScanner scan;" +
			"\n\nThis will make a Scanner variable but it doesn't extantiate the Scanner object yet. In order to extantiate the Scanner" +
			"\nObject you have to make a new Scanner. For Example:" +
			"\n\nscan = new Scanner(System.in);" +
			"\n\nafter this is done you can now start to read the input from the user by using the nextLine() method like this" +
			"\n\nscan.nextLine();" +
			"\n\n\n\n\nPress E to continue";

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
		GameObject.Find("Robo_Arm10").GetComponent<ArmAnimation2>().enabled = true;
		GameObject.Find("First Person Controller").GetComponent<MouseLook>().enabled = true;
		GameObject.Find("Initialization").GetComponent<CursorTime>().enabled = true;
		GameObject.Find("First Person Controller").GetComponent<MakeOrder>().enabled = true;
		GameObject.Find("First Person Controller").GetComponent<scannerUi>().enabled = true;
		GameObject.Find("Wall_Jack_S2").GetComponent<ToolTipTxt>().enabled = true;
		GameObject.Find("Terminal_Stage2").GetComponent<ToolTipTxt>().enabled = true;
		GameObject.Find("First Person Controller").GetComponent<CharacterMotor>().enabled = true;
	}
}