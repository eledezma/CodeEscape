using UnityEngine;
using System.Collections;

public class TargetColor : MonoBehaviour {
	
	public int bullet;
	public int goal;
	public Texture redTarget;
	public Texture blueTarget;
	// Use this for initialization
	void Start () {
		bullet = 0;
	}
	
	// Update is called once per frame
	void Update () {

	}

	void OnCollisionEnter(Collision col){

		if (col.gameObject.tag == "Bullet") {
			bullet = bullet + 1;
		}
		if (bullet == goal) {
			renderer.material.mainTexture = blueTarget;
			StartCoroutine (ChangeColor ());
		}
		
	}

	public void reset(){
		renderer.material.mainTexture = blueTarget;
		bullet = 0;
	}

	IEnumerator ChangeColor(){
		yield return new WaitForSeconds (5);
		renderer.material.mainTexture = redTarget;	
		bullet = 0;
	}
}
