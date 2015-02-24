using UnityEngine;
using System.Collections;

public class MaxLevel7 : MonoBehaviour {

	//public AudioClip clip;
	// Use this for initialization
	void Start () {
		//GameObject.Find ("ShootCube").GetComponent<TurretShoot> ().bulletImpulse = 35F;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	IEnumerator OnCollisionEnter(Collision other)
	{
		if (other.gameObject.tag == "Bullet") 
		{
			audio.Play();
			Destroy (other.gameObject);
			yield return new WaitForSeconds (audio.clip.length);
			Debug.Log ("YO2");
			GameObject.Find ("Initialization").GetComponent<CubeCreationStage7> ().enabled = true;
			Destroy (this.gameObject);
		}
	}
}
