using UnityEngine;
using System.Collections;

public class PlayerDice : MonoBehaviour {

	bool puzzle1Complete = false;
	bool guiEnabled = false;
	bool atWall = false;
	public AudioClip missionComplete;
	TextEditor editor;
	static string text="";
	public static string output="";
	public Texture2D cursorImage;
	int forStart;
	int forFinish;
	int value=0;
	bool showError = false;
	bool facesClicked= false;
	
	string errorString = "";
	string wrongValue = "Wrong value for die face.";
	
	//GameObject Arms;
	public string code = "public class game{\n" +
				"\tpublic static void main(String[] args){\n" +
				"\t\tint rolledNumber = (int)(Math.random() * 6 ) + 1;\n" +
				"\t\tswitch(rolledNumber){\n" +
				"\t\t\tcase 1:\n" +
				"\t\t\t\ttopFace = 1;\n" +
				"\t\t\tcase 2:\n" +
				"\t\t\t\ttopFace = 2;\n" +
				"\t\t\tcase 3:\n" +
				"\t\t\t\ttopFace = 3;\n" +
				"\t\t\tcase 4:\n" +
				"\t\t\t\ttopFace = 4;\n" +
				"\t\t\tcase 5:\n" +
				"\t\t\t\ttopFace = 5;\n" +
				"\t\t\tcase 6:\n" +
				"\t\t\t\ttopFace = 6;\n" +
				"\t\t}\n" +
				"\t\t\n" +
				"\t}\n" +
			"}";
	void OnTriggerEnter(Collider other){
		atWall=true;
		GameObject.Find("Arm Camera").camera.enabled = false;
		//Arms.camera.enabled = false;
	}
	void OnTriggerExit(Collider other){
		atWall=false;
		guiEnabled=false;
		//Arms.camera.enabled = true;
		GameObject.Find("Arm Camera").camera.enabled = true;
	}
	
	void Start(){ //I've commented this method out and nothing bad happens :o -Joseph
		Screen.lockCursor = true;
		//Screen.showCursor = false;
	}
	//Switches the GUI on and off
	//*******************************************************
	void Update()
	{
		///	if (atWall) {
		if (Input.GetKeyDown ("o")) {
			Screen.lockCursor = false;  //Cursor is free to move when user goes into terminal
			if (guiEnabled) {
				resume ();
			} else {
				GameObject.Find("Initialization").GetComponent<CursorTime>().showCursor=false;
				Time.timeScale = 0.0f;
				guiEnabled = true;
				GameObject.Find ("Main Camera").GetComponent<MouseLook> ().enabled = false;
				GameObject.Find ("First Person Controller").GetComponent<MouseLook> ().enabled = false;			
			}
		}
		//	} 
		else {
			//Screen.showCursor = false;
			//		Screen.lockCursor = true;  //Hiding Cursor means redoing the way the crosshair was implemented -Josephs
			//		Screen.lockCursor = false; //Cursor remains locked if not in terminal
		}
	}
	//*******************************************************
	
	
	//Includes all the GUI elements
	//*******************************************************
	public void OnGUI()
	{
		if (!atWall) {  //If not at wall terminal jack in - "show crosshair"
			Vector3 mPos = Input.mousePosition;
			GUI.DrawTexture (new Rect (mPos.x - 32, Screen.height - mPos.y - 32, 64, 64), cursorImage);
		} 
		
		else if (atWall && Input.GetKeyDown ("e")) { 
			
			//If at wall terminal show default cursor instead
		}
		
		if (guiEnabled) {
			GUI.Box (new Rect (0, 0, Screen.width, Screen.height), "List of Functions");
			
			if(showError)
			{
				GUI.Label ( new Rect ( Screen.width*0.4f,Screen.height*0.45f, Screen.width*0.3f,Screen.height*0.1f),errorString);
				if(GUI.Button (new Rect (Screen.width*0.47f,Screen.height*0.55f, Screen.width*0.06f,Screen.height*0.04f), "sorry"))
				{
					showError=false;
				}
			}
			GUI.TextArea (new Rect (Screen.width*0.2f, Screen.width*0.04f, Screen.width*0.75f, Screen.height*0.75f),code);
			
			if(showError)
			{
				GUI.Label ( new Rect ( Screen.width*0.4f,Screen.height*0.45f, Screen.width*0.3f,Screen.height*0.1f),errorString);
				if(GUI.Button (new Rect (Screen.width*0.47f,Screen.height*0.55f, Screen.width*0.06f,Screen.height*0.04f), "sorry"))
				{
					showError=false;
				}
			}
			
			editor = (TextEditor)GUIUtility.GetStateObject(typeof(TextEditor), GUIUtility.keyboardControl);
			
			GUI.Label(new Rect(500, 500, 200, 200), string.Format("Selected text: {0}\nPos: {1}\nSelect pos: {2}\nLines Before: {3}\nLines After: {4}",
			                                                      editor.SelectedText,
			                                                      editor.pos,
			                                                      0,
			                                                      countLinesBefore(code,editor.pos),
			                                                      countLinesAfter(code,editor.pos)));
			
			int temp;

			

			
			// Button that inserts the method that shoots a bullet
			if (GUI.Button (new Rect (Screen.width*0.02f, Screen.height*0.48f, Screen.width*0.1f, Screen.height*0.05f), "Cheat now!")) 
			{

					code = "public class game{\n" +
						"\tpublic static void main(String[] args){\n" +
							"\t\tint rolledNumber = (int)(Math.random() * 6 ) + 1;\n" +
							"\t\tswitch(rolledNumber){\n" +
							"\t\t\tcase 1:\n" +
							"\t\t\t\ttopFace = 1;\n" +
							"\t\t\tcase 2:\n" +
							"\t\t\t\ttopFace = 2;\n" +
							"\t\t\tcase 3:\n" +
							"\t\t\t\ttopFace = 3;\n" +
							"\t\t\tcase 4:\n" +
							"\t\t\t\ttopFace = 4;\n" +
							"\t\t\tcase 5:\n" +
							"\t\t\t\ttopFace = 5;\n" +
							"\t\t\tcase 6:\n" +
							"\t\t\t\ttopFace = 6;\n" +
							"\t\t}\n" +
							"\t\ttopFace = 6;\n" +
							"\t}\n" +
							"}";
				facesClicked = true;
			}
			
			// Button that activates the user's code
			if (GUI.Button (new Rect (Screen.width*0.6f, Screen.height*0.9f , Screen.width*0.08f, Screen.height*0.05f), "Submit")) 
			{
				TextChanger.Update();
				if (facesClicked){ 
					GameObject.Find("Initialization").GetComponent<PoisonTime>().cheating = true;
					GameObject.Find("d67").GetComponent<DiceRotateLoaded>().loaded = true;

				}
				resume();
			}
			
			// Button that closes the UI and disregards changes
			if (GUI.Button (new Rect (Screen.width*0.7f, Screen.height*0.9f , Screen.width*0.08f, Screen.height*0.05f), "Cancel")) 
			{
				resume();
			}
			
			// Button that restores the code in the textArea to its original state
			if (GUI.Button (new Rect (Screen.width*0.8f, Screen.height*0.9f , Screen.width*0.08f, Screen.height*0.05f), "Reset")) 
			{
				code = restoreCode();
				text="";
				//output="";
				forStart=0;
				forFinish=0;
				value=0;
			}
		}
	}
	
