using UnityEngine;
using System.Collections;

public class shoot : MonoBehaviour
{

    public GameObject bullet_prefab;
    float bulletImpulse = 60f;
    GameObject[] NumBullets;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Camera cam = Camera.main;
            GameObject thebullet = (GameObject)Instantiate(bullet_prefab, cam.transform.position + cam.transform.forward, cam.transform.rotation);
            thebullet.tag = "Bullet";
            thebullet.rigidbody.AddForce(cam.transform.forward * bulletImpulse, ForceMode.Impulse);
        }
        NumBullets = GameObject.FindGameObjectsWithTag("Bullet");
        if (NumBullets.Length > 9)
        {
            Destroy(NumBullets[0]);
        }
    }



    /*void Update () {
        if( Input.GetButtonDown("Fire1") ) {
            Camera cam = Camera.main;
            GameObject thebullet = (GameObject)Instantiate(bullet_prefab, cam.transform.position + cam.transform.forward, cam.transform.rotation);
            thebullet.tag = "Bullet";
            thebullet.rigidbody.AddForce( cam.transform.forward * bulletImpulse, ForceMode.Impulse);
            StartCoroutine (DestroyBullet(thebullet));
        }
    }

    IEnumerator DestroyBullet(GameObject bullet){
        yield return new WaitForSeconds (10);
        Destroy (bullet);	
    }
    */
}
