using UnityEngine;
using System.Collections;

public class ScannerInfo : MonoBehaviour
{
		public bool guiEnabeled = true;
		public string info = "The Scanner class is part of the java.util package." +
				"\nScanner's in java are used to get user input, but" +
				"\n that is not their only purpose. The method nextLine()" +
				"\n is part of the Scanner class and is used to get the " +
				"\n next line the user enters as the input.";
		// Use this for initialization
		void Start ()
		{
				GameObject.Find ("Main Camera").GetComponent<MouseLook> ().enabled = false;
				GameObject.Find ("First Person Controller").GetComponent<MouseLook> ().enabled = false;
				GameObject.Find ("Initialization").GetComponent<CursorTime> ().showCursor = false;
		}
	
		// Update is called once per frame
		void Update ()
		{
	
		}

		public void OnGUI ()
		{
				if (guiEnabeled) {
						GUILayout.Box ("Info");
						GUILayout.TextArea (info);
						//if(GUILayout.Button("Submit")){
						if (Input.GetKeyDown ("e")) {
								resume ();
								//CursorTime.showCursor = false;
						}
				}
		}

		public void resume ()
		{
				Time.timeScale = 1.0f;
				guiEnabeled = false;
				GameObject.Find ("Main Camera").GetComponent<MouseLook> ().enabled = true;
				GameObject.Find ("First Person Controller").GetComponent<MouseLook> ().enabled = true;
				GameObject.Find ("Initialization").GetComponent<CursorTime> ().showCursor = true;
		}
}

