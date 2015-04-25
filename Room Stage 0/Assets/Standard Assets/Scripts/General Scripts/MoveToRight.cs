using UnityEngine;
using System.Collections;

public class MoveToRight : MonoBehaviour {

	public Camera cam;
	private bool right;
	GameObject[] NumQuestions;
	// Use this for initialization
	void Start()
	{
		right = false;
	}
	
	// Update is called once per frame
	void Update()
	{
		/*
		if (Input.GetKeyDown (KeyCode.U)) 
		{
			cam.depth = 2;
			Screen.lockCursor = true;
			GameObject.Find("Initialization").GetComponent<CursorTime>().showCursor = false;
			this.gameObject.GetComponent<MeshRenderer> ().enabled = true;
			right = true;
		}
		*/
		if (Input.GetKeyDown (KeyCode.P)) 
		{
			GameObject.Find("First Person Controller").transform.position = new Vector3(-32.01288F, 8.895495F, 121.8482F);
			GameObject.Find("First Person Controller").transform.rotation = Quaternion.identity;
			GameObject.Find("First Person Controller").GetComponent<Questions>().correctNum = 0;
			if (!GameObject.Find("First Person Controller").GetComponent<GreenAndBlue4Eva>().green)
			{
				GameObject.Find("First Person Controller").GetComponent<GreenAndBlue4Eva>().greenTime = true;
			}
			NumQuestions = GameObject.FindGameObjectsWithTag("Question");
			for (int i = 0; i < NumQuestions.Length; i++)
			{
				NumQuestions[i].GetComponent<Level10FloorPanel>().active = true;
			}
	
		}
		if (right)
		{
			transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z - 0.1F);
		}

	}

	public void complete()
	{
		GameObject.Find ("First Person Controller").GetComponent<Level10Health> ().guiEnabled = false;
		cam.depth = 2;
		Screen.lockCursor = true;
		GameObject.Find("Initialization").GetComponent<CursorTime>().showCursor = false;
		this.gameObject.GetComponent<MeshRenderer> ().enabled = true;
		right = true;
	}
}
