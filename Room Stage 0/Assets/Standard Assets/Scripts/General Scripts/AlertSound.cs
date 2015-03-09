using UnityEngine;
using System.Collections;

public class AlertSound : MonoBehaviour
{
    bool played = false;
    public AudioClip alert;
    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        float fYRot = Camera.main.transform.eulerAngles.y;
        if ((fYRot < 10) && (!played))
        {
            audio.PlayOneShot(alert);
            played = true;
        }
    }
}
