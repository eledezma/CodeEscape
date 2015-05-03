using UnityEngine;
using System.Collections;

public class GameMenu : MonoBehaviour{

void OnMouseEnter(){
	//change text color
	renderer.material.color=Color.red;
}

void OnMouseExit(){
	//change text color
	renderer.material.color=Color.white;
}


	void OnTriggerEnter (Collider col) {
		if (col.gameObject.name == "txt_Start_Game") {
				
			Application.LoadLevel(1); 

				}
	}


void Update(){

	}
}
