using UnityEngine;
using System.Collections;

public class MoveToRight : MonoBehaviour {

	public Camera cam;
	private bool right;
	// Use this for initialization
	void Start()
	{
		right = false;
	}
	
	// Update is called once per frame
	void Update()
	{
		if (Input.GetKeyDown (KeyCode.U)) 
		{
			cam.depth = 2;
			GameObject.Find("Initialization").GetComponent<CursorTime>().showCursor = false;
			this.gameObject.GetComponent<MeshRenderer> ().enabled = true;
			right = true;
		}
		if (right)
		{
			transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z - 0.1F);
		}

	}

	public void complete()
	{
		cam.depth = 2;
		GameObject.Find("Initialization").GetComponent<CursorTime>().showCursor = false;
		this.gameObject.GetComponent<MeshRenderer> ().enabled = true;
		right = true;
	}
}
