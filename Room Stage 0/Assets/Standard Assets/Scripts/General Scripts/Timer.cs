using UnityEngine;
using System.Collections;

public class Timer : MonoBehaviour {
	
	
	float timer = 10.0f;
	bool guiPlay;

	void Start(){
		guiPlay = true;
	}
	
	void  Update (){
		
		timer -= Time.deltaTime;
		//Debug.Log (timer);
		if(timer < 0.0F){
			guiPlay = false;
			//Destroy (this);
			//DO SOMETHING KOOL
		}
		
	}
	
	void  OnGUI (){
		if (guiPlay)
			GUI.Box(new Rect(650, 40, 80, 40), "" + timer.ToString("0"));
	}

}