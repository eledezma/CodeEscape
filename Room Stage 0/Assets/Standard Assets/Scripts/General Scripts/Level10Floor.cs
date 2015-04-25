using UnityEngine;
using System.Collections;

public class Level10Floor : MonoBehaviour 
{

	//public enum floorColor{Green, Red, Grey};

	//public floorColor col;
	public Texture red;
	public Texture green;
	// Use this for initialization
	void Start () 
	{
		//col = floorColor.Grey;
	}
	
	// Update is called once per frame
	void Update ()
	{

	}

	public void answer(bool correct)
	{
		//this.gameObject.renderer.material = new Material(Shader.Find("Unlit/Texture"));
		if (correct) 
		{
			this.gameObject.renderer.material.mainTexture = green;
			//col = floorColor.Green;
		} 
		else
		{
			this.gameObject.renderer.material.mainTexture = red;
			//col = floorColor.Red;
		}

	}
}
