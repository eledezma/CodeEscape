using UnityEngine;
using System.Collections;

public class TemporaryDeathAnimation : MonoBehaviour 
{

	private bool die;
	private float speed;           //ascending speed
	// Use this for initialization
	void Start ()
	{
		speed = 0.5f;
		die = false;
	}
	
	// Update is called once per frame
	void Update () 
	{
		// if dead rise to heaven
		if(die)
		{
			this.GetComponent<Transform>().Translate(Vector3.up * speed); // Raise the player up if dead
			this.GetComponent<CharacterMotor>().enabled = false;          // disable character controller
		}

		// If rose to heaven reload level 
		if(this.GetComponent<Transform>().position.y>100)                   // when reached height 100 reload level
		{
			Application.LoadLevel(Application.loadedLevel);
		}
	}

	public bool Die{
		get{return die;}
		set{die=value;}
	}
}
