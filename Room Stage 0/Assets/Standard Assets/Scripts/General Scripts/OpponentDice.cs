using UnityEngine;
using System.Collections;

public class OpponentDice : MonoBehaviour {
	bool puzzle1Complete = false;
	bool guiEnabled = false;
	bool atOpponentWall = false;
	public AudioClip missionComplete;
	TextEditor editor;
	static string text="";
	public static string output="";
	public Texture2D cursorImage;
	int forStart;
	int forFinish;
	int value=0;
	bool showError = false;
	bool randClicked = false;
	bool switchClicked = false;
	bool facesClicked= false;
	bool switch2 =false;
	bool rand1 = false;
	bool face3 = false;
	bool facesCorrect = false;
	bool randCorrect = false;
	bool case1 = false;
	bool case2 = false;
	bool case3 = false;
	bool case4 = false;
	bool case5 = false;
	bool case6 = false;

	string errorString = "";
	string randFalseError = "Wrong range of numbers that dice can have.";
	string wrongFace = "Die face can't have that value. ";
	string switch1Error = "You only need one switch statement to do this puzzle, don't be greedy! >:[";
	string cheatError = "Don't cheat! You must make the dice fair.";
	string cantType="You can't type code in that area.";
	
	//GameObject Arms;
	public string code="public class game{\n" +
		"\tpublic static void main(String[] args){\n" +
			"\t\tint rolledNumber = 6;\n" +
			"\t\ttopFace = rolledNumber;\n" +
			"\t\t\n" +
			"\t}\n" +
			"}";
	void OnTriggerEnter(Collider other){
		if (other.gameObject.name == "Opponent_Wall_Jack_S2") {
			atOpponentWall = true;
			GameObject.Find ("Arm Camera").camera.enabled = false;
			//Arms.camera.enabled = false;
		}
	}


