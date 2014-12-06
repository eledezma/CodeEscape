using UnityEngine;
using System.Collections;

public class scannerUi : MonoBehaviour {
	
	public static bool puzzle2Complete = false;
	bool guiEnabled = false;
	public static bool atScanner = false;
	bool scannerCreated=false;
	bool scannerAssigned=false;
	bool showError = false;
	public Texture2D cursorImage;
	TextEditor editor;
	public static string output="";
	int forStart;
	static string var = "";
	public string code="public class game{\n" +
		"\tpublic static void main(String[] args){\n" +
			"\t\tString order = \"No input\";\n" +
			"\t\t\n" +
			"\t\tSystem.out.println(order);\n" +	
			"\t}\n" +
			"}";
	string noScannerError="No scanner was created yet.";
	string noVariableError="There's no such variable in the code.";
	string cantType="You can't type code in that area.";
	string errorString = "";
	//Ray outwardRay;
	//RaycastHit hit;

	void OnTriggerEnter(Collider col2){
		if (col2.gameObject.name == "Wall_Jack_S2") {
				atScanner = true;
				GameObject.Find ("Arm Camera").camera.enabled = false;
		}
	}
	
	void OnTriggerExit(Collider col2){
		if (col2.gameObject.name == "Wall_Jack_S2") {
				atScanner = false;
				guiEnabled = false;
				GameObject.Find ("Arm Camera").camera.enabled = true;
			}
	}

	void Start(){
		Screen.lockCursor = true;
	}

	//Switches the GUI on and off
	//*******************************************************
	void Update(){
		if (atScanner) {
			if (Input.GetKeyDown ("e")) {
				if (guiEnabled) {
					resume ();
				} else {
					Time.timeScale = 0.0f;
					guiEnabled = true;
					GameObject.Find ("Main Camera").GetComponent<MouseLook> ().enabled = false;
					GameObject.Find ("First Person Controller").GetComponent<MouseLook> ().enabled = false;
				}
			} 
			
		}
		/*
		outwardRay = Camera.main.ScreenPointToRay (Input.mousePosition);
		//Ray outwardRay = new Ray(transform.position, Vector3.back);
		if(Physics.Raycast(outwardRay, out hit,15f)){
			Debug.Log("you did it buddy");
			if(hit.collider.tag=="Terminal"){
				if(Input.GetKeyDown("o")){
					if(guiEnabled){
						resume();
					}
					else{
						Time.timeScale = 0.0f;
						guiEnabled = true;
						GameObject.Find ("Main Camera").GetComponent<MouseLook> ().enabled = false;
						GameObject.Find ("First Person Controller").GetComponent<MouseLook> ().enabled = false;
					}
				}
			}
		}*/
		else if(!MakeOrder.atOrderWall && !atScanner) {
			
			//Screen.lockCursor = true;
			//Screen.lockCursor = false; //Cursor remains locked if not in terminal
		}
	}
	//*******************************************************
	
	
	//Includes all the GUI elements
	//*******************************************************
	public void OnGUI()
	{
		//if(!(Physics.Raycast(outwardRay, out hit,15f))){
		if (!atScanner && !MakeOrder.atOrderWall) {  //If not at wall terminal jack in - "show crosshair"

		} 
		
		else if (atScanner && Input.GetKeyDown ("e")) { 
			GameObject.Find("Initialization").GetComponent<CursorTime>().showCursor=false;
			//If at wall terminal show default cursor instead
		}

		
		if (guiEnabled) {
			GUI.Box (new Rect (0, 0, Screen.width, Screen.height), "System Input Puzzle");
			
			//GUI.Label(new Rect(500, 500, 200, 200), string.Format("Selected text: {0}\n",showError));
			
			if(showError)
			{
				GUI.Label ( new Rect ( Screen.width*0.4f,Screen.height*0.45f, Screen.width*0.2f,Screen.height*0.1f),errorString);
				if(GUI.Button (new Rect (Screen.width*0.47f,Screen.height*0.55f, Screen.width*0.06f,Screen.height*0.04f), "sorry"))
				{
					showError=false;
				}
			}
			
			GUI.TextArea (new Rect (Screen.width*0.2f, Screen.width*0.04f, Screen.width*0.75f, Screen.height*0.75f),code);
			
			if(showError)
			{
				GUI.Label ( new Rect ( Screen.width*0.4f,Screen.height*0.45f, Screen.width*0.2f,Screen.height*0.1f),errorString);
				if(GUI.Button (new Rect (Screen.width*0.47f,Screen.height*0.55f, Screen.width*0.06f,Screen.height*0.04f), "sorry"))
				{
					showError=false;
				}
			}
			editor = (TextEditor)GUIUtility.GetStateObject(typeof(TextEditor), GUIUtility.keyboardControl);
			
			GUI.skin.label.fontSize = 12;
			
			//variable textfield
			//*******************************************************
			var = GUI.TextField (new Rect (Screen.width*0.16f,Screen.height*0.28f,Screen.width*0.04f,Screen.height*0.05f), var);
			
			//*******************************************************
			GUI.Label(new Rect(Screen.width*0.16f,Screen.height*0.24f,Screen.width*0.04f,Screen.height*0.05f),("variable"));  	//for loop parameter title
			
			// Button that inserts a scanner
			if (GUI.Button (new Rect (Screen.width*0.02f, Screen.height*0.18f, Screen.width*0.14f, Screen.height*0.05f), "Create a Scanner")) 
			{
				if((countLinesBefore(code,editor.pos)>=2)&&(countLinesAfter(code,editor.pos)>=2)&&isBlankLine(code,editor.pos))
				{
					int num =getNumOfTabs(code,editor.pos);
					code = addToCode(code,editor,"Scanner reader = new Scanner(System.in);\n"+addedTabs(num));
					scannerCreated=true;
				}
				else 
				{
					errorString=cantType;
					showError=true;
				}
			}
			
			// Button that assigns a scanner to a variable
			if (GUI.Button (new Rect (Screen.width*0.02f, Screen.height*0.28f, Screen.width*0.14f, Screen.height*0.05f), "Assign scanner to variable")) 
			{
				if(scannerCreated)
				{
					int num =getNumOfTabs(code,editor.pos);
					if(var=="order")
					{
						if((countLinesBefore(code,editor.pos)>=2)&&(countLinesAfter(code,editor.pos)>=2)&&isBlankLine(code,editor.pos))
						{
							code = addToCode (code,editor,"order = reader.nextLine();");
						}
						else
						{
							errorString=cantType;
							showError=true;
						}
					}
					else
					{
						errorString=noVariableError;
						showError=true;
					}
				}
				else 
				{
					errorString=noScannerError;
					showError=true;
				}				
			}				
			
			// Button that activates the user's code
			if (GUI.Button (new Rect (Screen.width*0.6f, Screen.height*0.9f , Screen.width*0.08f, Screen.height*0.05f), "Submit")) 
			{
				puzzle2Complete=true;
				if((scannerCreated)&&(scannerAssigned))
					puzzle2Complete=true;
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
				output="";
				forStart=0;
				var="";
				showError = false;
				scannerCreated= false;
				scannerAssigned = false;
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
				"\t\tString order = \"No input\";\n" +
				"\t\t\n" +
				"\t\tSystem.out.println(order);\n" +	
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
		GameObject.Find ("Initialization").GetComponent<CursorTime> ().showCursor = true;
		GameObject.Find("Main Camera").GetComponent<MouseLook>().enabled=true;
		GameObject.Find("First Person Controller").GetComponent<MouseLook>().enabled=true;
	}
}

