using UnityEngine;
using System.Collections;

public class LevelTransition : MonoBehaviour
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

			if(Application.loadedLevel==3)
			{
				GameObject.Find("First Person Controller").GetComponent<Player>().GuiEnabled = false;
			}
			if(Application.loadedLevel==10)
			{
				GameObject.Find("First Person Controller").GetComponent<Level10Health>().guiEnabled = false;
			}
            Application.LoadLevel(Application.loadedLevel + 1);
        }
    }
}
