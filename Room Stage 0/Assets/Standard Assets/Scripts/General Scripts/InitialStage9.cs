using UnityEngine;
using System.Collections;

public class InitialStage9 : MonoBehaviour 
{

	GameObject cube1;
	GameObject cube2;
	GameObject cube3;
	GameObject cube4;
	GameObject cube5;
	GameObject cube6;
	public Texture green;
	public Texture blue;
	public Texture greenShield;
	public Texture blueShield;

	// Use this for initialization
	void Start ()
	{

		cube1 = GameObject.CreatePrimitive(PrimitiveType.Cube);
		cube1.name = "Cube1";
		cube1.transform.localScale = new Vector3(5, 5, 5);
		cube1.transform.position = new Vector3(-81.98246F, 24.1359F, -41.45633F);
		cube1.renderer.material = new Material(Shader.Find("Unlit/Texture"));
		cube1.renderer.material.mainTexture = green;

		cube2 = GameObject.CreatePrimitive(PrimitiveType.Cube);
		cube2.name = "Cube2";
		cube2.transform.localScale = new Vector3(5, 5, 5);
		cube2.transform.position = new Vector3(-81.98246F, 11.16159F, -41.45633F);
		cube2.renderer.material = new Material(Shader.Find("Unlit/Texture"));
		cube2.renderer.material.mainTexture = green;

		cube3 = GameObject.CreatePrimitive(PrimitiveType.Cube);
		cube3.name = "Cube3";
		cube3.transform.localScale = new Vector3(5, 5, 5);
		cube3.transform.position = new Vector3(-8.598365F, 23.11633F, -41.45633F);
		cube3.renderer.material = new Material(Shader.Find("Unlit/Texture"));
		cube3.renderer.material.mainTexture = blue;

		cube4 = GameObject.CreatePrimitive(PrimitiveType.Cube);
		cube4.name = "Cube4";
		cube4.transform.localScale = new Vector3(5, 5, 5);
		cube4.transform.position = new Vector3(-8.263605F, 10.84026F, -41.45633F);
		cube4.renderer.material = new Material(Shader.Find("Unlit/Texture"));
		cube4.renderer.material.mainTexture = blue;

		cube5 = GameObject.CreatePrimitive(PrimitiveType.Cube);
		cube5.name = "ShieldBox1";
		cube5.transform.localScale = new Vector3(5, 5, 5);
		cube5.transform.position = new Vector3(-42.49564F, 10.53019F, -16.08878F);
		cube5.renderer.material = new Material(Shader.Find("Unlit/Texture"));
		cube5.GetComponent<BoxCollider> ().isTrigger = true;
		cube5.GetComponent<MeshRenderer> ().enabled = false;
		cube5.AddComponent("ShieldActivate");
		cube5.GetComponent<ShieldActivate> ().enabled = false;


		cube6 = GameObject.CreatePrimitive(PrimitiveType.Cube);
		cube6.name = "ShieldBox2";
		cube6.transform.localScale = new Vector3(5, 5, 5);
		cube6.transform.position = new Vector3(21.42704F, 10.53019F, 16.75284F);
		cube6.renderer.material = new Material(Shader.Find("Unlit/Texture"));
		cube6.GetComponent<BoxCollider> ().isTrigger = true;
		cube6.GetComponent<MeshRenderer> ().enabled = false;
		cube6.AddComponent("ShieldActivate");
		cube6.GetComponent<ShieldActivate> ().enabled = false;
	}
	
	// Update is called once per frame
	void Update () 
	{
		//for testing
		if (Input.GetKeyDown ("y")) 
		{
			activate (1);
		}
		if (Input.GetKeyDown ("u")) 
		{
			activate (2);
		}
	}

	public void activate(int color)
	{
		if (color == 1)  //blue in front
		{ 

			cube6.renderer.material.mainTexture = blueShield;
			cube6.GetComponent<MeshRenderer> ().enabled = true;
			cube6.GetComponent<ShieldActivate> ().enabled = true;
			cube6.GetComponent<ShieldActivate> ().color = 1;
		} 
		else if (color == 2)  //green in middle
		{
			cube5.renderer.material.mainTexture = greenShield;
			cube5.GetComponent<MeshRenderer> ().enabled = true;
			cube5.GetComponent<ShieldActivate> ().enabled = true;
			cube5.GetComponent<ShieldActivate> ().color = 2;

		}

		else if (color == 3) // blue in middle
		{
			cube5.renderer.material.mainTexture = blueShield;
			cube5.GetComponent<MeshRenderer> ().enabled = true;
			cube5.GetComponent<ShieldActivate> ().enabled = true;
			cube5.GetComponent<ShieldActivate> ().color = 1;
		}

		else if (color ==4)   //green in front
		{
			cube6.renderer.material.mainTexture = greenShield;
			cube6.GetComponent<MeshRenderer> ().enabled = true;
			cube6.GetComponent<ShieldActivate> ().enabled = true;
			cube6.GetComponent<ShieldActivate> ().color = 2;
		}

		else if (color == 5) // all
		{
			cube6.renderer.material.mainTexture = blueShield;
			cube6.GetComponent<MeshRenderer> ().enabled = true;
			cube6.GetComponent<ShieldActivate> ().enabled = true;
			cube6.GetComponent<ShieldActivate> ().color = 1;
		
			cube5.renderer.material.mainTexture = greenShield;
			cube5.GetComponent<MeshRenderer> ().enabled = true;
			cube5.GetComponent<ShieldActivate> ().enabled = true;
			cube5.GetComponent<ShieldActivate> ().color = 2;
			
		
			cube5.renderer.material.mainTexture = blueShield;
			cube5.GetComponent<MeshRenderer> ().enabled = true;
			cube5.GetComponent<ShieldActivate> ().enabled = true;
			cube5.GetComponent<ShieldActivate> ().color = 1;
		
			cube6.renderer.material.mainTexture = greenShield;
			cube6.GetComponent<MeshRenderer> ().enabled = true;
			cube6.GetComponent<ShieldActivate> ().enabled = true;
			cube6.GetComponent<ShieldActivate> ().color = 2;
		}
	}
}
