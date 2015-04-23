using UnityEngine;
using System.Collections;

public class Level10FloorPanel : MonoBehaviour {
	
	public int problem;
	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "Player" && GameObject.Find("First Person Controller").GetComponent<GreenAndBlue4Eva>().green) 
		{
			GameObject.Find("First Person Controller").GetComponent<GreenAndBlue4Eva>().greenTime = true;
		}
	}

	void OnTriggerExit(Collider other)
	{
		if (other.gameObject.tag == "Player" && this.gameObject.transform.parent.gameObject.GetComponent<Level10Floor>().col ==  Level10Floor.floorColor.Green) 
		{
			GameObject.Find("First Person Controller").GetComponent<GreenAndBlue4Eva>().greenTime = true;
			Destroy (this);
		}
	}

}
