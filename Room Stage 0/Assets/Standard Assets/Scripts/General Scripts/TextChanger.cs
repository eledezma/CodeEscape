using UnityEngine;
using System.Collections;

public class TextChanger: MonoBehaviour {
	
	string inputkey1= "1";
	string inputkey2= "2";
	string inputmessage1= "First Message";
	string inputmessage2= "Second Message";
	
	private TextMesh tm;
	
	void  Start (){  
		
		tm = GetComponent<TextMesh>();
		if( tm == null ) Debug.Log("No 3D Text component found");
	}
	
	void  Update (){
		
		if(Input.GetKeyDown(inputkey1)){
			print ( inputmessage1 );
			tm.text = inputmessage1; 
		}
		
		else if(Input.GetKeyDown(inputkey2)){
			print ( inputmessage2 ); 
			tm.text = inputmessage2; 
		}
		
	}
}