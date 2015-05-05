using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour 
{

	private float health;
	private bool guiEnabled;   // to disable health bar when need to
	public bool textureEnabled;
	Texture2D texture;
	// Use this for initialization
	void Start () 
	{
		guiEnabled = true;
		health = 100;
	}
	
	// Update is called once per frame
	void Update ()
	{
		if(health<1)
		{
			this.GetComponent<TemporaryDeathAnimation>().Die = true;
		}
		if (!guiEnabled && textureEnabled)            //disable health bar
		{
			texture.SetPixel (0,0,Color.clear);
			texture.Apply ();
			textureEnabled = false;
		} 
	}

	public void OnGUI(){                           //draws a health bar with width relative to player's health
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

	public void DrawQuad(Rect position, Color color) {            // Draws a box
		texture = new Texture2D(1, 1);
		texture.SetPixel(0,0,color);
		texture.Apply();
		GUI.skin.box.normal.background = texture;
		GUI.Box(position, GUIContent.none);
	}

	public bool GuiEnabled{
		get{ return guiEnabled; }
		set{ guiEnabled = value; }
	}
	public float Health{
		get{ return health; }
		set{ health = value; }
	}
}
