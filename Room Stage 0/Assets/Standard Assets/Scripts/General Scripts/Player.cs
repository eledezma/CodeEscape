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
}
