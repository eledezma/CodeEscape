using UnityEngine;
using System.Collections;

public class codingUI : MonoBehaviour {

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
				guiEnabled = false;
			}
			else
			{
				guiEnabled = true;
			}
		}
	}
	//*******************************************************


	//Includes all the GUI elements
	//*******************************************************
	public void OnGUI()
	{
		if (guiEnabled) {
			GUI.Box (new Rect (10, 10, 1000, 900), "List of Functions");
		
			// inserts the method that shoots a bullet
			GUI.TextArea (new Rect (260, 50, 600, 600),code);
			editor = (TextEditor)GUIUtility.GetStateObject(typeof(TextEditor), GUIUtility.keyboardControl);

			GUI.Label(new Rect(500, 500, 200, 200), string.Format("Selected text: {0}\nPos: {1}\nSelect pos: {2}\nLines Before: {3}\nLines After: {4}",
			                                                    editor.SelectedText,
			                                                    editor.pos,
			                                                    editor.selectPos,
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
			if (GUI.Button (new Rect (20, 100, 120, 20), "Printout")) 
			{
				if((countLinesBefore(code,editor.pos)>=2)&&(countLinesAfter(code,editor.pos)>=2))
				{
					code = addToCode (code,editor,"System.out.println(\""+text+"\");");
				}
			}

			// Button that inserts a for loop
			if (GUI.Button (new Rect (20, 150, 120, 20), "For Loop")) 
			{
				if((countLinesBefore(code,editor.pos)>=2)&&(countLinesAfter(code,editor.pos)>=2))
				{
					code = addToCode (code,editor,"For(int counter="+fs+";counter<="+ff+";counter++){};\n");
				}
			}

			// Button inserts a while loop
			if (GUI.Button (new Rect (20, 200, 120, 20), "While Loop"))
			{
				{
				if((countLinesBefore(code,editor.pos)>=2)&&(countLinesAfter(code,editor.pos)>=2))
					code = addToCode (code,editor,"while(){};\n");
				}
			}

			// Button that inserts the method that shoots a bullet
			if (GUI.Button (new Rect (20, 250, 120, 20), "Shooting Method")) 
			{
				if((countLinesBefore(code,editor.pos)>=2)&&(countLinesAfter(code,editor.pos)>=2))
				{
					code = addToCode (code,editor,"shoot();\n");
				}
			}

			// Button that restores the code in the textArea to its original state
			if (GUI.Button (new Rect (800, 20, 120, 20), "Reset")) 
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
}
