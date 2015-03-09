using UnityEngine;
using System.Collections;


public class FoodTrigger : MonoBehaviour
{


    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
        GameObject.Find("Door").audio.Play();
        GameObject.Find("Door").GetComponent<DoorOpen>().open = true;
    }
}
