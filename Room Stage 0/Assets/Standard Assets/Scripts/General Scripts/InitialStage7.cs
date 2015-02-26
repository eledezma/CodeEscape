using UnityEngine;
using System.Collections;

public class InitialStage7 : MonoBehaviour {

	public AudioClip head;
	public Texture pow;
	public GameObject arm;
	// Use this for initialization
	void Start () {
		GameObject cube1 = GameObject.CreatePrimitive(PrimitiveType.Cube);
		cube1.name = "PowBlock";
		cube1.transform.localScale = new Vector3 (2, 2, 2);
		cube1.transform.position = new Vector3 (-19.58157F, 15.99304F, -131.2278F);
		cube1.renderer.material = new Material(Shader.Find("Unlit/Texture"));
		cube1.GetComponent<BoxCollider> ().isTrigger = true;
		cube1.renderer.material.mainTexture = pow;
		cube1.AddComponent("PowBlock");
		cube1.AddComponent ("AudioSource");
		cube1.GetComponent<PowBlock> ().sound = head;
		cube1.GetComponent<PowBlock> ().armCam = arm;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
