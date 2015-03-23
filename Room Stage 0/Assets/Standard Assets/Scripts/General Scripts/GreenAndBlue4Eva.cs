using UnityEngine;
using System.Collections;

public class GreenAndBlue4Eva : MonoBehaviour {

	private bool green = false;
	private bool blue = false;
	private bool discoParty = false;
	private GUIStyle style = null;
	private float sheildStrength = 0.6f; // 0 < sheildStrength < 1

	//I tried to do this without having to make transparent textures. I just procedurally make a small one 
	//to repeat on the GUI, 
	//IS THIS OK?

	// Update is called once per frame
	void Update () {  //customize the triggers for "sheild", I made them toggles for now
		if (Input.GetKeyDown("1")) //green
		{
			if(green==false && blue==false)
			{
				green=true;
			}
			else if(green==false && blue==true)
			{
				blue=false;
				green=true;
			}
			else
				green=false;
		}
		if (Input.GetKeyDown("2")) //blue
		{
			if(blue==false && green==false)
			{
				blue=true;
			}
			else if(green==true && blue==false)
			{
				blue=true;
				green=false;
			}
			else
				blue=false;
		}
		bool inviteOnly = false;
		if(Input.GetKeyDown("3")){ //YOU CAN'T STOP DA PARTY, BOYZ!!!
			inviteOnly=true;
			discoParty=inviteOnly;
			for(int i=0; i<50;i++){
				OnGUI(); //OnGUI claims to be a function within itself...huh?
			}
		}
	}
	void OnGUI()
	{
		if (green)
		{
			Colors(0f, 1f, 0f);
			GUI.Box(new Rect(0, 0, Screen.width, Screen.height),"",style);
		}
		if(blue)
		{
			Colors(0f, 0f, 1f);
			GUI.Box(new Rect(0, 0, Screen.width, Screen.height),"",style);
		}
		if (discoParty) 
		{
			Colors(Random.Range(0f,1f),Random.Range(0f,1f),Random.Range(0f,1f));
			GUI.Box(new Rect(0, 0, Screen.width, Screen.height),"",style);
		}
	}

	private void Colors(float r, float g, float b)
	{
		style = new GUIStyle( GUI.skin.box );
		style.normal.background = MakeTex( 2, 2, new Color(r, g, b,sheildStrength)); //how transparent do you want it?
	}

	private Texture2D MakeTex( int width, int height, Color col )
	{
		Color[] pix = new Color[width * height];
		for( int i = 0; i < pix.Length; ++i )
		{
			pix[ i ] = col;
		}
		Texture2D result = new Texture2D( width, height );
		result.SetPixels( pix );
		result.Apply();
		return result;
	}

}
