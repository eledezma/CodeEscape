using UnityEngine;
using System.Collections;

public class Stage1Scratch : MonoBehaviour 
{

	public Texture backwalltext;
	public Texture2D crosshair;
	public GameObject robotarms;
	// Use this for initialization
	void Start () 
	{
		//Back Wall 1
		GameObject cube1 = GameObject.CreatePrimitive(PrimitiveType.Cube);
		cube1.name = "Back Wall 1";
		cube1.transform.localScale = new Vector3 (18.40298F, 40, 1);
		cube1.transform.position = new Vector3 (10.54097F, 20, 24.60629F);
		cube1.renderer.material.mainTexture = backwalltext;

		//Initialization
		this.gameObject.AddComponent ("CursorTime");
		this.gameObject.GetComponent<CursorTime>().cursorImage = crosshair;
		this.gameObject.GetComponent<BoxCollider> ().isTrigger = true;
		this.gameObject.GetComponent<BoxCollider> ().enabled = false;
		this.gameObject.GetComponent<MeshRenderer> ().enabled = false;

		//Arm Camera
		GameObject armCam  = new GameObject("Player");
		armCam.name = "Arm Camera";
		armCam.AddComponent ("Camera");
		armCam.GetComponent<Camera> ().clearFlags = CameraClearFlags.Depth;
		armCam.GetComponent<Camera> ().cullingMask = 256; //Arms Layer
		//armCam.transform.parent = cube1.transform;

	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}
}
