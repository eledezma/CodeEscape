using UnityEngine;
using System.Collections;

public class SetupStage6 : MonoBehaviour {

	TurretShoot tarShoot;
	// Use this for initialization
	void Start () {
		tarShoot = GameObject.Find ("turret/Cube").AddComponent<TurretShoot> ();
		tarShoot.bullet_prefab = GameObject.Find ("Sphere");
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
