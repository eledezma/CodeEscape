using UnityEngine;
using System.Collections;

public class codingUI : MonoBehaviour {
	bool guiEnabled = false;
	TextEditor editor;
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
			GUI.TextArea (new Rect (200, 50, 600, 600),code);
			editor = (TextEditor)GUIUtility.GetStateObject(typeof(TextEditor), GUIUtility.keyboardControl);

			GUI.Label(new Rect(500, 500, 200, 200), string.Format("Selected text: {0}\nPos: {1}\nSelect pos: {2}",
			                                                    editor.SelectedText,
			                                                    editor.pos,
			                                                    editor.selectPos));
			// inserts a for loop
			if (GUI.Button (new Rect (20, 100, 120, 20), "For Loop")) {
				code = addToCode (code,editor,"For(;;){};\n");
			}
		
			// inserts a while loop
			if (GUI.Button (new Rect (20, 125, 120, 20), "While Loop")) {
				code = addToCode (code,editor,"while(){};\n");

			}

			// inserts the method that shoots a bullet
			if (GUI.Button (new Rect (20, 150, 120, 20), "Shooting Method")) {
				code = addToCode (code,editor,"shoot();\n");
			}
		}
	}

	public string addToCode(string s,TextEditor e,string added){
		s = s.Insert(e.pos,added);
		return s;
	}


}
