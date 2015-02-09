using UnityEngine;
using System.Collections;

public class TurretsAndLoops : MonoBehaviour 
{	
	int forStart;
	int forFinish;
	int position = 0;
	public static bool puzzle2Complete = false;
	bool guiEnabled = false;
	public static bool atWall5 = false;
	bool showError = false;
	bool ifAdded = false;
	public bool reset = false;
	public static bool shootAdded = false;
	public static bool turnAdded = false;
	public static bool gateLowered = false;
	public static bool ballMoving = true;
	public static bool doorOpenDone = false;
	public static bool holeOpenedDone = false;
	public static bool gateLoweredDone = false;
	public Texture2D cursorImage;
	TextEditor editor;
	public static string text = "";
	static string var = "";
	public string code = "public class game{\n" +
				"\tpublic static void main(String[] args){\n" +
				"\t\tif(turretTriggered){\n" +
				"\t\t\tshoot(1);\n" +
				"\t\t\tturnTurret();\n" +
				"\t\t\t\n"+
				"\t\t}\n" +
				"\t}\n" +
				"}";
string errorString = "";
string cantType = "You can not add code here.";
	string badInput = "You can only inter an integer value between 0 and 50";

//Ray outwardRay;
//RaycastHit hit;

void OnTriggerEnter (Collider col2)
{
	if (col2.gameObject.name == "Wall_Jack_S5") {
		atWall5 = true;
		GameObject.Find ("Arm Camera").camera.enabled = false;
	}
}

void OnTriggerExit (Collider col2)
{
	if (col2.gameObject.name == "Wall_Jack_S5") 
		{
		atWall5 = false;
		guiEnabled = false;
		GameObject.Find ("Arm Camera").camera.enabled = true;
	}
}

void Start ()
{
	
}

//Switches the GUI on and off
//*******************************************************
void Update ()
{
	//if (atWall5) {
		if (Input.GetKeyDown ("e")) {
			if (guiEnabled) 
			{
				resume ();
			} 
			else 
			{
				Time.timeScale = 0.0f;
				guiEnabled = true;
				GameObject.Find ("Main Camera").GetComponent<MouseLook> ().enabled = false;
				GameObject.Find ("First Person Controller").GetComponent<MouseLook> ().enabled = false;
				GameObject.Find ("Initialization").GetComponent<CursorTime> ().showCursor = false; //remove this line when atScanner works
				Screen.lockCursor = false;
			}
		} 
//	}	

	
	// else if (!MakeOrder.atOrderWall && !atScanner) {
	
	//Screen.lockCursor = true;
	//Screen.lockCursor = false; //Cursor remains locked if not in terminal
	//	}
}
//*******************************************************


//Includes all the GUI elements
//*******************************************************
public void OnGUI ()
{
		int temp;
	//	if (Input.GetMouseButtonDown (0) && editor.pos != 0) {
	//			position = editor.pos;
	//	}
	//if(!(Physics.Raycast(outwardRay, out hit,15f))){
	/*if (!atWall5) {  //If not at wall terminal jack in - "show crosshair"
		
	} else */
		if ( Input.GetKeyDown ("e")) { 
		GameObject.Find ("Initialization").GetComponent<CursorTime> ().showCursor = false;
		//If at wall terminal show default cursor instead
	}
	
	
	if (guiEnabled) {
		GUI.Box (new Rect (0, 0, Screen.width, Screen.height), "Selection Statement Puzzle");
		
		
		//GUI.Label(new Rect(500, 500, 200, 200), string.Format("Selected text: {0}\n",showError));
		
		if (showError) {
			GUI.Label (new Rect (Screen.width * 0.4f, Screen.height * 0.45f, Screen.width * 0.2f, Screen.height * 0.1f), errorString);
			if (GUI.Button (new Rect (Screen.width * 0.47f, Screen.height * 0.55f, Screen.width * 0.06f, Screen.height * 0.04f), "sorry")) {
				showError = false;
			}
		}
		
		GUI.SetNextControlName ("textarea");
		GUI.TextArea (new Rect (Screen.width * 0.2f, Screen.width * 0.04f, Screen.width * 0.75f, Screen.height * 0.75f), code);
		
		if (showError) {
			GUI.Label (new Rect (Screen.width * 0.4f, Screen.height * 0.45f, Screen.width * 0.2f, Screen.height * 0.1f), errorString);
			if (GUI.Button (new Rect (Screen.width * 0.47f, Screen.height * 0.55f, Screen.width * 0.06f, Screen.height * 0.04f), "sorry")) {
				showError = false;
			}
		}
		editor = (TextEditor)GUIUtility.GetStateObject (typeof(TextEditor), GUIUtility.keyboardControl);
		editor.SelectNone ();
		
		GUI.skin.label.fontSize = 12;
		
		
		//*******************************************************
		// Button that erases unwanted code
		if (GUI.Button (new Rect (Screen.width * 0.02f, Screen.height * 0.18f, Screen.width * 0.1f, Screen.height * 0.05f), "Remove code")) {
			GUI.FocusControl ("textarea");
			editor = goToNextEmptyLine(editor,code);				
			if ((countLinesBefore (code, editor.pos) >= 2) && (countLinesAfter (code, editor.pos) >= 2) && isBlankLine (code, editor.pos)) {
				int num = getNumOfTabs (code, editor.pos);
					code = "public class game{\n" +
						"\tpublic static void main(String[] args){\n" +
							"\t\tif(turretTriggered){\n" +
							"\t\t\t\n"+
							"\t\t}\n" +
							"\t}\n" +
							"}";				
					ifAdded = true;
			} 
				else 
				{
				showError = true;
			}
		}
		
			// for loop starting value textfield
			//*******************************************************
			string fs = GUI.TextField (new Rect (Screen.width * 0.12f, Screen.height * 0.28f, Screen.width * 0.04f, Screen.height * 0.05f), forStart.ToString ());
			if (int.TryParse (fs, out temp)) 
			{
				forStart = Mathf.Clamp (temp, 0, 50);
			} 
			else if 
			(fs == "") 
			{
				forStart = 0;
			}
			//*******************************************************
			GUI.Label (new Rect (Screen.width * 0.12f, Screen.height * 0.24f, Screen.width * 0.04f, Screen.height * 0.05f), ("start"));  	//for loop parameter title
			
			//for loop ending value textfield
			//*******************************************************
			string ff = GUI.TextField (new Rect (Screen.width * 0.16f, Screen.height * 0.28f, Screen.width * 0.04f, Screen.height * 0.05f), forFinish.ToString ());
			if (int.TryParse (ff, out temp)) {
				forFinish = Mathf.Clamp (temp, 0, 100);
			} else if (ff == "") {
				forFinish = 0;
			}
			//*******************************************************
			GUI.Label (new Rect (Screen.width * 0.16f, Screen.height * 0.24f, Screen.width * 0.04f, Screen.height * 0.05f), ("finish"));  	//for loop parameter title

			// Button that inserts a for loop
			if (GUI.Button (new Rect (Screen.width * 0.02f, Screen.height * 0.28f, Screen.width * 0.1f, Screen.height * 0.05f), "For Loop")) 
			{
				GUI.FocusControl ("textarea");
				editor = goToNextEmptyLine (editor, code);				
				int num = getNumOfTabs (code, editor.pos);
				if ((countLinesBefore (code, editor.pos) >= 2) && (countLinesAfter (code, editor.pos) >= 2) && isBlankLine (code, editor.pos)) 
				{
					code = addToCode (code, editor, "For(int i=" + fs + ";i<=" + ff + ";i++){\n" + addedTabs (num) + "\t\n" + addedTabs (num) + "}");
				}
			}
		
			GUI.Label (new Rect (Screen.width * 0.12f, Screen.height * 0.34f, Screen.width * 0.04f, Screen.height * 0.05f), ("value"));						//print statement title
			text = GUI.TextField (new Rect (Screen.width * 0.12f, Screen.height * 0.38f, Screen.width * 0.04f, Screen.height * 0.05f), text); 

		if (GUI.Button (new Rect (Screen.width * 0.02f, Screen.height * 0.38f, Screen.width * 0.1f, Screen.height * 0.05f), "Shoot")) 
			{
			GUI.FocusControl ("textarea");
			editor = goToNextEmptyLine(editor,code);				
			if (ifAdded) {
					int.TryParse(text,out temp);
					if(text.Equals("i")||((temp>=0)&&(temp<51)))
					{
				int num = getNumOfTabs (code, editor.pos);
				
				if ((countLinesBefore (code, editor.pos) >= 2) && (countLinesAfter (code, editor.pos) >= 2) && isBlankLine (code, editor.pos)) 
						{
					code = addToCode (code, editor, "shoot("+text+");\n"+addedTabs(num));
					shootAdded = true;
				} 
						else 
						{
					errorString = cantType;
					showError = true;
				}
				}
					else
					{
						errorString = badInput;
						showError = true;
					}
				}
				else 
				{
				showError = true;
			}
		}
		
		// Button that opens level door
			if (GUI.Button (new Rect (Screen.width * 0.02f, Screen.height * 0.48f, Screen.width * 0.1f, Screen.height * 0.05f), "Turn Turret")) 
			{
			GUI.FocusControl ("textarea");
			editor = goToNextEmptyLine(editor,code);				
			if (ifAdded) 
				{
				int num = getNumOfTabs (code, editor.pos);
				
				if ((countLinesBefore (code, editor.pos) >= 2) && (countLinesAfter (code, editor.pos) >= 2) && isBlankLine (code, editor.pos)) {
					code = addToCode (code, editor, "turnTurret();");
					turnAdded = true;
				} 
					else 
					{
					errorString = cantType;
					showError = true;
				}
			}
				else 
				{
				showError = true;
			}		
		}		
		GUI.Label (new Rect (500, 500, 200, 200), string.Format ("Selected text: {0}\nPos: {1}\nSelect pos: {2}\nLines Before: {3}\nLines After: {4}",
		                                                         position,
		                                                         editor.pos,
		                                                         0,
		                                                         countLinesBefore (code, editor.pos),
		                                                         countLinesAfter (code, editor.pos)));
		// Button that activates the user's code
		if (GUI.Button (new Rect (Screen.width * 0.6f, Screen.height * 0.9f, Screen.width * 0.08f, Screen.height * 0.05f), "Submit")) {
			if (ifAdded) 
			{
					doForLoop(forStart,forFinish,text);
			}
			resume ();
		}
		
		// Button that closes the UI and disregards changes
		if (GUI.Button (new Rect (Screen.width * 0.7f, Screen.height * 0.9f, Screen.width * 0.08f, Screen.height * 0.05f), "Cancel")) 
			{
			resume ();
			code = restoreCode ();
			showError = false;
			ifAdded = false;
			//doorOpen = false;
		}
		
		
		// Button that restores the code in the textArea to its original state
		if (GUI.Button (new Rect (Screen.width * 0.8f, Screen.height * 0.9f, Screen.width * 0.08f, Screen.height * 0.05f), "Reset") || reset) 
			{
			code = restoreCode ();
			showError = false;
			ifAdded = false;
			//doorOpen = false;
			reset = false;
		}
		
	}
	
}

//Adds new Code to the TextArea based on the user input
//*******************************************************
public string addToCode (string s, TextEditor e, string added)
{
	s = s.Insert (e.pos, added);
	return s;
}

public string restoreCode ()
{
		string dummy = "public class game{\n" +
			"\tpublic static void main(String[] args){\n" +
				"\t\tif(turretTriggered){\n" +
				"\t\t\tshoot(1);\n" +
				"\t\t\tturnTurret();\n" +
				"\t\t\t\n"+
				"\t\t}\n" +
				"\t}\n" +
				"}";
	return dummy;
}

public int countLinesBefore (string s, int position)
{
	int lines = 0;
	char[] a = s.ToCharArray ();
		if (position == 0)
			position++;
	for (int i=0; i<position-1; i++) 
	{
		if (a [i] == '\n')
			lines++;
	}
	return lines;
}

public int countLinesAfter (string s, int position)
{
	int lines = 0;
	char[] a = s.ToCharArray ();
	for (int i=position; i<s.Length; i++) {
		if (a [i] == '\n')
			lines++;
	}
	return lines;
}

public bool isBlankLine (string s, int index)
{
	char[] a = s.ToCharArray ();
	if (((a [index - 1] == '\t') || (a [index - 1] == '\n')) && (a [index] == '\n'))
		return true;
	else
		return false;
}

public int getNumOfTabs (string s, int index)
{
	if (index <= 1)
		return 0;
	int tabs = 0;
	char[] a = s.ToCharArray ();
	while (a[index-1]!='\n' && index>1) {
		if (a [index - 1] == '\t')
			tabs++;
		index--;
	}
	return tabs;
}

public TextEditor moveNextLine (TextEditor te, string s)
{
	char[] a = s.ToCharArray ();
	while (a[te.pos]!='\n')
		te.MoveRight ();
	return te;
}

public string addedTabs (int num)
{
	string tabs = "";
	while (num>0) 
		{
		tabs = tabs.Insert (0, "\t");
		num--;
	}
	return tabs;
}

public TextEditor goToNextEmptyLine(TextEditor e,string s){
	char[] a = s.ToCharArray ();
	int i;
	if (editor.pos < 1)
		i = editor.pos;
	else
		i = editor.pos - 1;
	for (; i<s.Length; i++) 
		{
		if((a[i] == '\t')&&(a[i+1]=='\n'))
			{
			e.pos = i+1;
			return e;
		}
	}
	return e;
}
public void resume ()
{
	Time.timeScale = 1.0f;
	guiEnabled = false;
	GameObject.Find ("Initialization").GetComponent<CursorTime> ().showCursor = true;
	GameObject.Find ("Main Camera").GetComponent<MouseLook> ().enabled = true;
	GameObject.Find ("First Person Controller").GetComponent<MouseLook> ().enabled = true;
}

public void doForLoop(int start, int finish, string arg)
	{
		for (int s = start; s<finish; s++) 
		{
			if(arg == "i")
			{
				//shoot(s);
			}
			else
			{
					//shoot(int.tryparse(arg);
			}
			if (turnAdded) 
			{
				// add code that turns turret
			}
		}
}
}

