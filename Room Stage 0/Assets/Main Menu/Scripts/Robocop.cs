using UnityEngine;
using System.Collections;

public class Robocop : MonoBehaviour {
	public Transform player;
	public Transform friend;
	public Transform enemy;
	public Transform[] waypoints;
	public int detectionRange = 50;
	public int originalSpeed = 6;
	public int curWayPoint = 0;
	public int rotationSpeed = 6;
	public int speed;
	Vector3 Velocity;
	public Vector3 MoveDirection;
	Vector3 Target;
	public float distance;
	public float enemybotDistance;
	GameObject go;
	GameObject bot;
	GameObject e;
	public float time = 2000;
	bool decrement = false;
	AnimationClip Walk;
	private Transform myTransform;
	public GameObject bullet_prefab;
	float bulletImpulse = 60f;
	// Use this for initialization
	void Start () {
		myTransform = transform;
		go = GameObject.Find("First Person Controller");
		bot= GameObject.Find("rob");
		e= GameObject.Find("SPIDER");
		friend = bot.transform;
		enemy = e.transform;
		player = go.transform;
		speed = originalSpeed;
		//enemy.animation["Walk"].wrapMode = WrapMode.Loop;
		//enemy.animation.Play("Walk");
	}
	
	// Update is called once per frame
	void Update () {
		
		distance = Vector3.Distance(player.position,friend.position);
		enemybotDistance = Vector3.Distance(enemy.position,friend.position);
		//{
		speed = originalSpeed;
		//}
		
		if (distance > 10) {
			
			Target = new Vector3 (player.position.x, player.position.y-2, player.position.z);
			MoveDirection = Target - myTransform.position;
			Velocity = MoveDirection.normalized * speed;
			rigidbody.velocity = Velocity;
			myTransform.LookAt (Target);
		} else {
			MoveDirection = myTransform.position;
			Velocity = MoveDirection.normalized * speed;
			rigidbody.velocity = Velocity;
			myTransform.LookAt (Target);
			
		}
		
		if (enemybotDistance < 10) {
			transform.LookAt(enemy);
			GameObject thebullet = (GameObject)Instantiate(bullet_prefab, transform.position, transform.rotation);
			thebullet.tag = "Bullet";
			thebullet.rigidbody.AddForce(transform.forward * bulletImpulse, ForceMode.Impulse);
			
		}
		
		
		
	}
}
