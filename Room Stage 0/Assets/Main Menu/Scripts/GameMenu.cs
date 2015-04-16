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




void Update(){
	//quit game if escape key is pressed
		if (Input.GetKey (KeyCode.Q)) {
			Application.Quit (); //"Q" QUITS GAME
		} 
		else if (Input.GetKey (KeyCode.S)) {
			Application.LoadLevel(1); // "S" STARTS GAME
		}
		else if (Input.GetKey (KeyCode.C)) {
			// CONTINUE GOES HIERE
		}
	}
}
