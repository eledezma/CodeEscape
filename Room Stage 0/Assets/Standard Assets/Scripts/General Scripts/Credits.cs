using UnityEngine;
using System.Collections;

public class Credits : MonoBehaviour{
public TextAsset CreditsText;
	
	public float Speed = 0.1f;
 
	public int MaxFontSize = 20;
 
	public GUIStyle TextStyle = new GUIStyle();
	
	private GameObject creditHolder;
 
	private GUIText creditText;
	
	private Transform creditHolderTransform;
 
	public void Start()
	{
		InitializeCreditHolder();
		RecalculateFontSize();
		PlaceCreditsAtTheScreensBottom();
	}
 
	public void Update()
	{
		RecalculateFontSize();
		MoveCreditsTextUntilEndIsReached();
	}
 
	private void InitializeCreditHolder()
	{
		creditHolder = new GameObject ("Credits");
		creditText = creditHolder.AddComponent<GUIText> ();
		creditText.alignment = TextAlignment.Center;
		creditText.anchor = TextAnchor.LowerCenter;
		creditText.text = GetCreditsText ();
		creditText.fontStyle = TextStyle.fontStyle;
		creditHolderTransform = creditHolder.transform;
	}
 
	void RecalculateFontSize ()
	{
		int fontSize = MaxFontSize;
		do 
		{
			creditText.fontSize = fontSize;
			fontSize--;
		} while (creditText.GetScreenRect().width>Screen.width);
	}
 
	void PlaceCreditsAtTheScreensBottom ()
	{
		float screeny=0;
		float y=0.0f;
		float minScreenY = (-1.0f * creditText.GetScreenRect().height)+Screen.height/2;
		do
		{	
			creditHolderTransform.position = new Vector2(0.5f, y);
			y -= 0.1f;
			
			screeny = creditText.GetScreenRect().y;
		}while(screeny>minScreenY);
	}
 
	private string GetCreditsText()
	{
		if (CreditsText != null) 
		{
			return CreditsText.text;
		}
		return CreatePlaceHolderText();
	}
	
	private string CreatePlaceHolderText ()
	{
		string placeHolderText = "These credits are only a placeholder\n\n\n";
		for (int i = 0; i < 100; i++) 
		{
			placeHolderText+="Please set 'CreditsText' text asset for real credits...\n";
		}
		placeHolderText += "\n\n\n\n\nThanks for watching placeholder credits this far :)";
		return placeHolderText;
	}
 
	private void MoveCreditsTextUntilEndIsReached ()
	{
		if(creditText.GetScreenRect().y > Screen.height*0.35)
		{
			Application.Quit();
			return;

		}
		creditHolderTransform.Translate(Vector3.up * Time.deltaTime * Speed);
	}
}