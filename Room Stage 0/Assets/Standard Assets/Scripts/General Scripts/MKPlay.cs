using UnityEngine;
using System.Collections;

[RequireComponent(typeof(AudioSource))]

public class MKPlay : MonoBehaviour
{

    public Camera cam;
    MovieTexture movie;
    // Use this for initialization
    void Start()
    {
        movie = renderer.material.mainTexture as MovieTexture;
        StartCoroutine(Initial());
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator Initial()
    {
        movie.Play();
        audio.Play();
        yield return new WaitForSeconds(0.2F);
        movie.Pause();
        audio.Pause();
    }

    public IEnumerator PlayVideo()
    {
        cam.depth = 1;
        GameObject.Find("Initialization").GetComponent<AudioSource>().audio.Stop();
        GameObject.Find("Initialization").GetComponent<CursorTime>().showCursor = false;
        GameObject.Find("Initialization").GetComponent<AudioSource>().volume = 1;
        Screen.lockCursor = true;
        Screen.showCursor = false;
        GameObject.Find("Main Camera").GetComponent<MouseLook>().enabled = false;
        GameObject.Find("First Person Controller").GetComponent<MouseLook>().enabled = false;
        movie = renderer.material.mainTexture as MovieTexture;
        audio.clip = movie.audioClip;
        audio.Play();
        movie.Play();
        yield return new WaitForSeconds(audio.clip.length);
        movie.Stop();
        movie.Play();
        audio.Play();
        yield return new WaitForSeconds(0.2F);
        movie.Pause();
        audio.Pause();
        Application.LoadLevel(Application.loadedLevel);
    }
}
