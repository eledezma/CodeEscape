using UnityEngine;
using System.Collections;

public class Rollinrollinrollin : MonoBehaviour
{

		public bool roll = false;
		bool floorOpen = false;
		public static float speed = 0.17f;
		public static float offset = 0;
		// Use this for initialization
		void Start ()
		{
	
		}
	
		// Update is called once per frame
		void Update ()
		{
			if (roll) {

					GameObject.Find ("Object").transform.Translate (Vector3.forward * speed);
					GameObject.Find ("Object").transform.Translate (Vector3.down * speed * 0.36397f); 
					// angle of hallway is 20 degrees 0.36397f is tan of 20 ... mother of math!


					offset += (Time.deltaTime * speed * 8) / 1.0f;

					//moves textures
					GameObject.Find ("Object").renderer.material.SetTextureOffset ("_MainTex", new Vector2 (0, offset));
					
			}
			
			if (floorOpen) {
					GameObject.Find ("Hatch").GetComponent<MeshRenderer> ().enabled = false;
					GameObject.Find ("Hatch").GetComponent<BoxCollider> ().enabled = false;
			}

			if (Input.GetKeyDown ("r"))
					roll = true;
			if (Input.GetKeyDown ("f"))
				floorOpen = true;
		
	}
	    void OnCollisionEnter(Collision col){
		    if (col.gameObject.tag == "Player")
				roll = false;

		}
}
