using UnityEngine;
using System.Collections;

public class CubeCreationStage7 : MonoBehaviour {

	public Texture qmark;
	// Use this for initialization
	void Start () {
		//GameObject.Find ("First Person Controller").GetComponent<CharacterMotor> ().jumping.enabled = false;
		
		GameObject cube1 = GameObject.CreatePrimitive(PrimitiveType.Cube);
		cube1.name = "Cube1";
		cube1.transform.localScale = new Vector3 (10, 10, 14);
		cube1.transform.position = new Vector3 (1.905319F, -4.897118F, -33.9434F);
		cube1.AddComponent("MoveBlockStage3");
		cube1.renderer.material = new Material(Shader.Find("Unlit/Texture"));
		cube1.renderer.material.mainTexture = qmark;

		GameObject cube2 = GameObject.CreatePrimitive(PrimitiveType.Cube);
		cube2.name = "Cube2";
		cube2.transform.localScale = new Vector3 (10, 10, 14);
		cube2.transform.position = new Vector3 (1.905319F, -4.897118F, -47.9434F);
		cube2.AddComponent("MoveBlockStage3");
		cube2.renderer.material = new Material(Shader.Find("Unlit/Texture"));
		cube2.renderer.material.mainTexture = qmark;
		
		GameObject cube3 = GameObject.CreatePrimitive(PrimitiveType.Cube);
		cube3.name = "Cube3";
		cube3.transform.localScale = new Vector3 (10, 10, 14);
		cube3.transform.position = new Vector3 (1.905319F, -4.897118F, -61.9434F);
		cube3.AddComponent("MoveBlockStage3");
		cube3.renderer.material = new Material(Shader.Find("Unlit/Texture"));
		cube3.renderer.material.mainTexture = qmark;
		
		GameObject cube4 = GameObject.CreatePrimitive(PrimitiveType.Cube);
		cube4.name = "Cube4";
		cube4.transform.localScale = new Vector3 (10, 10, 14);
		cube4.transform.position = new Vector3 (1.905319F, -4.897118F, -75.9434F);
		cube4.AddComponent("MoveBlockStage3");
		cube4.renderer.material = new Material(Shader.Find("Unlit/Texture"));
		cube4.renderer.material.mainTexture = qmark;
		
		GameObject cube5 = GameObject.CreatePrimitive(PrimitiveType.Cube);
		cube5.name = "Cube5";
		cube5.transform.localScale = new Vector3 (10, 10, 14);
		cube5.transform.position = new Vector3 (1.905319F, -4.897118F, -89.9434F);
		cube5.AddComponent("MoveBlockStage3");
		cube5.renderer.material = new Material(Shader.Find("Unlit/Texture"));
		cube5.renderer.material.mainTexture = qmark;
		
		GameObject cube6 = GameObject.CreatePrimitive(PrimitiveType.Cube);
		cube6.name = "Cube6";
		cube6.transform.localScale = new Vector3 (10, 10, 14);
		cube6.transform.position = new Vector3 (1.905319F, -4.897118F, -103.9434F);
		cube6.AddComponent("MoveBlockStage3");
		cube6.renderer.material = new Material(Shader.Find("Unlit/Texture"));
		cube6.renderer.material.mainTexture = qmark;

		GameObject cube7 = GameObject.CreatePrimitive(PrimitiveType.Cube);
		cube7.name = "Cube7";
		cube7.transform.localScale = new Vector3 (10, 10, 14);
		cube7.transform.position = new Vector3 (1.905319F, -4.897118F, -117.9434F);
		cube7.AddComponent("MoveBlockStage3");
		cube7.renderer.material = new Material(Shader.Find("Unlit/Texture"));
		cube7.renderer.material.mainTexture = qmark;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