	//Adds new Code to the TextArea based on the user input
	//*******************************************************
	public string addToCode(string s,TextEditor e,string added)
	{
		s = s.Insert(e.pos,added);
		return s;
	}
	
	public string restoreCode()
	{
		string dummy="public class game{\n" +
			"\tpublic static void main(String[] args){\n" +
				"\t\tint rolledNumber = 6;\n" +
				"\t\ttopFace = rolledNumber;\n" +
				"\t\t\n" +
				"\t}\n" +
				"}";
		return dummy;
	}
	
	public int countLinesBefore(string s, int position)
	{
		int lines = 0;
		char[] a = s.ToCharArray ();
		for (int i=0; i<position-1; i++)
		{
			if(a[i]=='\n')
				lines++;
		}
		return lines;
	}
	
	public int countLinesAfter(string s, int position)
	{
		int lines = 0;
		char[] a = s.ToCharArray ();
		for (int i=position; i<s.Length; i++)
		{
			if(a[i]=='\n')
				lines++;
		}
		return lines;
	}
	
	public bool isBlankLine(string s, int index)
	{
		char[] a = s.ToCharArray();
		if (((a [index - 1] == '\t')||(a [index - 1] == '\n'))&&(a[index]=='\n'))
			return true;
		else
			return false;
	}
	
	public int getNumOfTabs(string s, int index)
	{
		if (index <= 1)
			return 0;
		int tabs = 0;
		char[] a = s.ToCharArray();
		while( a[index-1]!='\n' && index>1)
		{
			if(a[index-1]=='\t')
				tabs++;
			index--;
		}
		return tabs;
	}
	
	public TextEditor moveNextLine(TextEditor te, string s)
	{
		char[] a = s.ToCharArray();
		while (a[te.pos]!='\n')
			te.MoveRight ();
		return te;
	}
	
	public string addedTabs(int num)
	{
		string tabs = "";
		while (num>0) {
			tabs = tabs.Insert(0,"\t");
			num--;
		}
		return tabs;
	}
	
	public void resume(){
		Time.timeScale = 1.0f;
		guiEnabled = false;
		GameObject.Find("Main Camera").GetComponent<MouseLook>().enabled=true;
		GameObject.Find("First Person Controller").GetComponent<MouseLook>().enabled=true;
		GameObject.Find("Initialization").GetComponent<CursorTime>().showCursor=true;
		text = "Your die is fair. Don't" +
						"mess with it. Cheating will" +
						"result in dire consequences.";
	}
}
