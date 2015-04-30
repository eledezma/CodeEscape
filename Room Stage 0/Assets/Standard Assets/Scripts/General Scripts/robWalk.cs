using UnityEngine;
using System.Collections;

public class robWalk : MonoBehaviour {
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
	public GameObject bullet_prefab;
	float bulletImpulse = 10f;
	GameObject theSpider;
	Enemy spiderScript;
	private float distToGround;
	// Use this for initialization
	void Start () {
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
		friend.animation["Anim_Walk"].wrapMode = WrapMode.Loop;
		//friend.animation.Play("Anim_Walk");
		
		//enemy.animation["Walk"].wrapMode = WrapMode.Loop;
		//enemy.animation.Play("Walk");
	}
	
	// Update is called once per frame
	void Update () {
		if(myTransform.position.y<0.5f)
			myTransform.Translate(0,0.05f,0);

		friendDistance = Vector3.Distance (player.position, friend.position);
		playerEnemyDistance = Vector3.Distance (player.position, enemy.position);
		enemybotDistance = Vector3.Distance (enemy.position, friend.position);
	if(IsGrounded()){	
		switch (state) {
		case "patrol":
		{
			if (friendDistance > 10) {
				
				Target = new Vector3 (player.position.x, 1, player.position.z);
				MoveDirection = Target - myTransform.position;
				Velocity = MoveDirection.normalized * 6;
				rigidbody.velocity = Velocity;
				myTransform.LookAt (Target);
			} else {
//				MoveDirection = myTransform.position;
					Velocity = MoveDirection.normalized * 0;
					rigidbody.velocity = Velocity;
				myTransform.LookAt (Target);
				
			}
		}
			
			break;
			
		case "enemyEngaged":
		{
			if (enemybotDistance > 8) {
				
				Target = new Vector3 (enemy.position.x, 1, enemy.position.z);
				MoveDirection = Target - myTransform.position;
				Velocity = MoveDirection.normalized * 6;
				rigidbody.velocity = Velocity;
				myTransform.LookAt (enemy);
			} else {
		//		MoveDirection = myTransform.position;
				Velocity = MoveDirection.normalized * 0;
				rigidbody.velocity = Velocity;
		//		myTransform.LookAt (enemy);
				
			}
			
			if (enemybotDistance < 10) {
				
				if(shootTime > 100){
					GameObject thebullet = (GameObject)Instantiate(bullet_prefab, friend.position, friend.rotation);
					thebullet.tag = "Bullet";
					thebullet.rigidbody.AddForce(enemy.transform.forward * bulletImpulse, ForceMode.Impulse);
					MoveDirection = Target - thebullet.transform.position;
					Velocity = MoveDirection.normalized * 6;
					rigidbody.velocity = Velocity;
					shootTime = 0;
				}
				transform.LookAt(enemy);
				
				shootTime++;
				
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

		if(Velocity.x == 0){
				friend.animation.Stop("Anim_Walk");
		}
		else{
				friend.animation.Play("Anim_Walk");
		}

		}
	}
	public bool IsGrounded(){
		return Physics.Raycast(transform.position, -Vector3.up, distToGround + 0.1f);
	}
}
