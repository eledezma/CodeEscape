using UnityEngine;
using System.Collections;

public class Indentation : MonoBehaviour {
	bool puzzle1Complete = false;
	bool guiEnabled = false;
	bool atWall = false;
	public AudioClip missionComplete;
	TextEditor editor;
	public Texture2D cursorImage;
	public int height1=0;
	public int height2=0;
	public int height3=0;
	public int height4=0;
	public int height5=0;
	public int height6=0;
	public int height7=0;
	string output="Door is open";

	//GameObject Arms;
	public string code = "public static game{\n" +
				"public static void main(Sring[] args){\n" +
				"if (Door.open == false)\n" +
				"Door.open = true;\n" +
				"System.out.println(\"Door is open\");\n" + 
				"}\n" +
				"}";
	void OnTriggerEnter(Collider other){
		atWall=true;
		GameObject.Find("Arm Camera").camera.enabled = false;
		//Arms.camera.enabled = false;
	}
	void OnTriggerExit(Collider other){
		atWall=false;
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
	void Update()
	{
		if (atWall) {
			if (Input.GetKeyDown ("e")) {
				//			Screen.lockCursor = false;  //Cursor is free to move when user goes into terminal
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
			//Screen.showCursor = false;
			Screen.lockCursor = true;  //Hiding Cursor means redoing the way the crosshair was implemented -Josephs
			Screen.lockCursor = false; //Cursor remains locked if not in terminal
		}
	}
	//*******************************************************
	
	
	//Includes all the GUI elements
	//*******************************************************
	public void OnGUI()
	{
		if (!atWall) {  //If not at wall terminal jack in - "show crosshair"
			Vector3 mPos = Input.mousePosition;
			GUI.DrawTexture (new Rect (mPos.x - 32, Screen.height - mPos.y - 32, 64, 64), cursorImage);
		} 
		
		else if (atWall && Input.GetKeyDown ("e")) { 
			
			//If at wall terminal show default cursor instead
		}
		
		if (guiEnabled) {
			GUI.Box (new Rect (0, 0, Screen.width, Screen.height), "Indentation");
			
			// inserts the method that shoots a bullet
			GUI.TextArea (new Rect (Screen.width*0.2f, Screen.width*0.04f, Screen.width*0.75f, Screen.height*0.75f),code);
			editor = (TextEditor)GUIUtility.GetStateObject(typeof(TextEditor), GUIUtility.keyboardControl);
			
	/*			GUI.Label(new Rect(500, 500, 200, 200), string.Format("Selected text: {0}\nPos: {1}\nSelect pos: {2}\nLines Before: {3}\nLines After: {4}",
			                                                      height1,
			                                                      height2,
			                                                      height3,
			                                                      countLinesBefore(code,editor.pos),
			                                                      height4));*/
			

			// Button that inserts a print statement
			if (GUI.Button (new Rect (Screen.width*0.02f, Screen.height*0.18f, Screen.width*0.1f, Screen.height*0.05f), "Add Tab")) 
			{

				//if((countLinesBefore(code,editor.pos)>=2)&&(countLinesAfter(code,editor.pos)>=2)&&isBlankLine(code,edi
					code = addToCode (code,editor,"\t");
					if (countLinesBefore(code,editor.pos)==0)
						height1--;
					else if (countLinesBefore(code,editor.pos)==1)
						height2--;	
					else if (countLinesBefore(code,editor.pos)==2)
						height3--;	
					else if (countLinesBefore(code,editor.pos)==3)
						height4--;	
					else if (countLinesBefore(code,editor.pos)==4)
						height5--;	
					else if (countLinesBefore(code,editor.pos)==5)
						height6--;	
					else if (countLinesBefore(code,editor.pos)==6)
						height7--;	
			}
			
			// Button that inserts a for loop
			if (GUI.Button (new Rect (Screen.width*0.02f, Screen.height*0.28f, Screen.width*0.1f, Screen.height*0.05f), "Erase Tab")) 
			{
					code = deleteFromCode (code,editor);
				if (countLinesBefore(code,editor.pos)==0)
					height1++;
				else if (countLinesBefore(code,editor.pos)==1)
					height2++;	
				else if (countLinesBefore(code,editor.pos)==2)
					height3++;	
				else if (countLinesBefore(code,editor.pos)==3)
					height4++;	
				else if (countLinesBefore(code,editor.pos)==4)
					height5++;	
				else if (countLinesBefore(code,editor.pos)==5)
					height6++;	
				else if (countLinesBefore(code,editor.pos)==6)
					height7++;	
			}

			
			// Button that activates the user's code
			if (GUI.Button (new Rect (Screen.width*0.6f, Screen.height*0.9f , Screen.width*0.08f, Screen.height*0.05f), "Submit")) 
			{
				TextChanger.Update();
				GameObject.Find ("Cube1").GetComponent<MoveBlock>().height = height1;
				GameObject.Find ("Cube2").GetComponent<MoveBlock>().height = height2;
				GameObject.Find ("Cube3").GetComponent<MoveBlock>().height = height3;
				GameObject.Find ("Cube4").GetComponent<MoveBlock>().height = height4;
				GameObject.Find ("Cube5").GetComponent<MoveBlock>().height = height5;
				GameObject.Find ("Cube6").GetComponent<MoveBlock>().height = height6;
				GameObject.Find ("Cube7").GetComponent<MoveBlock>().height = height7;

				if((height1==0)&&(height2==-1)&&(height3==-2)&&(height4==-3)&&(height7==0)&&(height6==-1)&&(height5==-2))
				audio.PlayOneShot(missionComplete);
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
				height1=0;
				height2=0;
				height3=0;
				height4=0;
				height5=0;
				height6=0;
				height7=0;

				GameObject.Find ("Cube1").GetComponent<MoveBlock> ().height = 0;
				GameObject.Find ("Cube2").GetComponent<MoveBlock> ().height = 0;
				GameObject.Find ("Cube3").GetComponent<MoveBlock> ().height = 0;
				GameObject.Find ("Cube4").GetComponent<MoveBlock> ().height = 0;
				GameObject.Find ("Cube5").GetComponent<MoveBlock> ().height = 0;
				GameObject.Find ("Cube6").GetComponent<MoveBlock> ().height = 0;
				GameObject.Find ("Cube7").GetComponent<MoveBlock> ().height = 0;

			}
		}
	}
	
	//Adds new Code to the TextArea based on the user input
	//*******************************************************
	public string addToCode(string s,TextEditor e,string added)
	{
		char[] a = s.ToCharArray();
		if (e.pos==0)
			s = s.Insert(e.pos,added);
		else if (a[e.pos-1]=='\n')
			s = s.Insert(e.pos,added);
		return s;
	}

	public string deleteFromCode(string s,TextEditor e)
	{
		char[] a = s.ToCharArray();
		if (a [e.pos] == '\t')
			s = s.Remove(e.pos,1);
		else if (a [e.pos-1] == '\t')
			s = s.Remove(e.pos-1,1);
		return s;
	}
	
	public string restoreCode()
	{
		string dummy= "public static game{\n" +
			"public static void main(Sring[] args){\n" +
				"if (Door.open == false)\n" +
				"Door.open = true;\n" +
				"System.out.println(\"Door is open\");\n" + 
				"}\n" +
				"}";
		return dummy;
	}

	public int countLinesBefore(string s, int position)
	{
		int lines = 0;
		char[] a = s.ToCharArray ();
		for (int i=0; i<position; i++)
		{
			if(i!=a.Length)
			{
				if(a[i]=='\n')
					lines++;
			}
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
	}
}
