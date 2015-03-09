using UnityEngine;
using System.Collections;

public class SoundTrigger : MonoBehaviour
{

    public AudioClip sound;
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
        Debug.Log("SUCKIT");
        if (other.gameObject.tag == "Player")
            audio.PlayOneShot(sound);
    }

}
