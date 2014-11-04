using UnityEngine;
using System.Collections;

public class MoveBlockStage3 : MonoBehaviour {

	public int height;
	float initialHeight;
	public float currentHeight;
	// Use this for initialization
	void Start () {
		initialHeight = transform.position.y;
	}
	
	// Update is called once per frame
	void Update () {
		float newHeight = initialHeight + (10 * height);

		if (newHeight < 0F && initialHeight > 0) { // to adjust for going from positive to negative values
			newHeight += 0.205764F;
		}

		transform.position = new Vector3(transform.position.x, newHeight, transform.position.z);
		currentHeight = newHeight;
	}
}
