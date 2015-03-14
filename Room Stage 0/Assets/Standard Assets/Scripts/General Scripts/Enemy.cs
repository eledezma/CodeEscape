using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour
{

    public Transform target;
    public int speed = 1;
    public int rotationSpeed = 1;
	public bool attacking = false;
	Vector3 Node1;

	public float timer = 4000.0F;
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
		Node1 = new Vector3(myTransform.position.x + 1, myTransform.position.y,myTransform.position.z);
    }

    // Update is called once per frame
    void Update()
    {
		if(attacking)
		{
      		Debug.DrawLine(target.position, myTransform.position, Color.red);
        	myTransform.rotation = Quaternion.Slerp(myTransform.rotation, Quaternion.LookRotation(target.position - myTransform.position), rotationSpeed * Time.deltaTime);
        	myTransform.position += myTransform.forward * speed * Time.deltaTime;
    
		}
		else
		{
			timer-=Time.deltaTime;
			if(myTransform.position.x!=Node1.x)
			myTransform.position += myTransform.forward * speed * Time.deltaTime;
			if(timer<=0.0F)
			{
				speed = 100;

				myTransform.Rotate(180,0,0);
				timer = 4000.0F;
			}
		}
	}
}
