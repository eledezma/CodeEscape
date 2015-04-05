using UnityEngine;
using System.Collections;

public class TemporaryDeathAnimation : MonoBehaviour 
{

	public bool die = false;
	public float speed = 0.5f;
	// Use this for initialization
	void Start ()
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		// if dead rise to heaven
		if(die)
		{
			this.GetComponent<Transform>().Translate(Vector3.up * speed);
		}

		// If rose to heaven reload level
		if(this.GetComponent<Transform>().position.y>100)
		{
			Application.LoadLevel(Application.loadedLevel);
		}
	}
}
