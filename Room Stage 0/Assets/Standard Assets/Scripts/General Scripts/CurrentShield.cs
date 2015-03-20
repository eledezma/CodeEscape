using UnityEngine;
using System.Collections;

public class CurrentShield : MonoBehaviour
{

	public int shield;
	public int i;  //public for testing
	bool start;
	// Use this for initialization
	void Start () 
	{
		shield = 0;
		start = false;
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}

	public void shieldStart(int color)
	{
		start = true;
		shield = color;

		if (color == 1) 
		{
			//change to blue cam
		} 
		else if (color == 2)
		{
			//change to green cam
		}

		StartCoroutine (shieldDuration ());

	}

	IEnumerator shieldDuration()
	{
		start = false;
		for (i = 0; i < 50; i++) 
		{
			if (start)
			{
				break;
			}
			yield return new WaitForSeconds(0.2F);
		}
		if (i == 50)
		{
			//bring back regular cam
			shield = 0;
		}

	}
}
