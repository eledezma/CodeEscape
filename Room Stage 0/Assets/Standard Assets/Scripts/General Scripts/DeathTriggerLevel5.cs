using UnityEngine;
using System.Collections;

public class DeathTriggerLevel5 : MonoBehaviour
{

    public AudioClip self_death;
    public AudioClip people_death;
    // Use this for initialization
    void Start()
    {

    }

    void Update()
    {

    }

    // Update is called once per frame
    IEnumerator OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Destroy(GameObject.Find("Main Camera").GetComponent<MouseLook>());
            Destroy(GameObject.Find("First Person Controller").GetComponent<MouseLook>());
            GameObject.Find("First Person Controller").GetComponent<CharacterMotor>().canControl = false;
            Destroy(GameObject.Find("Initialization").GetComponent<CursorTime>());
            Screen.lockCursor = true;
            GameObject.Find("First Person Controller").transform.rotation = Quaternion.Euler(90, 0, 0);
            audio.clip = self_death;
            audio.Play();
            yield return new WaitForSeconds(audio.clip.length);
            Application.LoadLevel(4);
        }
        if (other.gameObject.tag == "Boulder")
        {
            audio.clip = people_death;
            audio.Play();
        }
    }
}
