using UnityEngine;
using System.Collections;

public class TargetColor : MonoBehaviour {
	
	public int bulletCount; //change to non-public later
	public int goal;
	float lastBulletTime;
	public Texture redTarget;
	public Texture blueTarget;
	// Use this for initialization
	void Start () {
		bulletCount = 0;
		lastBulletTime = Time.time;
	}
	
	// Update is called once per frame
	void Update () {  //to reset bulletcount after 5 seconds of no bullets being hit
		if ((Time.time - lastBulletTime) > 5.0 && bulletCount > 0) {
			bulletCount = 0;
		}
	}

	void OnCollisionEnter(Collision col){

		if (col.gameObject.tag == "Bullet") {
			bulletCount = bulletCount + 1;
			lastBulletTime = Time.time;
		}
		if (bulletCount == goal) {
			renderer.material.mainTexture = blueTarget;
			StartCoroutine (ChangeColor ());
		}
	}

	public void reset(){
		renderer.material.mainTexture = redTarget;
		bulletCount = 0;
	}

	IEnumerator ChangeColor(){
		yield return new WaitForSeconds (5);
		renderer.material.mainTexture = redTarget;	
		bulletCount = 0;
	}
}
