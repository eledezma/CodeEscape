using UnityEngine;
using System.Collections;

public class DeathTriggerLevel5 : MonoBehaviour
{

    public AudioClip self_death;
    public AudioClip people_death;
    // Use this for initialization
    void Start()
    {

    }

    void Update()
    {

    }

    // Update is called once per frame
    IEnumerator OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            //Destroy(GameObject.Find("Main Camera").GetComponent<MouseLook>());
            //Destroy(GameObject.Find("First Person Controller").GetComponent<MouseLook>());
            //GameObject.Find("First Person Controller").GetComponent<CharacterMotor>().canControl = false;
			GameObject.Find("Main Camera").GetComponent<MouseLook>().enabled = false;
			GameObject.Find("First Person Controller").GetComponent<MouseLook>().enabled = false;
			GameObject.Find("First Person Controller").GetComponent<CharacterMotor>().canControl = false;
			GameObject.Find("Initialization").GetComponent<CursorTime>().showCursor = false;
            //Destroy(GameObject.Find("Initialization").GetComponent<CursorTime>());
            Screen.lockCursor = true;
            GameObject.Find("First Person Controller").transform.rotation = Quaternion.Euler(90, 0, 0);
            audio.clip = self_death;
            audio.Play();
            yield return new WaitForSeconds(audio.clip.length);
			//Destroy(GameObject.Find("IndianaTrigger"));
			GameObject.Find("First Person Controller").GetComponent<LifeSaving>().reset = true;
			GameObject.Find("Gate").transform.position = new Vector3(0.52129F, -142.71F, 471.017F);
			GameObject.Find("Object").transform.position = new Vector3(-0.2081F, -20.871F, 19.3425F);
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
			GameObject.Find("Main Camera").GetComponent<MouseLook>().enabled = true;
			GameObject.Find("First Person Controller").GetComponent<MouseLook>().enabled = true;
			GameObject.Find("First Person Controller").GetComponent<CharacterMotor>().canControl = true;
			GameObject.Find("Initialization").GetComponent<CursorTime>().showCursor = true;
            //Application.LoadLevel(Application.loadedLevel);
        }
        if (other.gameObject.tag == "Boulder")
        {
			//GameObject.Find("Door").GetComponent<DoorOpen>().open = true;
            audio.clip = people_death;
            audio.Play();
        }
    }
}
