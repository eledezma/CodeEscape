using UnityEngine;
using System.Collections;

public class codingUI : MonoBehaviour {
	bool puzzle1Complete = false;
	bool puzzle2Complete = false;
	bool puzzle3Complete = false;
	bool puzzle4Complete = false;
	bool puzzle5Complete = false;
	bool puzzle6Complete = false;
	bool puzzle7Complete = false;
	bool puzzle8Complete = false;
	bool puzzle9Complete = false;
	bool puzzle10Complete = false;
	bool guiEnabled = false;
	TextEditor editor;
	string text="";
	int forStart;
	int forFinish;
	public string code="public class game{\n" +
						"\tpublic static void main(String[] args){\n" +
						"\t\t\n" +
						"\t}\n" +
						"}";
	
	//Switches the GUI on and off
	//*******************************************************
	void Update()
	{
		if (Input.GetKeyDown ("escape")) {
			if (guiEnabled)
			{
				Time.timeScale = 1.0f;
				guiEnabled = false;
				GameObject.Find("Main Camera").GetComponent<MouseLook>().enabled=true;
				GameObject.Find("First Person Controller").GetComponent<MouseLook>().enabled=true;
				if (puzzle1Complete){ 
					code = restoreCode();
					GameObject.Find("ButtonTrigger").GetComponent<ButtonTrigger>().puzzleComplete = true;
				}
			}
			else
			{
				Time.timeScale = 0.0f;
				guiEnabled = true;
				GameObject.Find("Main Camera").GetComponent<MouseLook>().enabled=false;
				GameObject.Find("First Person Controller").GetComponent<MouseLook>().enabled=false;

			}
		}

		//checks if the user entered the right solution
		if (text.ToLower() == "hello world"){
			puzzle1Complete = true;	
		}

	}
	//*******************************************************


	//Includes all the GUI elements
	//*******************************************************
	public void OnGUI()
	{
		if (guiEnabled) {
			GUI.Box (new Rect (0, 0, Screen.width, Screen.height), "List of Functions");
		
			// inserts the method that shoots a bullet
			GUI.TextArea (new Rect (260, 50, Screen.width*0.75f, Screen.height*0.75f),code);
			editor = (TextEditor)GUIUtility.GetStateObject(typeof(TextEditor), GUIUtility.keyboardControl);

			GUI.Label(new Rect(500, 500, 200, 200), string.Format("Selected text: {0}\nPos: {1}\nSelect pos: {2}\nLines Before: {3}\nLines After: {4}",
			                                                    editor.SelectedText,
			                                                    editor.pos,
			                                                    0,
			                                                    countLinesBefore(code,editor.pos),
			                                                    countLinesAfter(code,editor.pos)));

			int temp;

			GUI.Label(new Rect(140,80,40,20),("string"));						//print statement title
			text = GUI.TextField (new Rect (140,100,40,20), text);    			//print statement textfield
	
			// for loop starting value textfield
			//*******************************************************
			string fs = GUI.TextField (new Rect (140,150,40,20), forStart.ToString());
			if (int.TryParse(fs,out temp))
			{
				forStart = Mathf.Clamp(temp,0,100);
			}
			else if (fs == "")
			{
				forStart = 0;
			}
			//*******************************************************
			GUI.Label(new Rect(140,130,40,20),("start"));  	//for loop parameter title

			//for loop ending value textfield
			//*******************************************************
			string ff = GUI.TextField (new Rect (180,150,40,20), forFinish.ToString());
			if (int.TryParse(ff,out temp))
			{
				forFinish = Mathf.Clamp(temp,0,100);
			}
			else if (ff == "")
			{
				forFinish = 0;
			}
			//*******************************************************
			GUI.Label(new Rect(180,130,40,20),("finish"));  	//for loop parameter title
			
			// Button that inserts a print statement
			if (GUI.Button (new Rect (20, 100, Screen.width*0.08f, 20), "Printout")) 
			{
				if((countLinesBefore(code,editor.pos)>=2)&&(countLinesAfter(code,editor.pos)>=2)&&isBlankLine(code,editor.pos))
				{
					int num =getNumOfTabs(code,editor.pos);
					code = addToCode (code,editor,"System.out.println(\""+text+"\");\n"+addedTabs(num));

		
			//		int i=getNumOfTabs(code,editor.pos);
			//		while (code.Substring(editor.pos,1)!="\n")
			//		editor.MoveRight();
			//		for(;i>0;i--)
			//		{
			//			code = addToCode(code,editor,"\t");
			//		}
			//		editor.MoveLineEnd();
				}
			}

			// Button that inserts a for loop
			if (GUI.Button (new Rect (20, 150, Screen.width*0.08f, 20), "For Loop")) 
			{
				if((countLinesBefore(code,editor.pos)>=2)&&(countLinesAfter(code,editor.pos)>=2)&&isBlankLine(code,editor.pos))
				{
					code = addToCode (code,editor,"For(int counter="+fs+";counter<="+ff+";counter++){};\n");
				}
			}

			// Button inserts a while loop
			if (GUI.Button (new Rect (20, 200, Screen.width*0.08f, 20), "While Loop"))
			{
				{
					if((countLinesBefore(code,editor.pos)>=2)&&(countLinesAfter(code,editor.pos)>=2)&&isBlankLine(code,editor.pos))
					code = addToCode (code,editor,"while(){};\n");
				}
			}

			// Button that inserts the method that shoots a bullet
			if (GUI.Button (new Rect (20, 250, Screen.width*0.08f, 20), "Shooting Method")) 
			{
				if((countLinesBefore(code,editor.pos)>=2)&&(countLinesAfter(code,editor.pos)>=2)&&isBlankLine(code,editor.pos))
				{
					code = addToCode (code,editor,"shoot();\n");
				}
			}

			// Button that activates the user's code
			if (GUI.Button (new Rect (Screen.width*0.6f, Screen.height*0.9f , Screen.width*0.08f, 20), "Submit")) 
			{

			}

			// Button that closes the UI and disregards changes
			if (GUI.Button (new Rect (Screen.width*0.7f, Screen.height*0.9f , Screen.width*0.08f, 20), "Cancel")) 
			{
				guiEnabled=false;
			}

			// Button that restores the code in the textArea to its original state
			if (GUI.Button (new Rect (Screen.width*0.8f, Screen.height*0.9f , Screen.width*0.08f, 20), "Reset")) 
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
				"\t\t\n" +
				"\t}\n" +
				"}";
		return dummy;
	}
	
	public int countLinesBefore(string s, int position)
	{
		int lines = 0;
		char[] a = s.ToCharArray ();
			for (int i=0; i<position; i++)
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
}
