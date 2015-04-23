using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour
{
	public string state = "patrol";
	public Transform player;
	public Transform[] waypoints;
	public int detectionRange = 50;
	public int attackRange = 5;
	public int attackSpeed = 15;
	public int originalSpeed = 6;
	public int curWayPoint = 0;
	public int rotationSpeed = 6;
	public float distance;
	public int speed;
	Vector3 Velocity;
	public Vector3 MoveDirection;
	Vector3 Target;
	GameObject go;
	GameObject enemy;
	public float time = 2000;
	bool decrement = false;
	public bool attacking = false;
	bool pushedBack = false;
	AnimationClip Walk;
	
	private Transform myTransform;
	void awake()
	{
		
	}
	
	// Use this for initialization
	void Start()
	{
		myTransform = transform;
		go = GameObject.Find("First Person Controller");
		enemy = GameObject.Find("SPIDER");
		player = go.transform;
		speed = originalSpeed;
		enemy.animation["Walk"].wrapMode = WrapMode.Loop;
		enemy.animation.Play("Walk");
	}
	
	// Update is called once per frame
	void Update()
	{
		//go.animation.Play();
		distance = Vector3.Distance(player.position,myTransform.position);
		if(!pushedBack)
		{
		switch (state)
		{
		case "patrol":
		{
			if(!decrement)
				{
					speed = originalSpeed;
				}
			if(curWayPoint<waypoints.Length)
			{
				Target = waypoints[curWayPoint].position;
				MoveDirection = Target - myTransform.position;
				Velocity = rigidbody.velocity;
				if(MoveDirection.magnitude <1)
				{
					curWayPoint++;
				}
				else
				{
					Velocity = MoveDirection.normalized * speed;		
				}
			}
			else
			{
				curWayPoint = 0;
			}
			rigidbody.velocity = Velocity;
			myTransform.LookAt(Target);
		}
			break;
		case "chasing":
		{
			if(!decrement)	
			{
				speed = originalSpeed;
			}
			Target = new Vector3(player.position.x,player.position.y-3,player.position.z);
			MoveDirection = Target - myTransform.position;
			Velocity = MoveDirection.normalized * speed;
			rigidbody.velocity = Velocity;
			myTransform.LookAt(Target);
		}
			break;
		//case "pausing":
	//	{
	//		decrement = true;
//			speed = 0;
//		}
			break;
		case "attacking":
		{
			speed = attackSpeed;
			Target = player.position;
			MoveDirection = Target - myTransform.position;
			Velocity = MoveDirection.normalized * speed;
			rigidbody.velocity = Velocity;
				enemy.animation.Play("Attack");


		}
			break;
		case "repelling":
		{
			MoveDirection = Target + myTransform.position;
			attacking = false;
		}
			break;
		case "dead":
		{
			this.GetComponent<Rigidbody>().useGravity = true;
		}
			break;
	}
		if(distance<1)
		{
			state = "repelling";
			go.GetComponent<Player>().health--;
			
		} 
		else if((distance<attackRange)&&(!attacking))
		{
			state = "attacking";
		}

		else if(distance<detectionRange&&!attacking)
		{
			state = "chasing";
		}
		else if(!attacking)
		{
			state = "patrol";
		}

		if(go.GetComponent<Player>().health<1)
		{
			state = "dead";
		}
		}
		if(Input.GetKeyDown("e")&&(state == "attacking" || state == "repelling"))
		{
			pushedBack = true;
			MoveDirection = player.forward;
			Velocity = MoveDirection.normalized * speed;
			rigidbody.velocity = Velocity;
		}

		if(distance > 15)
		{
			pushedBack = false;
		}
/*		if(decrement)
		{
			time-=Time.deltaTime*1000;
		}
		if(time<0)
		{
			state="attacking";
			time = 2000;
			decrement = false;
			attacking = true;
		}*/
	}
}
