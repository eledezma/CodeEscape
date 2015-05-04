using UnityEngine;
using System.Collections;

public class QuestionStart : MonoBehaviour 
{

	public bool isActive;
	// Use this for initialization
	void Start () 
	{
		isActive = true;
	}
	
	// Update is called once per frame
	void Update () 
	{


	}

	void OnTriggerEnter(Collider other)
	{
		if (isActive) 
		{
			if (other.gameObject.tag == "Player") 
			{
				GameObject.Find ("First Person Controller").GetComponent<Questions> ().atWall = true;
			}
		}
	}

	void OnTriggerExit(Collider other)
	{
		if (isActive) 
		{
			if (other.gameObject.tag == "Player") 
			{
				GameObject.Find ("First Person Controller").GetComponent<Questions> ().atWall = false;
			}
		}
	}
}
