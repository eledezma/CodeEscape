using UnityEngine;
using System.Collections;

public class ShieldActivate : MonoBehaviour
{
	public int color;
	// Use this for initialization
	void Start ()
	{
		//color = 0; don't add this line because it messes stuff up
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "Player" && this.gameObject.GetComponent<MeshRenderer>().enabled)
		{
			this.gameObject.GetComponent<MeshRenderer>().enabled = false;
			if (color == 1)
			{
				GameObject.Find("First Person Controller").GetComponent<CurrentShield>().shieldStart(1);
			}
			else if (color == 2)
			{
				GameObject.Find("First Person Controller").GetComponent<CurrentShield>().shieldStart(2);
			}
			this.gameObject.GetComponent<ShieldActivate>().enabled = false;
		}

	}
}
