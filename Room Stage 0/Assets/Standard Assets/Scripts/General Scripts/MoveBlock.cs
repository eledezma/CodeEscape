using UnityEngine;
using System.Collections;

public class MoveBlock : MonoBehaviour {

	public int height;
	float initialHeight = -3.029409f;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		float newHeight = initialHeight + (7 * height);
		transform.position = new Vector3(transform.position.x, newHeight, transform.position.z);
	}
}
