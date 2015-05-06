using UnityEngine;
using System.Collections;

public class HatchTrigger : MonoBehaviour
{

	public bool stopit;
    // Use this for initialization
    void Start()
    {
		stopit = false;
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.tag == "Boulder" && GameObject.Find("Object").GetComponent<Rollinrollinrollin>().floorOpen)
        {
            //GameObject.Find ("Object").GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
            GameObject.Find("Object").GetComponent<Rollinrollinrollin>().roll = false;
			GameObject.Find("Object").transform.rigidbody.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationZ;
            Debug.Log("Yahoo");
            //Destroy(this);
        }

    }
    void OnTriggerStay(Collider other)
    {
		if (!stopit)
		{
	        if (other.gameObject.tag == "Boulder" && GameObject.Find("Object").GetComponent<Rollinrollinrollin>().floorOpen)
	        {
				stopit = true;
	            //GameObject.Find ("Object").GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
	            GameObject.Find("Object").GetComponent<Rollinrollinrollin>().roll = false;
				GameObject.Find("Object").transform.rigidbody.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationZ;
	            Debug.Log("Yahoo");
	            //Destroy(this);
	        }
		}
    }
}
