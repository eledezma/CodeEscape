using UnityEngine;
using System.Collections;

public class Lightning : MonoBehaviour {

	private LineRenderer lineRenderer;
	public Transform origin;
	public Transform dest;

	
	void Start () { //I just went with laser beams....
		lineRenderer = GetComponent<LineRenderer>();
		lineRenderer.enabled = false;
		lineRenderer.SetPosition(0, origin.position);
		lineRenderer.SetPosition(1, dest.position);
	}

//	void Start () {  //problems with cool looking lightning, I'll leave if anyone want to mess, dig?
//		lineRenderer = GetComponent<LineRenderer>();
//		lineRenderer.SetVertexCount(numOfSegments);
//		for(int i=1; i < vertices-1; i++)
//		{
//			float y =((float)i)*(maxy)/(float)(numOfSegments-1);
//			lineRenderer.SetPosition(i, new Vector3(Random.Range([rightVec],-[rightVec]),y,Random.Range([atVec],-[atVec])));
//		}
//		lineRenderer.SetPosition(0, origin.position);
//		lineRenderer.SetPosition(vertices-1, dest.position);
		//destroy on update, redraw random path to end position
//	}



	void Update () {  //could add sound for shut off but...don't know which node you guys want sound on
	/*if (Input.GetKeyDown("4") && lineRenderer.enabled == false)
		lineRenderer.enabled = true;
	else if(Input.GetKeyDown("4") && lineRenderer.enabled == true)
		lineRenderer.enabled = false;*/
	}

	public void lighttime()
	{
		lineRenderer.enabled = true;
	}

	public void removelight()
	{
		lineRenderer.enabled = false;

	}

}