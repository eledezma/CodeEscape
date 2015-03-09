using UnityEngine;
using System.Collections;

public class CamTime : MonoBehaviour
{

    public int value;
    // Use this for initialization
    void Start()
    {
        //value = this.gameObject.GetComponent<Camera>().cullingMask;
        value = this.gameObject.layer;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
