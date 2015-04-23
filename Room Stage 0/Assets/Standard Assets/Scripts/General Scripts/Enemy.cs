using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour
{
	public float timer=1.35f;
	public string state = "patrol";
	public Transform player;
	public Transform[] waypoints;
	public int detectionRange = 50;
	public int attackRange = 4;
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
			//if(!decrement)	
			//{
				speed = originalSpeed;
			//}
			Target = new Vector3(player.position.x,player.position.y-3,player.position.z);
			MoveDirection = Target - myTransform.position;
			Velocity = MoveDirection.normalized * speed;
			rigidbody.velocity = Velocity;
			myTransform.LookAt(Target);
			enemy.animation.Play("Run");
		}
			break;
		//case "pausing":
	//	{
	//		decrement = true;
//			speed = 0;
//		}
//			break;
		case "attacking":
		{
			//speed = attackSpeed;
			speed = 0;
			Target = player.position;
			MoveDirection = Target - myTransform.position;
			Velocity = MoveDirection.normalized * speed;
			rigidbody.velocity = Velocity;
			enemy.animation.Play("Attack");
			timer-=Time.deltaTime;
				
			if(timer<0){
				timer=1.35f;
				go.GetComponent<Player>().health-=25;
			}
			
					
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
//		if(distance<1)
//		{
//			state = "repelling";
///			go.GetComponent<Player>().health--;
//			
//		} 
		if(distance<attackRange)
		{
			state = "attacking";
		}

		else if(distance<detectionRange&&(distance>attackRange))
		{
			state = "chasing";
		}
		else
		{
			state = "patrol";
		}

		if(go.GetComponent<Player>().health<1)
		{
			state = "dead";
			enemy.animation.Play("Death");

		}
		if(Input.GetKeyDown("e")&&(state == "attacking"))
		{
			speed = attackSpeed;
			pushedBack = true;
			MoveDirection = player.forward;
			Velocity = MoveDirection.normalized * speed;
			rigidbody.velocity = Velocity;
				attacking=false;
		}

		

//		if(distance<4.5)
//		{
///			state = "repelling";
//			go.GetComponent<Player>().health--;
//				//			
//		} 
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
		else if(distance > 15)
		{
			pushedBack = false;
			state = "chasing";
		}
	}

}
