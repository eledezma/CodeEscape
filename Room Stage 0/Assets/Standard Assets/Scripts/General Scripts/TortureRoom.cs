using UnityEngine;
using System.Collections;

public class TortureRoom : MonoBehaviour
{

    public AudioClip tortureSound;
    // Use this for initialization
    void Start()
    {

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "creepy_door")
        {
            audio.PlayOneShot(tortureSound, 25);
        }

    }

    // Update is called once per frame
    void Update()
    {

    }
}
