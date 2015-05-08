using UnityEngine;
using System.Collections;

public class ScannerInfoLevel7 : MonoBehaviour 
{

	public bool guiEnabeled = true;
	private string info = "If you want to iterate over a collection of items or simply iterate over a " +
		"range of values, then the for loop is one of the way to acomplish this. In Java, the for loop has" +
			"the following structure:" +
			"\n\n\n for(start value; end expresion; increment){" +
			"\n\tstatements;" +
			"\n}" +
			"\n\nThe start value is thre espression where your for loop will start for example, int i = 0," +
			"will begin your for loop at index 0. The end expresion is a boolean expression that terminantes the " +
			"for loop. For example, i < 10, will terminate the for loop when i reached the value 9. The increment expression " +
			"will either increment or decrement your start value everytime the for loop goes throught your statements. For example, " +
			"i++, will increments i by 1 every time the for loop goes through your statemens. In the statements section, is where you" +
			"place the statments or collection the for looop will iterate over." +
			"\n\n\n\n\nPress H to continue";
	// Use this for initialization
	void Start()
	{
		Screen.showCursor = false;
		GameObject.Find("Main Camera").GetComponent<MouseLook>().enabled = false;
		//GameObject.Find("First Person Controller").GetComponent<Player>().enabled = false;
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
		//GameObject.Find("First Person Controller").GetComponent<Player>().enabled = true;
		GameObject.Find("First Person Controller").GetComponent<MouseLook>().enabled = true;
		GameObject.Find("Initialization").GetComponent<CursorTime>().enabled = true;
		GameObject.Find ("Robo_Arm10").GetComponent<ArmAnimation2> ().enabled = true;
		GameObject.Find("First Person Controller").GetComponent<CharacterMotor>().enabled = true;
		GameObject.Find("Initialization").GetComponent<CursorTime>().showCursor = true;
	}
}
