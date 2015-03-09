using UnityEngine;
using System.Collections;

public class TurretShoot : MonoBehaviour
{

    public GameObject bullet_prefab;
    public float bulletImpulse;
    GameObject[] NumBullets;
    public bool test;

    // Use this for initialization
    void Start()
    {
        bulletImpulse = 60f;
        test = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (test || Input.GetKeyDown("9"))
        { //remove this
            StartCoroutine(shoot(2));
            test = false;
        }
        NumBullets = GameObject.FindGameObjectsWithTag("Bullet");
        if (NumBullets.Length > 9)
        {
            Destroy(NumBullets[0]);
        }
    }

    public IEnumerator shoot(int max)
    {
        for (int i = 0; i < max; i++)
        {
            GameObject thebullet = (GameObject)Instantiate(bullet_prefab, transform.position, transform.rotation);
            thebullet.tag = "Bullet";
            thebullet.rigidbody.AddForce(transform.forward * bulletImpulse, ForceMode.Impulse);
            yield return new WaitForSeconds(0.5f);
        }

    }
    public IEnumerator turn()
    {
        this.gameObject.GetComponentInParent<TurretTurn>().turn = true;
        yield return new WaitForSeconds(1f);
    }


}

