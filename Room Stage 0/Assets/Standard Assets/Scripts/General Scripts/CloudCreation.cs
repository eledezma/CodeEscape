using UnityEngine;
using System.Collections;


public class CloudCreation : MonoBehaviour {

	public GameObject cloud;

	// Use this for initialization
	void Start () {
		for (int y = -25; y <= -5; y+= 10){ 
			for (int x = -35; x <= 35; x+=20){
				for (int z = -120; z <= -30; z+=20)
					createCloud ((float)x, (float)y, (float)z);
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void createCloud(float x, float y, float z){
		GameObject lavaCloud = Instantiate (cloud) as GameObject;
		lavaCloud.transform.position = new Vector3 (x, y, z);
	}
}
