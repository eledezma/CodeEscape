using UnityEngine;
using System.Collections;

public class MoveBlock : MonoBehaviour {

	public int height;
	float initialHeight;
	// Use this for initialization
	void Start () {
		initialHeight = transform.position.y;
	}
	
	// Update is called once per frame
	void Update () {
		float newHeight = initialHeight + (7 * height);
		transform.position = new Vector3(transform.position.x, newHeight, transform.position.z);
	}
}
