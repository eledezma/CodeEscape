using UnityEngine;
using System.Collections;

public class GateOpenLevel5 : MonoBehaviour
{

    public AnimationClip gateClosed;
    public bool lowered = false;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (lowered || Input.GetKeyDown("g"))
        {
            animation.Play(gateClosed.name);
            lowered = false;
        }

    }
}
