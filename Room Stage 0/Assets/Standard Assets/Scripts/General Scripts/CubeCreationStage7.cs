using UnityEngine;
using System.Collections;

public class CubeCreationStage7 : MonoBehaviour
{

    public AudioClip coin;
    public Texture qmark;
    // Use this for initialization
    void Start()
    {
        //GameObject.Find ("First Person Controller").GetComponent<CharacterMotor> ().jumping.enabled = false;

        GameObject cube1 = GameObject.CreatePrimitive(PrimitiveType.Cube);
        cube1.name = "Cube1";
        cube1.transform.localScale = new Vector3(10, 10, 14);
        cube1.transform.position = new Vector3(1.905319F, -4.897118F, -33.9434F);
        cube1.renderer.material = new Material(Shader.Find("Unlit/Texture"));
        cube1.renderer.material.mainTexture = qmark;

        GameObject cube2 = GameObject.CreatePrimitive(PrimitiveType.Cube);
        cube2.name = "Cube2";
        cube2.transform.localScale = new Vector3(10, 10, 14);
        cube2.transform.position = new Vector3(1.905319F, -4.897118F, -47.9434F);
        cube2.renderer.material = new Material(Shader.Find("Unlit/Texture"));
        cube2.renderer.material.mainTexture = qmark;

        GameObject cube3 = GameObject.CreatePrimitive(PrimitiveType.Cube);
        cube3.name = "Cube3";
        cube3.transform.localScale = new Vector3(10, 10, 14);
        cube3.transform.position = new Vector3(1.905319F, -4.897118F, -61.9434F);
        cube3.renderer.material = new Material(Shader.Find("Unlit/Texture"));
        cube3.renderer.material.mainTexture = qmark;

        GameObject cube4 = GameObject.CreatePrimitive(PrimitiveType.Cube);
        cube4.name = "Cube4";
        cube4.transform.localScale = new Vector3(10, 10, 14);
        cube4.transform.position = new Vector3(1.905319F, -4.897118F, -75.9434F);
        cube4.renderer.material = new Material(Shader.Find("Unlit/Texture"));
        cube4.renderer.material.mainTexture = qmark;

        GameObject cube5 = GameObject.CreatePrimitive(PrimitiveType.Cube);
        cube5.name = "Cube5";
        cube5.transform.localScale = new Vector3(10, 10, 14);
        cube5.transform.position = new Vector3(1.905319F, -4.897118F, -89.9434F);
        cube5.renderer.material = new Material(Shader.Find("Unlit/Texture"));
        cube5.renderer.material.mainTexture = qmark;

        GameObject cube6 = GameObject.CreatePrimitive(PrimitiveType.Cube);
        cube6.name = "Cube6";
        cube6.transform.localScale = new Vector3(10, 10, 14);
        cube6.transform.position = new Vector3(1.905319F, -4.897118F, -103.9434F);
        cube6.renderer.material = new Material(Shader.Find("Unlit/Texture"));
        cube6.renderer.material.mainTexture = qmark;

        GameObject cube7 = GameObject.CreatePrimitive(PrimitiveType.Cube);
        cube7.name = "Cube7";
        cube7.transform.localScale = new Vector3(10, 10, 14);
        cube7.transform.position = new Vector3(1.905319F, -4.897118F, -117.9434F);
        cube7.renderer.material = new Material(Shader.Find("Unlit/Texture"));
        cube7.renderer.material.mainTexture = qmark;

        GameObject cube8 = GameObject.CreatePrimitive(PrimitiveType.Cube);
        cube8.name = "Cube8";
        cube8.transform.localScale = new Vector3(10, 10, 14);
        cube8.transform.position = new Vector3(1.905319F, -0.897118F, -33.9434F);
        cube8.GetComponent<BoxCollider>().isTrigger = true;
        cube8.GetComponent<MeshRenderer>().enabled = false;
        cube8.AddComponent("SoundTrigger");
        cube8.AddComponent("AudioSource");
        cube8.GetComponent<SoundTrigger>().sound = coin;

        GameObject cube9 = GameObject.CreatePrimitive(PrimitiveType.Cube);
        cube9.name = "Cube9";
        cube9.transform.localScale = new Vector3(10, 10, 14);
        cube9.transform.position = new Vector3(1.905319F, -0.897118F, -47.9434F);
        cube9.GetComponent<BoxCollider>().isTrigger = true;
        cube9.GetComponent<MeshRenderer>().enabled = false;
        cube9.AddComponent("SoundTrigger");
        cube9.AddComponent("AudioSource");
        cube9.GetComponent<SoundTrigger>().sound = coin;

        GameObject cube10 = GameObject.CreatePrimitive(PrimitiveType.Cube);
        cube10.name = "Cube10";
        cube10.transform.localScale = new Vector3(10, 10, 14);
        cube10.transform.position = new Vector3(1.905319F, -0.897118F, -61.9434F);
        cube10.GetComponent<BoxCollider>().isTrigger = true;
        cube10.GetComponent<MeshRenderer>().enabled = false;
        cube10.AddComponent("SoundTrigger");
        cube10.AddComponent("AudioSource");
        cube10.GetComponent<SoundTrigger>().sound = coin;

        GameObject cube11 = GameObject.CreatePrimitive(PrimitiveType.Cube);
        cube11.name = "Cube11";
        cube11.transform.localScale = new Vector3(10, 10, 14);
        cube11.transform.position = new Vector3(1.905319F, -0.897118F, -75.9434F);
        cube11.GetComponent<BoxCollider>().isTrigger = true;
        cube11.GetComponent<MeshRenderer>().enabled = false;
        cube11.AddComponent("SoundTrigger");
        cube11.AddComponent("AudioSource");
        cube11.GetComponent<SoundTrigger>().sound = coin;

        GameObject cube12 = GameObject.CreatePrimitive(PrimitiveType.Cube);
        cube12.name = "Cube12";
        cube12.transform.localScale = new Vector3(10, 10, 14);
        cube12.transform.position = new Vector3(1.905319F, -0.897118F, -89.9434F);
        cube12.GetComponent<BoxCollider>().isTrigger = true;
        cube12.GetComponent<MeshRenderer>().enabled = false;
        cube12.AddComponent("SoundTrigger");
        cube12.AddComponent("AudioSource");
        cube12.GetComponent<SoundTrigger>().sound = coin;

        GameObject cube13 = GameObject.CreatePrimitive(PrimitiveType.Cube);
        cube13.name = "Cube13";
        cube13.transform.localScale = new Vector3(10, 10, 14);
        cube13.transform.position = new Vector3(1.905319F, -0.897118F, -103.9434F);
        cube13.GetComponent<BoxCollider>().isTrigger = true;
        cube13.GetComponent<MeshRenderer>().enabled = false;
        cube13.AddComponent("SoundTrigger");
        cube13.AddComponent("AudioSource");
        cube13.GetComponent<SoundTrigger>().sound = coin;

        GameObject cube14 = GameObject.CreatePrimitive(PrimitiveType.Cube);
        cube14.name = "Cube14";
        cube14.transform.localScale = new Vector3(10, 10, 14);
        cube14.transform.position = new Vector3(1.905319F, -0.897118F, -117.9434F);
        cube14.GetComponent<BoxCollider>().isTrigger = true;
        cube14.GetComponent<MeshRenderer>().enabled = false;
        cube14.AddComponent("SoundTrigger");
        cube14.AddComponent("AudioSource");
        cube14.GetComponent<SoundTrigger>().sound = coin;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
