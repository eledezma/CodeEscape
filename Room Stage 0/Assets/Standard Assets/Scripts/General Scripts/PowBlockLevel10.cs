using UnityEngine;
using System.Collections;

public class PowBlockLevel10 : MonoBehaviour
{

	public AudioClip sound;
	public Camera cam;
	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{

	}

	IEnumerator OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "Max")
		{
			audio.PlayOneShot(sound);
			this.gameObject.GetComponent<MeshRenderer>().enabled = false;
			yield return new WaitForSeconds(0.5F);
			//ACTIVATE ELECTRICTY HERE
			GameObject.Find("MAX").GetComponent<TimetoFly>().enabled = false;
			GameObject.Find("MAXCAM").GetComponent<TimetoFly>().enabled = false;
			GameObject.Find("Initialization").GetComponent<CursorTime>().showCursor = true;
			Screen.lockCursor = false;

			cam.depth = -2;
			GameObject.Find("First Person Controller").GetComponent<Level10Health>().guiEnabled = true;
			GameObject.Find("First Person Controller").GetComponent<GreenAndBlue4Eva>().greenTime = true;
			GameObject.Find("Main Camera").GetComponent<MouseLook>().enabled = true;
			GameObject.Find("First Person Controller").GetComponent<MouseLook>().enabled = true;
			GameObject.Find("First Person Controller").GetComponent<CharacterMotor>().canControl = true;
			GameObject.Find("MAX").transform.position = new Vector3(152.6644F, 53.75206F, 283.6994F);
			GameObject.Find("MAXCAM").transform.position = new Vector3(144.9551F, 61.17865F, 283.306F);
		}
	}
}