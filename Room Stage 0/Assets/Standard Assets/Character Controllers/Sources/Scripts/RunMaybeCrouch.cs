using UnityEngine;
using System.Collections;
public class RunMaybeCrouch : MonoBehaviour
{
	public float walk = 7; // regular speed
	public float crouch = 4; // crouching speed
	public float  sprint = 20; // run speed
	private CharacterMotor chMotor;
	private Transform trans;
	private float dist; // distance to ground
	// Use this for initialization
	void Start ()
	{
		chMotor = GetComponent<CharacterMotor>();
		trans = transform;
		CharacterController ch = GetComponent<CharacterController>();
		dist = ch.height/2; // calculate distance to ground
	}
	// Update is called once per frame
	void FixedUpdate ()
	{
		float vScale = 1.0f;
		float currSpd = walk;
		if ((Input.GetKey("left shift") || Input.GetKey("right shift")) && chMotor.grounded)
		{
			currSpd = sprint;
		}
		/*if (Input.GetKey("c"))
		{ // press C to crouch
			vScale = 0.5f;
			currSpd = crouch; // slow down when crouching
		}*/
		chMotor.movement.maxForwardSpeed = currSpd; // set max speed
		float ultScale = trans.localScale.y; // crouch/stand up smoothly
		Vector3 tmpScale = trans.localScale;
		Vector3 tmpPosition = trans.position;
		tmpScale.y = Mathf.Lerp(trans.localScale.y, vScale, 5 * Time.deltaTime);
		trans.localScale = tmpScale;
		tmpPosition.y += dist * (trans.localScale.y - ultScale); // fix vertical position
		trans.position = tmpPosition;
	}
}