using UnityEngine;
using System.Collections;

public class DoorOpenLevel6 : MonoBehaviour
{

    public GameObject target1;
    public GameObject target2;
    public GameObject target3;
    public AnimationClip doorOpen;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (target1.GetComponent<TargetColor>().blue && target2.GetComponent<TargetColor>().blue && target3.GetComponent<TargetColor>().blue)
        {
            animation.Play(doorOpen.name);
            Destroy(this);
        }
    }
}
