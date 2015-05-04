using UnityEngine;
using System.Collections;

public class Level10FloorPanel : MonoBehaviour {
	
	public int problem;
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
				GameObject.Find ("First Person Controller").GetComponent<Questions> ().questionNumber = problem;
				if (GameObject.Find ("First Person Controller").GetComponent<GreenAndBlue4Eva> ().green) 
				{
					GameObject.Find ("First Person Controller").GetComponent<GreenAndBlue4Eva> ().greenTime = true;
				}
			}
		}
	}
	/*
	void OnTriggerExit(Collider other)
	{
		if (other.gameObject.tag == "Player" && this.gameObject.transform.parent.gameObject.GetComponent<Level10Floor>().col ==  Level10Floor.floorColor.Green) 
		{
			isActive = false;
		}
	}
	*/
}
