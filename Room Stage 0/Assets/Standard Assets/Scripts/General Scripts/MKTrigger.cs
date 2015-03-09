using UnityEngine;
using System.Collections;

public class MKTrigger : MonoBehaviour
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
        if (other.gameObject.tag == "Player")
        {
            StartCoroutine(GameObject.Find("MKPit").GetComponent<MKPlay>().PlayVideo());
        }
    }
}
