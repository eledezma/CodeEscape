﻿using UnityEngine;
using System.Collections;

public class Level10Health : MonoBehaviour 
{
	GameObject[] NumQuestions;
	public float health;
	public bool guiEnabled;
	bool textureEnabled;
	Texture2D texture;
	// Use this for initialization
	void Start () 
	{
		guiEnabled = true;
		textureEnabled = true;
		health = 100;
	}
	
	// Update is called once per frame
	void Update () {
		if(health<1)
		{
			health = 100;
			GameObject.Find("First Person Controller").transform.position = new Vector3(-32.01288F, 8.895495F, 121.8482F);
			GameObject.Find("First Person Controller").transform.rotation = Quaternion.identity;
			GameObject.Find("First Person Controller").GetComponent<Questions>().correctNum = 0;
			if (!GameObject.Find("First Person Controller").GetComponent<GreenAndBlue4Eva>().green)
			{
				GameObject.Find("First Person Controller").GetComponent<GreenAndBlue4Eva>().greenTime = true;
			}
			NumQuestions = GameObject.FindGameObjectsWithTag("Question");
			for (int i = 0; i < NumQuestions.Length; i++)
			{
				NumQuestions[i].GetComponent<Level10FloorPanel>().active = true;
			}
		}
		if (!guiEnabled && textureEnabled)
		{
			texture.SetPixel (0,0,Color.clear);
			texture.Apply ();
			textureEnabled = false;
		}
	
	}
	
	public void OnGUI(){
		if (guiEnabled)
		{
			textureEnabled = true;
			GUI.Label(new Rect(10,0,200.0f,20.0f),"Health");
			if(health>1)
			{
				DrawQuad(new Rect(10,20,health*2.0f,10.0f), Color.red);
			}
		}

	}
	
	public void DrawQuad(Rect position, Color color) {
		texture = new Texture2D(1, 1);
		texture.SetPixel(0,0,color);
		texture.Apply();
		GUI.skin.box.normal.background = texture;
		GUI.Box(position, GUIContent.none);
	}
}
