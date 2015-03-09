using UnityEngine;
using System.Collections;

public class ButtonTriggerStage4 : MonoBehaviour
{

    public AudioClip ButtonClick;
    public GameObject button;
    //public GameObject door; //Abel's Door
    public AnimationClip PushDown;
    public AnimationClip PushUp;
    public bool pushup;
    private bool buttondown;

    // Use this for initialization
    void Start()
    {
        buttondown = false;
        pushup = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (pushup)
        {
            StartCoroutine(PushItUp());
            pushup = false;
        }
    }

    IEnumerator OnTriggerEnter(Collider other)
    {

        if (other.gameObject.tag == "Player" && !buttondown)
        {
            buttondown = true;
            if (button.animation.isPlaying)
                yield return new WaitForSeconds(0.5f);
            Debug.Log("Object Entered the trigger");
            audio.PlayOneShot(ButtonClick);
            button.animation.Play(PushDown.name);
            GameObject.Find("d67").GetComponent<DiceRotateLoaded>().rot = true;
            GameObject.Find("d67").GetComponent<DiceRotateLoaded>().delay = true;
            GameObject.Find("d6").GetComponent<DiceRotateLoaded>().rot = true;
            GameObject.Find("d6").GetComponent<DiceRotateLoaded>().delay = true;
            //yield return new WaitForSeconds (PushDown.length);
        }


    }

    IEnumerator PushItUp()
    {
        button.animation.Play(PushUp.name);
        yield return new WaitForSeconds(1);
        int value1 = GameObject.Find("d6").GetComponent<Die_d6>().value;
        int value2 = GameObject.Find("d67").GetComponent<Die_d6>().value;
        //Debug.Log (value1);
        //Debug.Log (value2);
        if (value2 > value1)
            GameObject.Find("Door").GetComponent<DoorOpen>().open = true;
        Debug.Log("PUSH ME UP");
        buttondown = false;


    }

    IEnumerator OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player" && !buttondown)
        {
            buttondown = true;
            if (button.animation.isPlaying)
                yield return new WaitForSeconds(0.5f);
            Debug.Log("Object Stayed in the trigger");
            audio.PlayOneShot(ButtonClick);
            button.animation.Play(PushDown.name);
            GameObject.Find("d67").GetComponent<DiceRotateLoaded>().rot = true;
            GameObject.Find("d67").GetComponent<DiceRotateLoaded>().delay = true;
            GameObject.Find("d6").GetComponent<DiceRotateLoaded>().rot = true;
            GameObject.Find("d6").GetComponent<DiceRotateLoaded>().delay = true;
            //yield return new WaitForSeconds (PushDown.length);
        }

    }
}
