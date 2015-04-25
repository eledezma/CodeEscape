using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour 
{

	public float health;
	public bool guiEnabled;
	bool textureEnabled;
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
			this.GetComponent<TemporaryDeathAnimation>().die = true;
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
