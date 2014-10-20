using UnityEngine;
using System.Collections;

public class MakeOrder : MonoBehaviour {
	
	public static string order="";
	bool guiEnabled=false;
	public static bool atOrderWall= false;
	public Texture2D cursorImage;
	GUIStyle title;
	
	// Use this for initialization
	
	void OnTriggerEnter(Collider wall){
		
		atOrderWall = true;
	}
	
	void OnTriggerExit(Collider wall){
		atOrderWall=false;
		guiEnabled=false;
	}
	
	void Start(){
		Screen.lockCursor = true;
	}
	//Switches the GUI on and off
	//*******************************************************
	void Update()
	{
		if (atOrderWall) {
			if (Input.GetKeyDown ("p")) {
				
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
		else {
			
			Screen.lockCursor = true;
			Screen.lockCursor = false; //Cursor remains locked if not in terminal
		}
	}
	
	public void OnGUI()
	{
		
		if (!atOrderWall) {  //If not at wall terminal jack in - "show crosshair"
			Vector3 mPos = Input.mousePosition;
			GUI.DrawTexture (new Rect (mPos.x - 32, Screen.height - mPos.y - 32, 64, 64), cursorImage);
		} 
		
		else if (atOrderWall && Input.GetKeyDown ("p")) { 
			
			//If at wall terminal show default cursor instead
		}
		
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
				
				TextChanger_Stage2.Update();
				resume();
			}
		}
	}
	
	public void resume(){
		Time.timeScale = 1.0f;
		guiEnabled = false;
		GameObject.Find("Main Camera").GetComponent<MouseLook>().enabled=true;
		GameObject.Find("First Person Controller").GetComponent<MouseLook>().enabled=true;
	}
	
}
