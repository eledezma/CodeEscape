using UnityEngine;
using System.Collections;

public class GenerateShots : MonoBehaviour {

	public GameObject sphere;
	public Texture green;
	public Texture blue;
	private bool createShot1;
	private bool createShot2;
	private bool createShot3;
	private bool createShot4;
	private bool first;
	// Use this for initialization
	void Start () 
	{
		createShot1 = true;
		createShot2 = true;
		createShot3 = true;
		createShot4 = true;
		first = true;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (createShot1) 
		{
			createShot1 = false;
			StartCoroutine (makeShot1 ());
		}
		if (createShot2) 
		{
			createShot2 = false;
			StartCoroutine (makeShot2 ());
		}
		if (createShot3) 
		{
			createShot3 = false;
			StartCoroutine (makeShot3 ());
		}
		if (createShot4) 
		{
			createShot4 = false;
			StartCoroutine (makeShot4 ());
		}
		first = false;
	}

	IEnumerator makeShot1()
	{
		//shot 1
		if (!first) 
		{
			GameObject shot = (GameObject)Instantiate(sphere, new Vector3(-8.177089F, 11.09282F, 37.93257F), transform.rotation);
			shot.AddComponent ("ShotMovement");
			shot.GetComponent<SphereCollider> ().isTrigger = true;
			shot.GetComponent<ShotMovement>().color = 1;
			shot.renderer.material = new Material(Shader.Find("Unlit/Texture"));
			shot.transform.localScale = new Vector3(2, 2, 2);
			shot.renderer.material.mainTexture = blue;
			yield return new WaitForSeconds (0.10F);
		}
		else 
		{
			yield return new WaitForSeconds (0.01F);
		}
		//at end
		createShot1 = true;
	}

	IEnumerator makeShot2()
	{
		//shot 1
		if (!first) 
		{
			GameObject shot = (GameObject)Instantiate(sphere, new Vector3(-8.184517F, 23.23381F, 38.21523F), transform.rotation);
			shot.AddComponent ("ShotMovement");
			shot.GetComponent<SphereCollider> ().isTrigger = true;
			shot.GetComponent<ShotMovement>().color = 1;
			shot.renderer.material = new Material(Shader.Find("Unlit/Texture"));
			shot.transform.localScale = new Vector3(2, 2, 2);
			shot.renderer.material.mainTexture = blue;
			yield return new WaitForSeconds (0.10F);
		}
		else 
		{
			yield return new WaitForSeconds (0.01F);
		}
		//at end
		createShot2 = true;
	}

	IEnumerator makeShot3()
	{
		//shot 3
		if (!first) 
		{
			GameObject shot = (GameObject)Instantiate (sphere, new Vector3 (-81.6478F, 11.08865F, 38.21523F), transform.rotation);
			shot.AddComponent ("ShotMovement");
			shot.GetComponent<SphereCollider> ().isTrigger = true;
			shot.GetComponent<ShotMovement>().color = 2;
			shot.renderer.material = new Material (Shader.Find ("Unlit/Texture"));
			shot.transform.localScale = new Vector3(2, 2, 2);
			shot.renderer.material.mainTexture = green;
			yield return new WaitForSeconds (0.10F);
		} 
		else 
		{
			yield return new WaitForSeconds (0.01F);
		}

		createShot3 = true;
	}

	IEnumerator makeShot4()
	{
		//shot 4
		if (!first)
		{
			GameObject shot = (GameObject)Instantiate (sphere, new Vector3 (-81.98382F, 24.1359F, 38.21523F), transform.rotation);
			shot.AddComponent ("ShotMovement");
			shot.GetComponent<SphereCollider> ().isTrigger = true;
			shot.GetComponent<ShotMovement>().color = 2;
			shot.renderer.material = new Material (Shader.Find ("Unlit/Texture"));
			shot.transform.localScale = new Vector3 (2, 2, 2);
			shot.renderer.material.mainTexture = green;
			yield return new WaitForSeconds (0.10F);

		} 
		else 
		{
			yield return new WaitForSeconds (0.01F);
		}

		createShot4 = true;
	}
}
