using UnityEngine;
using System.Collections;

public class TargetColor : MonoBehaviour
{

    public int bulletCount; //change to non-public later
    public int goal;
    float lastBulletTime;
    public Texture redTarget;
    public Texture blueTarget;
    public bool blue;
    // Use this for initialization
    void Start()
    {
        bulletCount = 0;
        lastBulletTime = Time.time;
        blue = false;
    }

    // Update is called once per frame
    void Update()
    {  //to reset bulletcount after 6 seconds if no bullets hitting target
        if ((Time.time - lastBulletTime) > 3.7F && bulletCount > 0)
        {
            bulletCount = 0;
        }
        if (GameObject.Find("PlayButton").GetComponentInChildren<ButtonTriggerStage6>().answer > 6.1F)
            reset();
    }

    void OnCollisionEnter(Collision col)
    {

        if (col.gameObject.tag == "Bullet")
        {
            bulletCount = bulletCount + 1;
            lastBulletTime = Time.time;
        }
        if (bulletCount == goal)
        {
            renderer.material.mainTexture = blueTarget;
            blue = true;
            StartCoroutine(ChangeColor());
        }
    }

    public void reset()
    {
        renderer.material.mainTexture = redTarget;
        bulletCount = 0;
        blue = false;
    }

    IEnumerator ChangeColor()
    {
        yield return new WaitForSeconds(3.7F);
        renderer.material.mainTexture = redTarget;
        bulletCount = 0;
        blue = false;
    }
}
