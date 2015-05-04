using UnityEngine;
using System.Collections;

public class DebugMainMenu : MonoBehaviour 
{
	
	private bool debugTime;
	
	void Start()
	{
		debugTime = false;
	}
	
	void  Update ()
	{
		if (Input.GetKeyDown (KeyCode.Q))
		{
			debugTime = !debugTime;
		}
	}
	
	void  OnGUI ()
	{
		if (debugTime)
		{
			if (GUI.Button( new Rect(40,40,40,40),"M"))
			{
				Application.LoadLevel (0);
			}
			if (GUI.Button( new Rect(80,40,40,40),"1"))
			{
				Application.LoadLevel (1);
			}
			if (GUI.Button( new Rect(120,40,40,40),"2"))
			{
				Application.LoadLevel (2);
			}
			if (GUI.Button( new Rect(160,40,40,40),"3"))
			{
				Application.LoadLevel (3);
			}
			if (GUI.Button( new Rect(200,40,40,40),"4"))
			{
				Application.LoadLevel (4);
			}
			if (GUI.Button( new Rect(240,40,40,40),"5"))
			{
				Application.LoadLevel (5);
			}
			if (GUI.Button( new Rect(40,80,40,40),"6"))
			{
				Application.LoadLevel (6);
			}
			if (GUI.Button( new Rect(80,80,40,40),"7"))
			{
				Application.LoadLevel (7);
			}
			if (GUI.Button( new Rect(120,80,40,40),"8"))
			{
				Application.LoadLevel (8);
			}
			if (GUI.Button( new Rect(160,80,40,40),"9"))
			{
				Application.LoadLevel (9);
			}
			if (GUI.Button( new Rect(200,80,40,40),"10"))
			{
				Application.LoadLevel (10);
			}
			if (GUI.Button( new Rect(240,80,40,40),"11"))
			{
				Application.LoadLevel (11);
			}
		}
		
	}
}

