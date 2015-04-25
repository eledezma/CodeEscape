using UnityEngine;
using System.Collections;

public class StarPanel : MonoBehaviour 
{
	public Texture darkstar;
	public Texture greybak;
	public Texture yellowstar;
	public Texture yellowbak;
	public GameObject plane;

	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update ()
	{
		/*
		if (Input.GetKeyDown (KeyCode.U)) 
		{
			plane.renderer.material.mainTexture = darkstar;
			this.gameObject.renderer.material.mainTexture = greybak;
		
		}
		else if (Input.GetKeyDown (KeyCode.I))
		{
			GameObject.Find ("StarTrigger").GetComponent<StarTrig> ().active = true;
			plane.renderer.material.mainTexture = yellowstar;
			this.gameObject.renderer.material.mainTexture = yellowbak;
		}*/
	}

	public void dark()
	{
		StartCoroutine(GameObject.Find("StarVideo").GetComponent<Level10Video>().PlayVideo ());
		GameObject.Find("DoorFinal").transform.position = new Vector3(176.5465F, 8.741457F, 331.659F);
		GameObject.Find("DoorFinal").transform.Rotate (new Vector3(0,270,0));
		GameObject.Find ("StarTrigger").GetComponent<StarTrig> ().active = false;
		plane.renderer.material.mainTexture = darkstar;
		this.gameObject.renderer.material.mainTexture = greybak;
	}

	public void yellow()
	{
		GameObject.Find ("StarTrigger").GetComponent<StarTrig> ().active = true;
		plane.renderer.material.mainTexture = yellowstar;
		this.gameObject.renderer.material.mainTexture = yellowbak;


	}
}
