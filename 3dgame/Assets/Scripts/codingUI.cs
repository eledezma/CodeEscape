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

	void Update()
	{
				if (Input.GetKeyDown ("escape")) {
						if (guiEnabled)
								guiEnabled = false;
						else
								guiEnabled = true;
				}
	}

	public void OnGUI()
	{
		if (guiEnabled) {
			GUI.Box (new Rect (10, 10, 1000, 900), "List of Functions");
		
			// inserts the method that shoots a bullet
			GUI.TextArea (new Rect (260, 50, 600, 600),code);
			editor = (TextEditor)GUIUtility.GetStateObject(typeof(TextEditor), GUIUtility.keyboardControl);

			GUI.Label(new Rect(500, 500, 200, 200), string.Format("Selected text: {0}\nPos: {1}\nSelect pos: {2}",
			                                                    editor.SelectedText,
			                                                    editor.pos,
			                                                    editor.selectPos));

			int temp;

			//print statement textfield
			//*******************************************************
			text = GUI.TextField (new Rect (140,100,40,20), text);
			//*******************************************************


			// for loop starting value textfield
			//*******************************************************
			string fs = GUI.TextField (new Rect (140,125,40,20), forStart.ToString());
			if (int.TryParse(fs,out temp))
			{
				forStart = Mathf.Clamp(temp,0,100);
			}
			else if (fs == "")
			{
				forStart = 0;
			}
			//*******************************************************

			//for loop ending value textfield
			//*******************************************************
			string ff = GUI.TextField (new Rect (180,125,40,20), forFinish.ToString());
			if (int.TryParse(ff,out temp))
			{
				forFinish = Mathf.Clamp(temp,0,100);
			}
			else if (ff == "")
			{
				forFinish = 0;
			}
			//*******************************************************

			// inserts a print statement
			if (GUI.Button (new Rect (20, 100, 120, 20), "Printout")) {
				code = addToCode (code,editor,"System.out.println(\""+text+"\");");
			}

			// inserts a for loop
			if (GUI.Button (new Rect (20, 125, 120, 20), "For Loop")) {
				code = addToCode (code,editor,"For(int counter="+fs+";counter<="+ff+";counter++){};\n");
			}

			// inserts a while loop
			if (GUI.Button (new Rect (20, 150, 120, 20), "While Loop")) {
				code = addToCode (code,editor,"while(){};\n");

			}

			// inserts the method that shoots a bullet
			if (GUI.Button (new Rect (20, 175, 120, 20), "Shooting Method")) {
				code = addToCode (code,editor,"shoot();\n");
			}
		}
	}

	public string addToCode(string s,TextEditor e,string added){
		s = s.Insert(e.pos,added);
		return s;
	}


}
