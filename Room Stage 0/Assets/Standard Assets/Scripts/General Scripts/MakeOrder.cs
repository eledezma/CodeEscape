using UnityEngine;
using System.Collections;

public class MakeOrder : MonoBehaviour {

	string order="";
	bool guiEnabled=false;
	GUIStyle title;
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
		if (Input.GetKeyDown ("p")) {
			if(!guiEnabled)
			guiEnabled=true;
			else
				guiEnabled=false;
		}
	}

	public void OnGUI()
	{
		title = new GUIStyle ();
		title.fontSize = 34;
		title.normal.textColor = Color.white;
		title.alignment = TextAnchor.MiddleCenter;
		GUI.skin.label.fontSize = 18;
		if(guiEnabled)
		{
		GUI.Box (new Rect (0, 0, Screen.width, Screen.height), "");
			GUI.Label (new Rect(Screen.width*.25f, Screen.height*.10f, Screen.width*.50f, Screen.height*.20f),"Make an Order",title);
		GUI.Box (new Rect (Screen.width*.25f, Screen.height*.30f, Screen.width*.50f, Screen.height*.50f), "");
			GUI.Label (new Rect(Screen.width*.4f, Screen.height*.37f, Screen.width*.2f, Screen.height*.05f),"What would you like to order?");
		order = GUI.TextField (new Rect (Screen.width * .40f, Screen.height * .52f, Screen.width * .20f, Screen.height * 0.05f),order);
		if (GUI.Button (new Rect (Screen.width*0.46f, Screen.height*0.60f, Screen.width*0.08f, Screen.height*0.05f), "Feed Me!")){ 

		}
		}
	}
}
