using UnityEngine;
using System.Collections;

public class Timer : MonoBehaviour {
	
	
	float timer = 10.0f;
	
	
	void  Update (){
		
		timer -= Time.deltaTime;
		
		if(timer ==0){
			

			//DO SOMETHING KOOL
		}
		
	}
	
	void  OnGUI (){
		
		GUI.Box(new Rect(650, 40, 80, 40), "" + timer.ToString("0"));
	}

}