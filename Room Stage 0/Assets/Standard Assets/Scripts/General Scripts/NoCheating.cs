using UnityEngine;
using System.Collections;

public class NoCheating : MonoBehaviour
{

	public AudioClip pain;
	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}

	IEnumerator OnTriggerEnter(Collider col)
	{
		if (col.gameObject.tag == "Player")
		{
			GameObject.Find("Object").GetComponent<Rollinrollinrollin>().roll = false;
			//Destroy(GameObject.Find("Main Camera").GetComponent<MouseLook>());
			//Destroy(GameObject.Find("First Person Controller").GetComponent<MouseLook>());
			//GameObject.Find("First Person Controller").GetComponent<CharacterMotor>().canControl = false;
			GameObject.Find("Main Camera").GetComponent<MouseLook>().enabled = false; //this line and next four help in changing position and rotation of character
			GameObject.Find("First Person Controller").GetComponent<MouseLook>().enabled = false;
			GameObject.Find("First Person Controller").GetComponent<CharacterMotor>().enabled = false;
			Destroy(GameObject.Find("Robo_Arm10").GetComponent<ArmAnimation2>());
			audio.clip = pain;
			audio.Play();
			yield return new WaitForSeconds(audio.clip.length);
			//Application.LoadLevel(Application.loadedLevel);
			//Destroy(GameObject.Find("IndianaTrigger"));
			
			//GameObject.Find("First Person Controller").GetComponent<CharacterController>().enabled = false;
			//GameObject.Find("Object").GetComponent<Rollinrollinrollin>().roll = false;
			
			//Destroy (GameObject.Find ("First Person Controller").GetComponent<LifeSaving>());
			//GameObject.Find ("Object").GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
			GameObject.Find("First Person Controller").GetComponent<LifeSaving>().reset = true;
			GameObject.Find("Gate").transform.position = new Vector3(0.52129F, -142.71F, 471.017F);
			GameObject.Find("Object").transform.position = new Vector3(-0.2081F, -20.871F, 19.3425F);
			GameObject.Find("Object").transform.rigidbody.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationZ | 
				RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezePositionZ;
			GameObject.Find("First Person Controller").transform.position = new Vector3(1.01357F, -65.637466F, 131.416F);
			GameObject.Find("First Person Controller").transform.rotation = Quaternion.Euler(-10, 180, 0);
			GameObject.Find("Object").GetComponent<Rollinrollinrollin>().roll = true;
			GameObject.Find("Object").GetComponent<Rollinrollinrollin>().floorOpen = false;
			GameObject.Find("Gate").GetComponent<GateOpenLevel5>().lowered = false;
			GameObject.Find("Door").GetComponent<DoorOpen>().open = false;
			GameObject.Find("Hatch").GetComponent<MeshRenderer>().enabled = true;
			GameObject.Find("Hatch").GetComponent<BoxCollider>().enabled = true;
			GameObject.Find("Door").transform.position = new Vector3(-10.98F, -185.4771F, 493.1635F);
			GameObject.Find("Door").transform.rotation = Quaternion.Euler(20, 0, 0);
			//GameObject.Find ("First Person Controller").AddComponent<LifeSaving>();
			
			GameObject.Find("Main Camera").GetComponent<MouseLook>().enabled = true;
			GameObject.Find("First Person Controller").GetComponent<MouseLook>().enabled = true;
			GameObject.Find("First Person Controller").GetComponent<CharacterMotor>().enabled = true;
			GameObject.Find("Initialization").GetComponent<CursorTime>().showCursor = true;
			//GameObject.Find("First Person Controller").GetComponent<CharacterController>().enabled = true;
			GameObject.Find("Robo_Arm10").AddComponent<ArmAnimation2>();
			GameObject.Find("HatchTrigger").GetComponent<HatchTrigger>().stopit = false;
		
		}
	}
}
