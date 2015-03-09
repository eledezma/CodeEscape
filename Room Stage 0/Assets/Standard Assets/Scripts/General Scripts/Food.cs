using UnityEngine;
using System.Collections;

public class Food : MonoBehaviour
{

    public GameObject hamburger;
    public GameObject cake;
    public GameObject waffle;
    private GameObject food;
    public bool ham;
    public bool pie;
    public bool bfast;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (ham)
        {
            food = Instantiate(hamburger, new Vector3(-2.92F, 0.5F, -1.16F), Quaternion.identity) as GameObject;
            food.renderer.material.shader = Shader.Find("Diffuse");
            food.transform.localScale = new Vector3(20F, 20F, 20F);
            food.AddComponent("FoodTrigger");
            food.AddComponent("BoxCollider");
            food.collider.isTrigger = true;
            Destroy(this);
        }
        else if (bfast)
        {
            food = Instantiate(waffle, new Vector3(-2.92F, 0.5F, -1.16F), Quaternion.identity) as GameObject;
            food.renderer.material.shader = Shader.Find("Diffuse");
            food.transform.localScale = new Vector3(20F, 20F, 20F);
            food.AddComponent("FoodTrigger");
            food.AddComponent("BoxCollider");
            food.collider.isTrigger = true;
            Destroy(this);
        }
        else if (pie)
        {
            food = Instantiate(cake, new Vector3(-2.92F, 0.5F, -1.16F), Quaternion.identity) as GameObject;
            food.renderer.material.shader = Shader.Find("Diffuse");
            food.transform.localScale = new Vector3(20F, 20F, 20F);
            food.AddComponent("FoodTrigger");
            food.AddComponent("BoxCollider");
            food.collider.isTrigger = true;
            Destroy(this);
        }
    }
}
