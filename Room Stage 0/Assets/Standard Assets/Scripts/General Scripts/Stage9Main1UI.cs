using UnityEngine;
using System.Collections;

public class Stage9Main1UI : MonoBehaviour {
	int positionI;
	int positionG;
		public static bool puzzleComplete = false;
		public bool guiEnabled = false;
		public static bool atWall9_1 = false;
		bool showError = false;
		bool instantiated = false;
		bool generated = false;
		public bool reset = false;
		public Texture2D cursorImage;
		TextEditor editor;
		public static string ind = "";
		public static string val = "";
		static string var = "";
		public string code;
		string errorString = "";
		string cantType = "You can not add code here.";
		string already = "Object already instantiated.";
		string invalid ="You must instantiate the object first.";

		//Ray outwardRay;
		//RaycastHit hit;
		
		void OnTriggerEnter(Collider col2)
		{
			if (col2.gameObject.name == "Wall_Jack_S9_1")
			{
				atWall9_1 = true;
				GameObject.Find("Arm Camera").camera.enabled = false;
			}
		}
		
		void OnTriggerExit(Collider col2)
		{
			if (col2.gameObject.name == "Wall_Jack_S9_1")
			{
				atWall9_1 = false;
				guiEnabled = false;
				GameObject.Find("Arm Camera").camera.enabled = true;
			}
		}
		
		void Start()
		{

			code = "public class game{\n" +
				"\tpublic static void main(String[] args){\n" +
					"\t\t\n" +
					"\t}\n" +
					"}";
		}
		
		//Switches the GUI on and off
		//*******************************************************
		void Update()
		{
			if (atWall9_1) {
				if (Input.GetKeyDown ("e")) {
						if (guiEnabled) {					
								resume ();
						} else {
							StartCoroutine(jackin ());
						}
				}
			}
			
		}
		//*******************************************************
		
		
		//Includes all the GUI elements
		//*******************************************************
		public void OnGUI()
		{
			if (atWall9_1 && Input.GetKeyDown("e"))
			{
				//GameObject.Find("Initialization").GetComponent<CursorTime>().showCursor = false;
				//If at wall terminal show default cursor instead
			}
			
			
			if (guiEnabled)
			{
				GUI.Box(new Rect(0, 0, Screen.width, Screen.height), "Arrays Puzzle");
				
				if (showError)
				{
					GUI.Label(new Rect(Screen.width * 0.4f, Screen.height * 0.45f, Screen.width * 0.2f, Screen.height * 0.1f), errorString);
					if (GUI.Button(new Rect(Screen.width * 0.47f, Screen.height * 0.55f, Screen.width * 0.06f, Screen.height * 0.04f), "sorry"))
					{
						showError = false;
					}
				}
				
				GUI.SetNextControlName("Textarea");
				GUI.TextArea(new Rect(Screen.width * 0.24f, Screen.width * 0.04f, Screen.width * 0.75f, Screen.height * 0.75f), code);
				
				if (showError)
				{
					GUI.Label(new Rect(Screen.width * 0.4f, Screen.height * 0.45f, Screen.width * 0.2f, Screen.height * 0.1f), errorString);
					if (GUI.Button(new Rect(Screen.width * 0.47f, Screen.height * 0.55f, Screen.width * 0.06f, Screen.height * 0.04f), "sorry"))
					{
						showError = false;
					}
				}
				editor = (TextEditor)GUIUtility.GetStateObject(typeof(TextEditor), GUIUtility.keyboardControl);
				editor.SelectNone();
				
				GUI.skin.label.fontSize = 12;

				
				if (GUI.Button(new Rect(Screen.width * 0.02f, Screen.height * 0.32f, Screen.width * 0.2f, Screen.height * 0.1f), "Instantiate Sheild"))
				{

				if(instantiated)
				{
					showError = true;
					errorString = already;
				}
				else
				{
					GUI.FocusControl("Textarea");
					string s = "Sheild sh = new Sheild();\n\t\t";
					positionG = countLinesBefore(code, editor.pos);
					instantiated = true;
					editor.pos=1;
					editor = goToNextLine(editor, code);
					code = addToCode(code, editor, s);
				}
				}

				if (GUI.Button(new Rect(Screen.width * 0.02f, Screen.height * 0.44f, Screen.width * 0.2f, Screen.height * 0.1f), "Generate Sheild"))
				{
				if(!instantiated)
				{
						showError = true;
						errorString = invalid;
				}
				else
				{
					GUI.FocusControl("Textarea");
					string s = "generate(sh);\n\t\t";
					editor.pos=1;
					editor = goToNextLine(editor, code);
					code = addToCode(code, editor, s);
					generated = true;
					positionG = countLinesBefore(code, editor.pos);
				}
				}
				
				// Button that activates the user's code
				if (GUI.Button(new Rect(Screen.width * 0.4f, Screen.height * 0.9f, Screen.width * 0.15f, Screen.height * 0.08f), "Submit"))
				{
				GameObject.Find("Initialization").GetComponent<InitialStage9>().activate(1);
					resume();
				}
				
				// Button that closes the UI and disregards changes
				if (GUI.Button(new Rect(Screen.width * 0.6f, Screen.height * 0.9f, Screen.width * 0.15f, Screen.height * 0.08f), "Cancel"))
				{
					resume();
					code = restoreCode();
					instantiated = false;
					generated = false;
					showError = false;
				}
				
				
				// Button that restores the code in the indArea to its original state
				if (GUI.Button(new Rect(Screen.width * 0.8f, Screen.height * 0.9f, Screen.width * 0.15f, Screen.height * 0.08f), "Reset") || reset)
				{
					code = restoreCode();
					instantiated = false;
					generated = false;
					showError = false;
				}

				
			}
			
		}
		
