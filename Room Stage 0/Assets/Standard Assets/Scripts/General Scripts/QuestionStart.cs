using UnityEngine;
using System.Collections;

public class QuestionStart : MonoBehaviour 
{

	public bool active;
	// Use this for initialization
	void Start () 
	{
		active = true;
	}
	
	// Update is called once per frame
	void Update () 
	{


	}

	void OnTriggerEnter(Collider other)
	{
		if (active) 
		{
			if (other.gameObject.tag == "Player") 
			{
				GameObject.Find ("First Person Controller").GetComponent<Questions> ().atWall = true;
			}
		}
	}
}