	void OnTriggerExit(Collider other){
		atOpponentWall=false;
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
	void Update(){
		if (atOpponentWall) {
			if (Input.GetKeyDown ("e")) {
					Screen.lockCursor = false;  //Cursor is free to move when user goes into terminal
					if (guiEnabled) {
							resume ();
					} else {
							GameObject.Find ("Initialization").GetComponent<CursorTime> ().showCursor = false;
							Time.timeScale = 0.0f;
							guiEnabled = true;
							GameObject.Find ("Main Camera").GetComponent<MouseLook> ().enabled = false;
							GameObject.Find ("First Person Controller").GetComponent<MouseLook> ().enabled = false;

					}
			}
			editor = (TextEditor)GUIUtility.GetStateObject (typeof(TextEditor), GUIUtility.keyboardControl);
		}
	}
	//*******************************************************
	
	
	//Includes all the GUI elements
	//*******************************************************
	public void OnGUI()
	{
		if (!atOpponentWall) {  //If not at wall terminal jack in - "show crosshair"
			Vector3 mPos = Input.mousePosition;
			//GUI.DrawTexture (new Rect (mPos.x - 32, Screen.height - mPos.y - 32, 64, 64), cursorImage);
		} 
		
		else if (atOpponentWall && Input.GetKeyDown ("e")) { 
			//GameObject.Find("Initialization").GetComponent<CursorTime>().showCursor=false;
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
			                                                      facesCorrect,
			                                                      randCorrect,
			                                                      rand1,
			                                                      switch2,
			                                                      face3));
			
			int temp;
			

			
			// for loop starting value textfield
			//*******************************************************
			string fs = GUI.TextField (new Rect (Screen.width*0.12f,Screen.height*0.28f,Screen.width*0.04f,Screen.height*0.05f), forStart.ToString());
			if (int.TryParse(fs,out temp))
			{
				forStart = Mathf.Clamp(temp,0,100);
			}
			else if (fs == "")
			{
				forStart = 0;
			}
			//*******************************************************
			GUI.Label(new Rect(Screen.width*0.12f,Screen.height*0.24f,Screen.width*0.04f,Screen.height*0.05f),("start"));  	//for loop parameter title
			
			//for loop ending value textfield
			//*******************************************************
			string ff = GUI.TextField (new Rect (Screen.width*0.16f,Screen.height*0.28f,Screen.width*0.04f,Screen.height*0.05f), forFinish.ToString());
			if (int.TryParse(ff,out temp))
			{
				forFinish = Mathf.Clamp(temp,0,100);
			}
			else if (ff == "")
			{
				forFinish = 0;
			}
			//*******************************************************

			string val = GUI.TextField (new Rect (Screen.width*0.12f,Screen.height*0.48f,Screen.width*0.04f,Screen.height*0.05f), value.ToString());
			if (int.TryParse(val,out temp))
			{
				value = Mathf.Clamp(temp,0,100);
			}
			else if (val == "")
			{
				value = 0;
			}


			GUI.Label(new Rect(Screen.width*0.16f,Screen.height*0.24f,Screen.width*0.04f,Screen.height*0.05f),("finish"));  	//for loop parameter title

			
			// Button that inserts a Random generator function
			if (GUI.Button (new Rect (Screen.width*0.02f, Screen.height*0.28f, Screen.width*0.1f, Screen.height*0.05f), "Assign a Random int between")) 
			{
				int num =getNumOfTabs(code,editor.pos);
				if((countLinesBefore(code,editor.pos)>=2)&&(countLinesAfter(code,editor.pos)>=2)&&isBlankLine(code,editor.pos))
				{
					randClicked=true;
					if(!switchClicked&&!facesClicked)
						rand1=true;
					if((forFinish==6)&&(forStart==1))
					{
						randCorrect=true;
						code = addToCode (code,editor,"rolledNumber = (int)(Math.random() * "+ff+" + "+fs+");\n"+addedTabs(num));
					}
					else
					{
						randCorrect=false;
						errorString = randFalseError;
						showError = true;
					}
				}
				else
				{
					errorString = cantType;
					showError=true;
				}

			}
			// Button inserts a switch statement
			if (GUI.Button (new Rect (Screen.width*0.02f, Screen.height*0.38f, Screen.width*0.1f, Screen.height*0.05f), "Add Switch Statement"))
			{
				editor.MoveLineEnd ();
				int num =getNumOfTabs(code,editor.pos);
				if((countLinesBefore(code,editor.pos)>=2)&&(countLinesAfter(code,editor.pos)>=2)&&isBlankLine(code,editor.pos))
				{
					if(!switchClicked)
					{
						code = addToCode (code,editor,"switch(rolledNumber){\n"+
						                  addedTabs(num)+"\tcase 1:\n"+"\t\t"
						                  +addedTabs(num)+"\n"
						                  +addedTabs(num)+"\t\tbreak;\n"
						                  +addedTabs(num)+"\tcase 2:\n"+"\t\t"
						                  +addedTabs(num)+"\n"
						                  +addedTabs(num)+"\t\tbreak;\n"
						                  +addedTabs(num)+"\tcase 3:\n"+"\t\t"
						                  +addedTabs(num)+"\n"
						                  +addedTabs(num)+"\t\tbreak;\n"
						                  +addedTabs(num)+"\tcase 4:\n"+"\t\t"
						                  +addedTabs(num)+"\n"
						                  +addedTabs(num)+"\t\tbreak;\n"
						                  +addedTabs(num)+"\tcase 5:\n"+"\t\t"
						                  +addedTabs(num)+"\n"
						                  +addedTabs(num)+"\t\tbreak;\n"
						                  +addedTabs(num)+"\tcase 6:\n"+"\t\t"
						                  +addedTabs(num)+"\n"
						                  +addedTabs(num)+"\t\tbreak;\n"
						                  +addedTabs(num)+"\tdefault:\n"
						                  +addedTabs(num)+"\t\tSystem.out.println(\"Wrong value, check your random generation\");");
						switchClicked=true;
					}
					else
					{
						errorString = switch1Error;
						showError = true;
					}
					if(randClicked&&!facesClicked)
						switch2=true;
				}
				else
				{
					errorString = cantType;
					showError=true;
				}
			}


			// Button that assigns a number to face
			if (GUI.Button (new Rect (Screen.width*0.02f, Screen.height*0.48f, Screen.width*0.1f, Screen.height*0.05f), "Assign an int to topFace")) 
			{
				if(randClicked&&switchClicked)
					face3 = true;

				if (((value==1)||(value==2)||(value==3)||(value==4)||(value==5))&&!randClicked&&!switchClicked){
					errorString = cheatError;
					showError = true;

				}
				else if((countLinesBefore(code,editor.pos)>=2)&&(countLinesAfter(code,editor.pos)>=2)&&isBlankLine(code,editor.pos))
				{
					if(countLinesBefore(code,editor.pos)==7)
						if(value==1)
							case1=true;
						else
							case1=false;
					if(countLinesBefore(code,editor.pos)==10)
						if(value==2)
							case2=true;
						else
							case2=false;
					if(countLinesBefore(code,editor.pos)==13)
						if(value==3)
							case3=true;
						else
							case3=false;
					if(countLinesBefore(code,editor.pos)==16)
						if(value==4)
							case4=true;
						else
							case4=false;
					if(countLinesBefore(code,editor.pos)==19)
						if(value==5)
							case5=true;
						else
							case5=false;
					if(countLinesBefore(code,editor.pos)==22)
						if(value==6)
							case6=true;
						else
							case6=false;

					if((case1)&&(case2)&&(case3)&&(case4)&&(case5)&&(case6))
						facesCorrect = true;
					if((value>6)||(value<1))
					{
						errorString = wrongFace;
						showError = true;
					}
					else
					{
						facesClicked=true;
						code = addToCode (code,editor,"topFace = "+value+" ;");
					}

				}
				else
				{
					errorString = cantType;
					showError=true;
				}
			}
			
			// Button that activates the user's code
			if (GUI.Button (new Rect (Screen.width*0.6f, Screen.height*0.9f , Screen.width*0.08f, Screen.height*0.05f), "Submit")) 
			{
				TextChanger.Update();
				if(facesCorrect&&face3&&switch2&&rand1&&randCorrect){
					//code = restoreCode();
					//GameObject.Find("ButtonTrigger").GetComponent<ButtonTrigger>().puzzleComplete = true;
					audio.PlayOneShot(missionComplete);
					//puzzle1Complete = false;
					GameObject.Find("d6").GetComponent<DiceRotateLoaded>().loaded = false;
					GameObject.Find("Initialization").GetComponent<PoisonTime>().cheating = false;
				}
			
				resume();
			}
			
			// Button that closes the UI and disregards changes
			if (GUI.Button (new Rect (Screen.width*0.7f, Screen.height*0.9f , Screen.width*0.08f, Screen.height*0.05f), "Cancel")) 
			{
				code = restoreCode();
				resetValues();
				resume();
			}
			
			// Button that restores the code in the textArea to its original state
			if (GUI.Button (new Rect (Screen.width*0.8f, Screen.height*0.9f , Screen.width*0.08f, Screen.height*0.05f), "Reset")) 
			{
				code = restoreCode();
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

	public void resetValues(){
		text =  "The opponent die is not fair\n"+
				"You need to make it fair.";
				//output = "";
				forStart = 0;
				forFinish = 0;
				value = 0;
				showError = false;
				randClicked = false;
				switchClicked = false;
				facesClicked = false;
				switch2 = false;
				rand1 = false;
				face3 = false;
				facesCorrect = false;
				randCorrect = false;
				case1 = false;
				case2 = false;
				case3 = false;
				case4 = false;
				case5 = false;
				case6 = false;
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
		text =  "The opponent die is not fair\n"+
			"You need to make it fair.";
	}
}