		//Adds new Code to the indArea based on the user input
		//*******************************************************
		public string addToCode(string s, TextEditor e, string added)
		{
			s = s.Insert(e.pos, added);
			return s;
		}
		
		public string restoreCode()
		{
		string dummy = "public class game{\n" +
			"\tpublic static void main(String[] args){\n" +
				"\t\t\n" +
				"\t}\n" +
				"}";
			return dummy;
		}
		
		public int countLinesBefore(string s, int position)
		{
			int lines = 0;
			char[] a = s.ToCharArray();
			if (position == 0)
				position++;
			for (int i = 0; i < position - 1; i++)
			{
				if (a[i] == '\n')
					lines++;
			}
			return lines;
		}
		
		public int countLinesAfter(string s, int position)
		{
			int lines = 0;
			char[] a = s.ToCharArray();
			for (int i = position; i < s.Length; i++)
			{
				if (a[i] == '\n')
					lines++;
			}
			return lines;
		}
		
		public bool isBlankLine(string s, int index)
		{
			char[] a = s.ToCharArray();
			if (((a[index - 1] == '\t') || (a[index - 1] == '\n')) && (a[index] == '\n'))
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
			while (a[index - 1] != '\n' && index > 1)
			{
				if (a[index - 1] == '\t')
					tabs++;
				index--;
			}
			return tabs;
		}
		
		public TextEditor moveNextLine(TextEditor te, string s)
		{
			char[] a = s.ToCharArray();
			while (a[te.pos] != '\n')
				te.MoveRight();
			return te;
		}
		
		public string addedTabs(int num)
		{
			string tabs = "";
			while (num > 0)
			{
				tabs = tabs.Insert(0, "\t");
				num--;
			}
			return tabs;
		}
		
		public TextEditor goToNextLine(TextEditor e, string s)
		{
			char[] a = s.ToCharArray();
			int i;
			if (editor.pos < 1)
				i = editor.pos;
			else
				i = editor.pos - 1;
			for (; i < s.Length; i++)
			{
				if ((a[i] == '\t') && (a[i + 1] == '\n'))
				{
					e.pos = i + 1;
					return e;
				}
			}
			return e;
		}
		
		public void resume()
		{
			//Time.timeScale = 1.0f;
			guiEnabled = false;
			GameObject.Find("Initialization").GetComponent<CursorTime>().showCursor = true;
			GameObject.Find("Main Camera").GetComponent<MouseLook>().enabled = true;
			GameObject.Find("First Person Controller").GetComponent<MouseLook>().enabled = true;
			GameObject.Find("First Person Controller").GetComponent<CharacterMotor>().enabled = true;
			GameObject.Find("Robo_Arm10").GetComponent<ArmAnimation2>().enabled = true;
			GameObject.Find ("Robo_Arm10").GetComponent<ArmAnimation2> ().disable = false;
		}
		
		public bool isNumber(string input)
		{
			bool b = true;
			char[] a = input.ToCharArray();
			for (int i = 0; i < input.Length; i++)
			{
				if (!(((a[i].CompareTo('0') >= 0) && (a[i].CompareTo('9') <= 0)) || ((a[i].CompareTo('.') == 0))))
				{
					b = false;
				}
			}
			return b;
		}
		

		IEnumerator jackin()
		{
			atWall9_1 = false;
			GameObject.Find ("Robo_Arm10").GetComponent<ArmAnimation2> ().disable = true;
			GameObject.Find("Main Camera").GetComponent<MouseLook>().enabled = false;
			GameObject.Find("First Person Controller").GetComponent<MouseLook>().enabled = false;
			GameObject.Find("First Person Controller").GetComponent<CharacterMotor>().enabled = false;
			yield return new WaitForSeconds (1.0F);
			//Time.timeScale = 0.0f;
			guiEnabled = true;
			GameObject.Find("Initialization").GetComponent<CursorTime>().showCursor = false;
			GameObject.Find("Robo_Arm10").GetComponent<ArmAnimation2>().enabled = false;
			atWall9_1 = true;
		}
		
	}

	