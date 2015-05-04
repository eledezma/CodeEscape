using UnityEngine;
using System.Collections;

public class Robot : MonoBehaviour {
	public AudioClip ButtonClick;
	private Transform player;
	private Transform friend;
	private Transform enemy;
	private string state = "patrol";
	private Vector3 Velocity;
	private Vector3 MoveDirection;
	private Vector3 Target;
	private float friendDistance;
	private float playerEnemyDistance;
	private float enemyFriendDistance;
	private GameObject fpc;
	private GameObject bot;
	private GameObject spider;
	private int shootTime = 0;
	private bool attacking = false;
	private AnimationClip Walk;
	private Transform myTransform;
	public GameObject bullet_prefab;
	private float bulletImpulse = 10f;
	private int maxFriendPlayerDistance = 10;
	private int maxEnemyFriendDistance1 = 12;
	private int maxEnemyFriendDistance2 = 8;
	private int bulletCooldown = 100;
	private GameObject theSpider;
	private Enemy spiderScript;
	private float distToGround;
	// Use this for initialization
	void Start () {  
		//grabbing all objects from screen and referencing them
		distToGround = (float)(collider.bounds.extents.y);
		theSpider = GameObject.Find("SPIDER");
		spiderScript = theSpider.GetComponent<Enemy>();
		myTransform = transform;
		fpc = GameObject.Find("First Person Controller");
		bot= GameObject.Find("rob");
		spider= GameObject.Find("SPIDER");
		friend = bot.transform;
		enemy = spider.transform;
		player = fpc.transform;
		friend.animation["Anim_Walk"].wrapMode = WrapMode.Loop;;
	}
	
	// Update is called once per frame
	void Update () {
		if (myTransform.position.y < 0.5f) {
			myTransform.Translate (0, 0.05f, 0);  //keeps robot from sinking through the floor
		}
		//gets distances between enemy, player, and friend
		friendDistance = Vector3.Distance (player.position, friend.position);
		enemyFriendDistance = Vector3.Distance (enemy.position, friend.position);
		
		if(IsGrounded()){	
			switch (state) {
			case "patrol":  //Friendly AI is on patrol mode, protecting player
			{
				if (friendDistance >  maxFriendPlayerDistance) {  //if friendly AI is distant then allow him to come 
					Target = new Vector3 (player.position.x, 1, player.position.z); //retrieve only x,z position
					MoveDirection = Target - myTransform.position; // get vector distance from friend to player
					Velocity = MoveDirection.normalized * 6; //give some force
					rigidbody.velocity = Velocity;  
					myTransform.LookAt (Target);  //look at player
				} else {  //if distance between player is close to 10 dont come anymore closer
					Velocity = MoveDirection.normalized * 0;
					rigidbody.velocity = Velocity;
					myTransform.LookAt (Target);		
				}
			}
				break;
				
			case "enemyEngaged":  //when enemy is close to player
			{
				if (enemyFriendDistance > maxEnemyFriendDistance2) {  //if friend is close to enemy follow 
					Target = new Vector3 (enemy.position.x, 1, enemy.position.z);  //get position of enemy
					MoveDirection = Target - friend.position;  //calculate vector from friend to enemy
					Velocity = MoveDirection.normalized * 6;
					rigidbody.velocity = Velocity;
					myTransform.LookAt (enemy);
				} else {
					Velocity = MoveDirection.normalized * 0;
					rigidbody.velocity = Velocity;
				}
				
				if (enemyFriendDistance < maxEnemyFriendDistance1) {  //if enemy gets really close to friend then friend shoots spider
					Vector3 temp = friend.transform.position;
					temp.y = 4.0f; //vertical position where bullets shoot from
					
					if(shootTime > bulletCooldown){  //shoot cooldown, keeps friend from shooting too much at a time
						
						GameObject thebullet = (GameObject)Instantiate(bullet_prefab, temp, friend.transform.rotation);  //bullet is a sphere and shoots from friend
						thebullet.tag = "Fireball";
						MoveDirection = Target - thebullet.transform.position;  //calculate vector from friend to enemy 
						thebullet.rigidbody.AddForce(MoveDirection * bulletImpulse, ForceMode.Impulse);  //add power to this vector to have a fast shot
						spider.GetComponent<Enemy>().BulletShot = thebullet;
						Velocity = MoveDirection.normalized * 6;
						rigidbody.velocity = Velocity;
						shootTime = 0;
						audio.PlayOneShot(ButtonClick);

					}
						
					transform.LookAt(enemy); // keep looking at enemy once following
					
					shootTime++;  //adds to shoottime on every frame
					
				}
				
				transform.LookAt(enemy);
				attacking = true;
			}
				break;
			}
			
			if(spiderScript.State == "chasing")  
			{
				state = "enemyEngaged";
			}
			
			if(friendDistance > 10 && !attacking ) 
			{
				state = "patrol";
				attacking = false;
			}
			
			if(Velocity.x == 0){  //friend stops animation when it gets close enough to friend
				friend.animation.Stop("Anim_Walk");
			}

			else{
				friend.animation.Play("Anim_Walk");
			}

			if(friend.position.y-enemy.position.y>1){       // Don't follow enemy to pit
				state = "patrol";
			}
		}
	}
	
	public bool IsGrounded(){  //keeps friend from sinking		
		return Physics.Raycast(transform.position, -Vector3.up, distToGround + 0.1f);
	}
}
