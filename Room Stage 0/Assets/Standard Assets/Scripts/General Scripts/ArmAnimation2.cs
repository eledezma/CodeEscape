using UnityEngine;
using System.Collections;

public class ArmAnimation2 : MonoBehaviour 
{
	private Animator animate;
	public float walking;
	public float jackn;
	public float run;
	public bool disable;

	// Use this for initialization
	void Start ()
	{
		animate= GetComponent<Animator>();
		disable = false;
	}
	
	// Update is called once per frame
	void Update () 
	{
	
		if (!disable)
		{
			//if(walking<-1||walking>1){walking=0.0;}
			if(Input.GetKeyDown(KeyCode.LeftShift))
			{
				run++;
				
			}
			if(Input.GetKeyUp(KeyCode.LeftShift))
			{
				run=0;
			}
			
			if(Input.GetKeyDown("w")||Input.GetKeyDown("up"))
			{
				walking++;
				
			}
			if(Input.GetKeyUp("w")||Input.GetKeyUp("up"))
			{
				walking--;
				
			}
			if(Input.GetKeyDown("s")||Input.GetKeyDown("down"))
			{
				walking++;
				
			}
			if(Input.GetKeyUp("s")||Input.GetKeyUp("down"))
			{
				walking--;
				
			}
			if(Input.GetKeyDown("a")||Input.GetKeyDown("left"))
			{
				walking++;
				
			}
			if(Input.GetKeyUp("a")||Input.GetKeyUp("left"))
			{
				walking--;
				
			}
			if(Input.GetKeyDown("d")||Input.GetKeyDown("right"))
			{
				walking++;
				
			}
			if(Input.GetKeyUp("d")||Input.GetKeyUp("right"))
			{
				walking--;
				
			}
		}

		if(Input.GetKeyDown("e"))
		{
			jackn++;
		}
		if(Input.GetKeyUp("e"))
		{
			jackn=0;
		}
	}
	void FixedUpdate()
	{
		animate.SetFloat("walking", walking);
		animate.SetFloat("run", run);
		animate.SetFloat("jackn",jackn);
	}

}
