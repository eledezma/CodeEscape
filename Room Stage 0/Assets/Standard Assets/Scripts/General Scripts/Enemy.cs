using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour
{

    public Transform target;
    public int speed = 1;
    public int rotationSpeed = 1;

    private Transform myTransform;
    void awake()
    {

    }

    // Use this for initialization
    void Start()
    {
        myTransform = transform;

        GameObject go = GameObject.Find("First Person Controller");
        target = go.transform;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.DrawLine(target.position, myTransform.position, Color.red);
        myTransform.rotation = Quaternion.Slerp(myTransform.rotation, Quaternion.LookRotation(target.position - myTransform.position), rotationSpeed * Time.deltaTime);
        myTransform.position += myTransform.forward * speed * Time.deltaTime;
    }
}
