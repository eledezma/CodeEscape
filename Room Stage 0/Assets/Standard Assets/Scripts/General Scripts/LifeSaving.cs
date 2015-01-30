using UnityEngine;
using System.Collections;

public class LifeSaving : MonoBehaviour
{
		int position = 0;
		public static bool puzzle2Complete = false;
		bool guiEnabled = false;
		public static bool atWall5 = false;
		bool showError = false;
		bool ifAdded = false;
		public static bool doorOpen = false;
		public static bool holeOpened = false;
		public static bool gateLowered = false;
		public static bool ballMoving = true;
		public static bool doorOpenDone = false;
		public static bool holeOpenedDone = false;
		public static bool gateLoweredDone = false;
		public Texture2D cursorImage;
		TextEditor editor;
		public static string output = "";
		int forStart;
		static string var = "";
		public string code = "public class game{\n" +
				"\tpublic static void main(String[] args){\n" +
				"\t\tgateLowered = " + gateLowered + ";\n" +
				"\t\tdoorOpen = " + doorOpen + ";\n" +
				"\t\tholeOpen = " + holeOpened + ";\n" +
				"\t\tballMoving =" + ballMoving + ";\n" +
				"\t\t\n" +
				"\t}\n" +
				"}";
		string errorString = "";
		string cantType = "You can not add code here.";
		string noIfStatement = "You must use an if statement.";
		string oneIf = "You do not need more than one if statement.";
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
				if (col2.gameObject.name == "Wall_Jack_S5") {
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
		if (atWall5) {
			if (Input.GetKeyDown ("e")) {
				if (guiEnabled) {
						resume ();
				} else {
						Time.timeScale = 0.0f;
						guiEnabled = true;
						GameObject.Find ("Main Camera").GetComponent<MouseLook> ().enabled = false;
						GameObject.Find ("First Person Controller").GetComponent<MouseLook> ().enabled = false;
						GameObject.Find ("Initialization").GetComponent<CursorTime> ().showCursor = false; //remove this line when atScanner works
						Screen.lockCursor = false;
				}
			} 
		}	
		ballMoving = GameObject.Find ("Object").GetComponent<Rollinrollinrollin> ().roll;
		if(doorOpen&&!doorOpenDone){
			GameObject.Find ("Door").GetComponent<DoorOpen> ().open = true;
			doorOpenDone = true;
		}
		if (gateLowered && !doorOpenDone) {
						GameObject.Find ("Gate").GetComponent<GateOpenLevel5> ().lowered = true;
						gateLoweredDone = true;
				}
		if (holeOpened && !holeOpenedDone) {
						GameObject.Find ("Object").GetComponent<Rollinrollinrollin> ().floorOpen = true;
						holeOpenedDone = true;
				}

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
			//	if (Input.GetMouseButtonDown (0) && editor.pos != 0) {
			//			position = editor.pos;
			//	}
				//if(!(Physics.Raycast(outwardRay, out hit,15f))){
				if (!atWall5) {  //If not at wall terminal jack in - "show crosshair"
				
				} else if (atWall5 && Input.GetKeyDown ("e")) { 
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
						// Button that inserts an if statement
						if (GUI.Button (new Rect (Screen.width * 0.02f, Screen.height * 0.18f, Screen.width * 0.14f, Screen.height * 0.05f), "Insert if statement")) {
								GUI.FocusControl ("textarea");
				editor = goToNextEmptyLine(editor,code);				
				if ((countLinesBefore (code, editor.pos) >= 2) && (countLinesAfter (code, editor.pos) >= 2) && isBlankLine (code, editor.pos)) {
										int num = getNumOfTabs (code, editor.pos);
										code = addToCode (code, editor, "If(ballMoving){\n" + addedTabs (num) + "\t\n" + addedTabs (num) + "}\n" + addedTabs (num) + "else{\n" + addedTabs (num) + "\t\n" + addedTabs (num) + "}");
										ifAdded = true;
								} else {
										errorString = oneIf;
										showError = true;
								}
						}
				
						// Button that adds a function that closes the gate
						if (GUI.Button (new Rect (Screen.width * 0.02f, Screen.height * 0.28f, Screen.width * 0.14f, Screen.height * 0.05f), "Close gate")) {
								GUI.FocusControl ("textarea");
				editor = goToNextEmptyLine(editor,code);				
								if (ifAdded) {
										int num = getNumOfTabs (code, editor.pos);
						
										if ((countLinesBefore (code, editor.pos) >= 2) && (countLinesAfter (code, editor.pos) >= 2) && isBlankLine (code, editor.pos)) {
												code = addToCode (code, editor, "closeGate();");
												gateLowered = true;
										} else {
												errorString = cantType;
												showError = true;
										}
								} else {
										errorString = noIfStatement;
										showError = true;
								}		
			}

						// Button that adds a function that closes the gate
						if (GUI.Button (new Rect (Screen.width * 0.02f, Screen.height * 0.38f, Screen.width * 0.14f, Screen.height * 0.05f), "Open hole")) {
				GUI.FocusControl ("textarea");
				editor = goToNextEmptyLine(editor,code);				
				if (ifAdded) {
										int num = getNumOfTabs (code, editor.pos);
					
										if ((countLinesBefore (code, editor.pos) >= 2) && (countLinesAfter (code, editor.pos) >= 2) && isBlankLine (code, editor.pos)) {
												code = addToCode (code, editor, "openHole();");
												holeOpened = true;
										} else {
												errorString = cantType;
												showError = true;
										}
								} else {
										errorString = noIfStatement;
										showError = true;
								}
			}

						// Button that opens level door
						if (GUI.Button (new Rect (Screen.width * 0.02f, Screen.height * 0.48f, Screen.width * 0.14f, Screen.height * 0.05f), "Open Door")) {
								GUI.FocusControl ("textarea");
				editor = goToNextEmptyLine(editor,code);				
				if (ifAdded) {
										int num = getNumOfTabs (code, editor.pos);
					
										if ((countLinesBefore (code, editor.pos) >= 2) && (countLinesAfter (code, editor.pos) >= 2) && isBlankLine (code, editor.pos)) {
												code = addToCode (code, editor, "openDoor();");
												doorOpen = true;
										} else {
												errorString = cantType;
												showError = true;
										}
								} else {
										errorString = noIfStatement;
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
								if (doorOpen) {
										// add code that opens door				
								}
								if (gateLowered) {
										// add code that closes gate
								}
								if (holeOpened) {
										//add code that opens hole
								}
								resume ();
						}
				
						// Button that closes the UI and disregards changes
						if (GUI.Button (new Rect (Screen.width * 0.7f, Screen.height * 0.9f, Screen.width * 0.08f, Screen.height * 0.05f), "Cancel")) {
								resume ();
								code = restoreCode ();
								showError = false;
								ifAdded = false;
								doorOpen = false;
						}
				
				
						// Button that restores the code in the textArea to its original state
						if (GUI.Button (new Rect (Screen.width * 0.8f, Screen.height * 0.9f, Screen.width * 0.08f, Screen.height * 0.05f), "Reset")) {
								code = restoreCode ();
								showError = false;
								ifAdded = false;
								doorOpen = false;
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
						"\t\tgateLowered = " + gateLowered + ";\n" +
						"\t\tdoorOpen = " + doorOpen + ";\n" +
						"\t\tholeOpen = " + holeOpened + ";\n" +
						"\t\tballMoving =" + ballMoving + ";\n" +
						"\t\t\n" +
						"\t}\n" +
						"}";
				return dummy;
		}
		
		public int countLinesBefore (string s, int position)
		{
				int lines = 0;
				char[] a = s.ToCharArray ();
				for (int i=0; i<position-1; i++) {
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
				while (num>0) {
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
		for (; i<s.Length; i++) {
			if((a[i] == '\t')&&(a[i+1]=='\n')){
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
}
	
