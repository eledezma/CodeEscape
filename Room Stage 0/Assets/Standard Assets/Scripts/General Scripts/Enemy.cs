using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour
{

    public Transform player;
	public Transform[] waypoints;
	public bool patrol = true;
	public int detectionRange = 100;
    public int speed = 8;
	public int curWayPoint = 0;
    public int rotationSpeed = 8;
	public bool attacking = false;
	Vector3 Velocity;
	Vector3 MoveDirection;
	Vector3 Target;

    private Transform myTransform;
    void awake()
    {

    }

    // Use this for initialization
    void Start()
    {
        myTransform = transform;
        GameObject go = GameObject.Find("First Person Controller");
        player = go.transform;
    }

    // Update is called once per frame
    void Update()
    {
		if(attacking)
		{
      		//Debug.DrawLine(target.position, myTransform.position, Color.red);
        	//myTransform.rotation = Quaternion.Slerp(myTransform.rotation, Quaternion.LookRotation(target.position - myTransform.position), rotationSpeed * Time.deltaTime);
        	//myTransform.position += myTransform.forward * speed * Time.deltaTime;
			Target = player.position;
			MoveDirection = Target - myTransform.position;
			Velocity = MoveDirection.normalized * speed;
			rigidbody.velocity = Velocity;
			myTransform.LookAt(Target);
		}
		else if(patrol)
		{
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


		if(Vector3.Distance(player.position,myTransform.position)<detectionRange)
		{
			attacking=true;
			patrol = false;
		}
	}
}
