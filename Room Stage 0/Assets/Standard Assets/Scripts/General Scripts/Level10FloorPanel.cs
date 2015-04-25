using UnityEngine;
using System.Collections;

public class Level10FloorPanel : MonoBehaviour {
	
	public int problem;
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
				GameObject.Find ("First Person Controller").GetComponent<Questions> ().questionNumber = problem;
				GameObject.Find ("First Person Controller").GetComponent<Questions> ().atWall = true;
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
			active = false;
		}
	}
	*/
}
