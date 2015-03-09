using UnityEngine;
using System.Collections;

public class ButtonTriggerStage7 : MonoBehaviour
{

    public AudioClip ButtonClick;
    public GameObject button;
    public AnimationClip PushDown;
    public AnimationClip PushUp;
    public int numBullets;
    private bool buttondown;
    // Use this for initialization
    void Start()
    {
        numBullets = 1;
        buttondown = false;
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" && !buttondown)
        {
            buttondown = true;
            audio.PlayOneShot(ButtonClick);
            button.animation.Play(PushDown.name);
            StartCoroutine(GameObject.Find("turret/ShootCube").GetComponent<TurretShoot>().shoot(numBullets));
            /*if (button.animation.isPlaying)
                yield return new WaitForSeconds (0.5f);*/
            yield return new WaitForSeconds(4.5F);
            button.animation.Play(PushUp.name);
            if (button.animation.isPlaying)
                yield return new WaitForSeconds(0.5f);
            buttondown = false;
        }
    }
    IEnumerator OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player" && !buttondown)
        {
            buttondown = true;
            audio.PlayOneShot(ButtonClick);
            button.animation.Play(PushDown.name);
            StartCoroutine(GameObject.Find("turret/ShootCube").GetComponent<TurretShoot>().shoot(numBullets));
            /*if (button.animation.isPlaying)
                yield return new WaitForSeconds (0.5f);*/
            yield return new WaitForSeconds(4.5F);
            button.animation.Play(PushUp.name);
            if (button.animation.isPlaying)
            {
                yield return new WaitForSeconds(0.5f);
            }
            buttondown = false;
        }
    }
}
