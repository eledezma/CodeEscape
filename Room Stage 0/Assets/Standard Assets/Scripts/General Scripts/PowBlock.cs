using UnityEngine;
using System.Collections;

public class PowBlock : MonoBehaviour
{

    public AudioClip sound;
    public GameObject armCam;
    GameObject[] NumBullets;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            audio.PlayOneShot(sound);
            GameObject.Find("Initialization").GetComponent<CubeCreationStage7>().enabled = true;
            this.gameObject.GetComponent<MeshRenderer>().enabled = false;
            yield return new WaitForSeconds(0.5F);
            GameObject.Find("Main Camera").GetComponent<MouseLook>().enabled = true;
            GameObject.Find("First Person Controller").GetComponent<MouseLook>().enabled = true;
            armCam.SetActive(true);
            Screen.lockCursor = false;
            GameObject.Find("Initialization").GetComponent<CursorTime>().showCursor = true;
            GameObject.Find("MaxCam").GetComponent<Camera>().depth = -1;
            NumBullets = GameObject.FindGameObjectsWithTag("Bullet");
            for (int i = 0; i < NumBullets.Length; i++)
                Destroy(NumBullets[i]);
            GameObject.Find("PlayButton/PlayTrigger").GetComponent<ButtonTriggerStage7>().numBullets = 0;

            //Destroy (this.gameObject);
        }
    }
}
