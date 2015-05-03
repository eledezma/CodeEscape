using UnityEngine;
using System.Collections;

public class Main : MonoBehaviour {
	//Top Banner
	public float topBannerH;
	public float topBannerW;
	//Buttons
	public float buttonSizeH;
	public float buttonSizeW;
	public float buttonPos1;
	public float buttonPos2;
	public float buttonPos3;
	//Bottom Banner
	public float bottomBannerH;
	public float bottomBannerW;
	public float bottomBannerPos;
	public string exampleVar1;
	public GUISkin customSkin1;
	public GUISkin customSkin2;
	public GUISkin customSkin3;
	
	void  Awake (){
		topBannerH = Screen.height/4;
		topBannerW = Screen.width;
		buttonSizeH = Screen.height/7;
		buttonSizeW = Screen.width;
		buttonPos1 = topBannerH;
		buttonPos2 = topBannerH+buttonSizeH;
		buttonPos3 = topBannerH+buttonSizeH*2;
		bottomBannerH = Screen.height;
		bottomBannerW =  Screen.width;
		bottomBannerPos = topBannerH+buttonSizeH*3;	
	}
	
	void  OnGUI (){
		GUI.skin = customSkin1;
		//Title Banner
		GUI.Box( new Rect(0,0,topBannerW,topBannerH),exampleVar1);
		
		GUI.skin = customSkin2;
		//Button 1
		if (GUI.Button( new Rect(0,buttonPos1,buttonSizeW,buttonSizeH),"START")){
			Debug.Log("START");
		}
		//Button 2
		if (GUI.Button( new Rect(0,buttonPos2,buttonSizeW,buttonSizeH),"CONTINUE")){
			Debug.Log("CONTINUE");
		}
		//Button 3
		if (GUI.Button( new Rect(0,buttonPos3,buttonSizeW,buttonSizeH),"QUIT")){
			Debug.Log("QUIT");
		}
		GUI.skin = customSkin3;
		//Bottom Banner
		GUI.Box( new Rect(0,bottomBannerPos,bottomBannerW,bottomBannerH),"COMP 491");
	}
}