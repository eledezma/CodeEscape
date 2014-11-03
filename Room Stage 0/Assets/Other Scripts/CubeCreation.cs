﻿using UnityEngine;
using System.Collections;

public class CubeCreation : MonoBehaviour {

	// Use this for initialization
	void Start () {
		GameObject.Find ("First Person Controller").GetComponent<CharacterMotor> ().jumping.enabled = false;

		GameObject cube1 = GameObject.CreatePrimitive(PrimitiveType.Cube);
		cube1.name = "Cube1";
		cube1.transform.localScale = new Vector3 (7, 7, 7);
		cube1.transform.position = new Vector3 (-2.104987F, -3.029409F, 28.4881F);
		cube1.AddComponent("MoveBlock");

		GameObject cube2 = GameObject.CreatePrimitive(PrimitiveType.Cube);
		cube2.name = "Cube2";
		cube2.transform.localScale = new Vector3 (7, 7, 7);
		cube2.transform.position = new Vector3 (-2.104987F, 4.029409F, 35.51467F);
		cube2.AddComponent("MoveBlock");
		
		GameObject cube3 = GameObject.CreatePrimitive(PrimitiveType.Cube);
		cube3.name = "Cube3";
		cube3.transform.localScale = new Vector3 (7, 7, 7);
		cube3.transform.position = new Vector3 (-2.104987F, 11.029409F, 42.5925F);
		cube3.AddComponent("MoveBlock");
		
		GameObject cube4 = GameObject.CreatePrimitive(PrimitiveType.Cube);
		cube4.name = "Cube4";
		cube4.transform.localScale = new Vector3 (7, 7, 7);
		cube4.transform.position = new Vector3 (-2.104987F, 18.029409F, 49.63367F);
		cube4.AddComponent("MoveBlock");
		
		GameObject cube5 = GameObject.CreatePrimitive(PrimitiveType.Cube);
		cube5.name = "Cube5";
		cube5.transform.localScale = new Vector3 (7, 7, 7);
		cube5.transform.position = new Vector3 (-2.104987F, 11.029409F, 56.71941F);
		cube5.AddComponent("MoveBlock");
		
		GameObject cube6 = GameObject.CreatePrimitive(PrimitiveType.Cube);
		cube6.name = "Cube6";
		cube6.transform.localScale = new Vector3 (7, 7, 7);
		cube6.transform.position = new Vector3 (-2.104987F, 4.029409F, 63.72967F);
		cube6.AddComponent("MoveBlock");
		
		GameObject cube7 = GameObject.CreatePrimitive(PrimitiveType.Cube);
		cube7.name = "Cube7";
		cube7.transform.localScale = new Vector3 (7, 7, 7);
		cube7.transform.position = new Vector3 (-2.104987F, -3.029409F, 70.72247F);
		cube7.AddComponent("MoveBlock");
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}