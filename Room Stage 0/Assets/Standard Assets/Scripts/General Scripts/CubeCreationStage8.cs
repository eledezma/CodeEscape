using UnityEngine;
using System.Collections;

public class CubeCreationStage8 : MonoBehaviour
{

    float initial;
	GameObject cube1;
	GameObject cube2;
	GameObject cube3;
	GameObject cube4;
	GameObject cube5;
	public Texture c1;
	public Texture c2;
	public Texture c3;
	public Texture c4;
	public Texture c5;
    // Use this for initialization
    void Start()
    {
        initial = 6;

        cube1 = GameObject.CreatePrimitive(PrimitiveType.Cube);
        cube1.name = "Cube1";
		cube1.transform.localScale = new Vector3(9.75F, 9.75F, 9.75F);
		cube1.transform.position = new Vector3(-5.665023F, 6, -26.608F);
        cube1.renderer.material = new Material(Shader.Find("Unlit/Texture"));
        cube1.renderer.material.mainTexture = c1;

        cube2 = GameObject.CreatePrimitive(PrimitiveType.Cube);
        cube2.name = "Cube2";
		cube2.transform.localScale = new Vector3(9.75F, 9.75F, 9.75F);
		cube2.transform.position = new Vector3(-15.41151F, 6, -26.608F);
        cube2.renderer.material = new Material(Shader.Find("Unlit/Texture"));
        cube2.renderer.material.mainTexture = c2;

        cube3 = GameObject.CreatePrimitive(PrimitiveType.Cube);
        cube3.name = "Cube3";
		cube3.transform.localScale = new Vector3(9.75F, 9.75F, 9.75F);
		cube3.transform.position = new Vector3(-25.08608F, 6, -26.608F);
        cube3.renderer.material = new Material(Shader.Find("Unlit/Texture"));
        cube3.renderer.material.mainTexture = c3;

        cube4 = GameObject.CreatePrimitive(PrimitiveType.Cube);
        cube4.name = "Cube4";
		cube4.transform.localScale = new Vector3(9.75F, 9.75F, 9.75F);
		cube4.transform.position = new Vector3(-34.83625F, 6, -26.608F);
        cube4.renderer.material = new Material(Shader.Find("Unlit/Texture"));
        cube4.renderer.material.mainTexture = c4;

        cube5 = GameObject.CreatePrimitive(PrimitiveType.Cube);
        cube5.name = "Cube5";
		cube5.transform.localScale = new Vector3(9.75F, 9.75F, 9.75F);
		cube5.transform.position = new Vector3(-44.54134F, 6, -26.608F);
        cube5.renderer.material = new Material(Shader.Find("Unlit/Texture"));
        cube5.renderer.material.mainTexture = c5;
    }

    public void moveBlock1(int value)
    {
		if (value == 0)
		{
			value = -1;
		}
        float y = initial;
        y += 9.75F * (value - 1);
        cube1.transform.position = new Vector3(cube1.transform.position.x, y, cube1.transform.position.z);
    }

    public void moveBlock2(int value)
    {
		if (value == 0)
		{
			value = -1;
		}
        float y = initial;
		y += 9.75F * (value - 1);
        cube2.transform.position = new Vector3(cube2.transform.position.x, y, cube2.transform.position.z);
    }

    public void moveBlock3(int value)
    {
		if (value == 0)
		{
			value = -1;
		}
        float y = initial;
		y += 9.75F * (value - 1);
        cube3.transform.position = new Vector3(cube3.transform.position.x, y, cube3.transform.position.z);
    }

    public void moveBlock4(int value)
    {
		if (value == 0)
		{
			value = -1;
		}
        float y = initial;
		y += 9.75F * (value - 1);
        cube4.transform.position = new Vector3(cube4.transform.position.x, y, cube4.transform.position.z);
    }

    public void moveBlock5(int value)
    {
		if (value == 0)
		{
			value = -1;
		}
        float y = initial;
		y += 9.75F * (value - 1);
        cube5.transform.position = new Vector3(cube5.transform.position.x, y, cube5.transform.position.z);
    }
    // Update is called once per frame
    void Update()
    {

    }
}
