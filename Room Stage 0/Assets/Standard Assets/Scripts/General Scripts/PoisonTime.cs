using UnityEngine;
using System.Collections;


public class PoisonTime : MonoBehaviour {

	public GameObject cloud;
	public bool cheating;

	// Use this for initialization
	void Start () {
		cheating = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (cheating) {
			GameObject.Find("Initialization").GetComponent<Timer>().enabled = true;
			for (int x = -20; x <= 20; x+= 20){ 
				for (int y = 15; y <= 36; y+=7){
					//for (int z = -120; z <= -30; z+=20)
					for (int z = -21; z <= 21; z+=20){ 
						createCloud (x,y,z);
					}
				}
			}
			Destroy (this);
		}
	}

	void createCloud(float x, float y, float z){
		GameObject lavaCloud = Instantiate (cloud) as GameObject;
		lavaCloud.transform.position = new Vector3 (x, y, z);
		foreach (Transform child in lavaCloud.transform) {
			ParticleAnimator particleAnimator = child.GetComponent<ParticleAnimator> ();
			Color[] modifiedColors = particleAnimator.colorAnimation;
			modifiedColors [0] = Color.magenta;
			modifiedColors[1] = new Vector4(255,0,216,83);
			modifiedColors[2] = new Vector4(255,0,216,83);
			modifiedColors[3] = new Vector4(255,0,216,83);
			modifiedColors[4] = new Vector4(255,0,216,83);
			particleAnimator.colorAnimation = modifiedColors;
			break;   //only do first object
		}		
	}
}
