using UnityEngine;
using System.Collections;

public class codingUI : MonoBehaviour {
	bool guiEnabled = false;
	void Update()
	{
				if (Input.GetKeyDown ("escape")) {
						if (guiEnabled)
								guiEnabled = false;
						else
								guiEnabled = true;
				}
	}

	void OnGUI()
	{
		if (guiEnabled) {
						GUI.Box (new Rect (10, 10, 1000, 900), "List of Functions");
		
						// inserts a for loop
						if (GUI.Button (new Rect (20, 100, 120, 20), "For Loop")) {
								//do somehting
						}

						// inserts a while loop
						if (GUI.Button (new Rect (20, 125, 120, 20), "While Loop")) {
								//do something
						}

						// inserts the method that shoots a bullet
						if (GUI.Button (new Rect (20, 150, 120, 20), "Shooting Method")) {
								//do something
						}

						// inserts the method that shoots a bullet
						GUI.TextArea (new Rect (200, 50, 600, 600), "Code appears here");
				}

	}

}
