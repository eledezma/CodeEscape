using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour 
{

	public float health;
	// Use this for initialization
	void Start () 
	{
		health = 100;
	}
	
	// Update is called once per frame
	void Update () {
		if(health<1)
		{
			this.GetComponent<TemporaryDeathAnimation>().die = true;
		}


	}

	public void OnGUI(){
		GUI.Label(new Rect(10,0,200.0f,20.0f),"Health");
		if(health>1)
		DrawQuad(new Rect(10,20,health*2.0f,10.0f), Color.red);

	}

	public void DrawQuad(Rect position, Color color) {
		Texture2D texture = new Texture2D(1, 1);
		texture.SetPixel(0,0,color);
		texture.Apply();
		GUI.skin.box.normal.background = texture;
		GUI.Box(position, GUIContent.none);
	}
}
