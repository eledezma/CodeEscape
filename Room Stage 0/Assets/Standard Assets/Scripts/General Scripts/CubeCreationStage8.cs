using UnityEngine;
using System.Collections;

public class CubeCreationStage8 : MonoBehaviour {

	//public AudioClip coin;
	//public Texture qmark;
	//public int num;
	float initial;
	GameObject cube1,cube2,cube3,cube4,cube5;
	// Use this for initialization
	void Start () 
	{
		initial = -4.897118F;

		//num = 1;
		cube1 = GameObject.CreatePrimitive(PrimitiveType.Cube);
		cube1.name = "Cube1";
		cube1.transform.localScale = new Vector3 (10, 10, 14);
		cube1.transform.position = new Vector3 (1.905319F, -4.897118F, -33.9434F);
		cube1.renderer.material = new Material(Shader.Find("Unlit/Texture"));
		//cube1.renderer.material.mainTexture = qmark;
		
		cube2 = GameObject.CreatePrimitive(PrimitiveType.Cube);
		cube2.name = "Cube2";
		cube2.transform.localScale = new Vector3 (10, 10, 14);
		cube2.transform.position = new Vector3 (1.905319F, -4.897118F, -47.9434F);
		cube2.renderer.material = new Material(Shader.Find("Unlit/Texture"));
		//cube2.renderer.material.mainTexture = qmark;
		
		cube3 = GameObject.CreatePrimitive(PrimitiveType.Cube);
		cube3.name = "Cube3";
		cube3.transform.localScale = new Vector3 (10, 10, 14);
		cube3.transform.position = new Vector3 (1.905319F, -4.897118F, -61.9434F);
		cube3.renderer.material = new Material(Shader.Find("Unlit/Texture"));
		//cube3.renderer.material.mainTexture = qmark;
		
		cube4 = GameObject.CreatePrimitive(PrimitiveType.Cube);
		cube4.name = "Cube4";
		cube4.transform.localScale = new Vector3 (10, 10, 14);
		cube4.transform.position = new Vector3 (1.905319F, -4.897118F, -75.9434F);
		cube4.renderer.material = new Material(Shader.Find("Unlit/Texture"));
		//cube4.renderer.material.mainTexture = qmark;
		
		cube5 = GameObject.CreatePrimitive(PrimitiveType.Cube);
		cube5.name = "Cube5";
		cube5.transform.localScale = new Vector3 (10, 10, 14);
		cube5.transform.position = new Vector3 (1.905319F, -4.897118F, -89.9434F);
		cube5.renderer.material = new Material(Shader.Find("Unlit/Texture"));
		//cube5.renderer.material.mainTexture = qmark;
	}

	public void moveBlock1(int value)
	{
		float y = initial;
		y += 5 * (value - 1);
		cube1.transform.position = new Vector3(cube1.transform.position.x, y, cube1.transform.position.z);		                                     
	}

	public void moveBlock2(int value)
	{
		float y = initial;
		y += 5 * (value - 1);
		cube2.transform.position = new Vector3(cube2.transform.position.x, y, cube2.transform.position.z);		                                     
	}

	public void moveBlock3(int value)
	{
		float y = initial;
		y += 5 * (value - 1);
		cube3.transform.position = new Vector3(cube3.transform.position.x, y, cube3.transform.position.z);		                                     
	}

	public void moveBlock4(int value)
	{
		float y = initial;
		y += 5 * (value - 1);
		cube4.transform.position = new Vector3(cube4.transform.position.x, y, cube4.transform.position.z);		                                     
	}

	public void moveBlock5(int value)
	{
		float y = initial;
		y += 5 * (value - 1);
		cube5.transform.position = new Vector3(cube5.transform.position.x, y, cube5.transform.position.z);		                                     
	}
	// Update is called once per frame
	void Update () 
	{
		//moveBlock1 (num);
	}
}
