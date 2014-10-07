using UnityEngine;
using System.Collections;

public class TextChanger: MonoBehaviour {

	private static TextMesh tm;
	
	void  Start (){  
		
		tm = GetComponent<TextMesh>();
		if( tm == null ) Debug.Log("No 3D Text component found");
	}
	
	public static void Update (){

			tm.text = codingUI.text;
		
	}
}