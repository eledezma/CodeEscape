using UnityEngine;
using System.Collections;
public class TextChanger_Stage2: MonoBehaviour {
	
	static string inputmessage1= "";
	
	private static TextMesh tm;
	
	void  Start (){  
		
		tm = GetComponent<TextMesh>();
		if( tm == null ) Debug.Log("No 3D Text component found");
	}
	
	public static void Update (){
		
		print ( inputmessage1 );
		
		if (scannerUi.puzzle2Complete) {
			tm.text = MakeOrder.order;
		} 
		else {
			tm.text = "I can't read your Order";
		}
	}
}