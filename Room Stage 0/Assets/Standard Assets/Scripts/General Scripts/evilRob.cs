using UnityEngine;
using System.Collections;

public class evilRob : MonoBehaviour {
	public Transform player;
	
	public Transform friend;
	public Transform enemy;
	public string state = "patrol";
	Vector3 Velocity;
	public Vector3 MoveDirection;
	Vector3 Target;
	public float friendDistance;
	public float playerEnemyDistance;
	public float enemybotDistance;
	GameObject fpc;
	GameObject bot;
	GameObject spider;
	public int shootTime = 0;
	public bool attacking = false;
	AnimationClip Walk;
	private Transform myTransform;
	float bulletImpulse = 10f;
	GameObject theSpider;
	Enemy spiderScript;
	// Use this for initialization
	void Start () {
		myTransform = transform;
		fpc = GameObject.Find("First Person Controller");
		bot= this.gameObject;
		enemy = bot.transform;
		player = fpc.transform;
		bot.animation["Anim_Walk"].wrapMode = WrapMode.Loop;

		
		//enemy.animation["Walk"].wrapMode = WrapMode.Loop;
		//enemy.animation.Play("Walk");
	}
	
	// Update is called once per frame
	void Update () {
		playerEnemyDistance = Vector3.Distance (player.position, enemy.position);
		if (playerEnemyDistance < 75 && playerEnemyDistance > 4) {
						
	
						Target = new Vector3 (player.position.x, player.position.y-12, player.position.z);
						MoveDirection = Target - myTransform.position;
						Velocity = MoveDirection.normalized * 8;
						rigidbody.velocity = Velocity;
						myTransform.LookAt (Target);
			bot.animation.Play("Anim_Walk");


				}

			

		}
}
