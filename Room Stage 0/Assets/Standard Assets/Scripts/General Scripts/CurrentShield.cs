using UnityEngine;
using System.Collections;

public class CurrentShield : MonoBehaviour
{

	public int shield;
	public int i;  //public for testing
	private bool shieldActive;

	// Use this for initialization
	void Start () 
	{
		i = 0;
		shield = 0;
		shieldActive = false;
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}

	public void shieldStart(int color)
	{
		shield = color;

		if (color == 1) 
		{
			GameObject.Find("First Person Controller").GetComponent<GreenAndBlue4Eva>().blueTime = true;
			//change to blue cam
		} 
		else if (color == 2)
		{
			GameObject.Find("First Person Controller").GetComponent<GreenAndBlue4Eva>().greenTime = true;
			//change to green cam
		}

		i = 0;

		if (!shieldActive) 
		{
			StartCoroutine (shieldDuration ());
		}
	}

	IEnumerator shieldDuration()
	{
		shieldActive = true;

		for (; i < 50; i++) 
		{
			yield return new WaitForSeconds(0.2F);
		}
		if (i == 50) //bring back regular cam
		{
			if (shield == 1)
			{
				GameObject.Find("First Person Controller").GetComponent<GreenAndBlue4Eva>().blueTime = true;
			}
			else if (shield == 2)
			{
				GameObject.Find("First Person Controller").GetComponent<GreenAndBlue4Eva>().greenTime = true;
			}

			shield = 0;
		}
		shieldActive = false;

	}
}
