using UnityEngine;
using System.Collections;

public class MaxLevel7 : MonoBehaviour {

	//public AudioClip clip;
	// Use this for initialization
	public GameObject armCam;

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
			GameObject.Find ("Main Camera").GetComponent<MouseLook> ().enabled = false;
			GameObject.Find ("First Person Controller").GetComponent<MouseLook> ().enabled = false;
			armCam.SetActive (false);
			Screen.lockCursor = true;
			GameObject.Find("Initialization").GetComponent<CursorTime>().showCursor=false;
			GameObject.Find ("MaxCam").GetComponent<Camera>().depth = 1;
			yield return new WaitForSeconds (audio.clip.length);
			Debug.Log ("YO2");
			this.gameObject.GetComponent<TimetoFly>().enabled = true;
			//GameObject.Find ("Cube").GetComponent<TimetoFly> ().enabled = true;
			GameObject.Find ("MaxCam").GetComponent<TimetoFly> ().enabled = true;
			GameObject.Find ("Initialization").GetComponent<CubeCreationStage7> ().enabled = true;
			//Destroy (this.gameObject);
		}
	}
}
