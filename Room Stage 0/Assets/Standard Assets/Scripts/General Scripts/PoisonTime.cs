using UnityEngine;
using System.Collections;
//handles poison and button pushing up for stage 4

public class PoisonTime : MonoBehaviour {

	public GameObject cloud;
	public bool cheating;

	// Use this for initialization
	void Start () {
		cheating = false;
	}
	
	// Update is called once per frame
	void Update () {
		bool d6 = GameObject.Find ("d6").GetComponent<DiceRotateLoaded> ().diceComplete;
		bool d67 = GameObject.Find ("d67").GetComponent<DiceRotateLoaded> ().diceComplete;
		if (d6 && d67) {
			GameObject.Find ("ButtonTrigger").GetComponent<ButtonTriggerStage4> ().pushup = true;
			GameObject.Find ("d6").GetComponent<DiceRotateLoaded> ().diceComplete = false;
			GameObject.Find ("d67").GetComponent<DiceRotateLoaded> ().diceComplete = false;
		}
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
