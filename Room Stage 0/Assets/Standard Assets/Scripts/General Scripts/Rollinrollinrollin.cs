using UnityEngine;
using System.Collections;

public class Rollinrollinrollin : MonoBehaviour
{

		bool roll = false;
		public static float speed = 0.1f;
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
				if (Input.GetKeyDown ("r"))
						roll = true;
		}
}
