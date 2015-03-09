using UnityEngine;
using System.Collections;

public class WalkingAnimation : MonoBehaviour
{

    float walking;
    private Animator animate;
    // Use this for initialization
    void Start()
    {
        animate = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.Find("First Person Controller").GetComponent<CharacterMotor>().enabled)
        {  //if the character can walk, then walking animation is enabled
            if (Input.GetKeyDown("w") || Input.GetKeyDown("up"))
            {
                walking += 1;

            }
            if (Input.GetKeyUp("w") || Input.GetKeyUp("up"))
            {
                walking -= 1;

            }
            if (Input.GetKeyDown("s") || Input.GetKeyDown("down"))
            {
                walking += 1;

            }
            if (Input.GetKeyUp("s") || Input.GetKeyUp("down"))
            {
                walking -= 1;

            }
            if (Input.GetKeyDown("a") || Input.GetKeyDown("left"))
            {
                walking += 1;

            }
            if (Input.GetKeyUp("a") || Input.GetKeyUp("left"))
            {
                walking -= 1;

            }
            if (Input.GetKeyDown("d") || Input.GetKeyDown("right"))
            {
                walking += 1;

            }
            if (Input.GetKeyUp("d") || Input.GetKeyUp("right"))
            {
                walking -= 1;
            }
        }
    }
    void FixedUpdate()
    {
        animate.SetFloat("walking", walking);
    }
}
