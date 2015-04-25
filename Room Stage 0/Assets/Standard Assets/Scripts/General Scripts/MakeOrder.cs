using UnityEngine;
using System.Collections;

public class MakeOrder : MonoBehaviour
{

    public static string order = "";
    bool guiEnabled = false;
    public static bool atOrderWall = false;
    public Texture2D cursorImage;
    GUIStyle title;

    // Use this for initialization

    void OnTriggerEnter(Collider col1)
    {
        if (col1.gameObject.name == "Terminal_Stage2")
        {
            atOrderWall = true;
            GameObject.Find("Arm Camera").camera.enabled = false;
            Debug.Log("at wall");
        }
    }

    void OnTriggerExit(Collider col1)
    {

        if (col1.gameObject.name == "Terminal_Stage2")
        {
            atOrderWall = false;
            guiEnabled = false;
            GameObject.Find("Arm Camera").camera.enabled = true;
        }

    }

    void Start()
    {
        //Screen.showCursor = false; 
        Screen.lockCursor = true;
    }
    //Switches the GUI on and off
    //*******************************************************
    void Update()
    {
        if (atOrderWall)
        {
            if (Input.GetKeyDown("e"))
            {
                if (guiEnabled)
                {
                    resume();
                }
                else
                {
                    Time.timeScale = 0.0f;
                    guiEnabled = true;
                    GameObject.Find("Main Camera").GetComponent<MouseLook>().enabled = false;
                    GameObject.Find("First Person Controller").GetComponent<MouseLook>().enabled = false;
                }
            }
        }
        else if (!atOrderWall && !scannerUi.atScanner)
        {

            //Screen.lockCursor = true;
            //Screen.lockCursor = false;
            //Cursor remains locked if not in terminal
        }
    }

    public void OnGUI()
    {
        if (!atOrderWall && !scannerUi.atScanner)
        {  //If not at wall terminal jack in - "show crosshair"
            //Vector3 mPos = Input.mousePosition;
            //GUI.DrawTexture (new Rect (mPos.x - 32, Screen.height - mPos.y - 32, 64, 64), cursorImage);
        }
        else if (atOrderWall && Input.GetKeyDown("e"))
        {
            GameObject.Find("Initialization").GetComponent<CursorTime>().showCursor = false;
            //If at wall terminal show default cursor instead
        }

        title = new GUIStyle();
        title.fontSize = 34;
        title.normal.textColor = Color.white;
        title.alignment = TextAnchor.MiddleCenter;
        GUI.skin.label.fontSize = 18;
        if (guiEnabled)
        {
            GUI.Box(new Rect(0, 0, Screen.width, Screen.height), "");
            GUI.Label(new Rect(Screen.width * .25f, Screen.height * .10f, Screen.width * .50f, Screen.height * .20f), "Make an Order", title);
            GUI.Box(new Rect(Screen.width * .25f, Screen.height * .30f, Screen.width * .50f, Screen.height * .50f), "");
            GUI.Label(new Rect(Screen.width * .4f, Screen.height * .37f, Screen.width * .2f, Screen.height * .05f), "What would you like to order?");
            order = GUI.TextField(new Rect(Screen.width * .40f, Screen.height * .52f, Screen.width * .20f, Screen.height * 0.05f), order);
            if (GUI.Button(new Rect(Screen.width * 0.46f, Screen.height * 0.60f, Screen.width * 0.08f, Screen.height * 0.05f), "Feed Me!"))
            {

                TextChanger_Stage2.Update();
                resume();
            }
        }
    }

    public void resume()
    {
        Time.timeScale = 1.0f;
        guiEnabled = false;
		if (scannerUi.puzzle2Complete)
		{
	        if (string.Compare(order, "hamburger", true) == 0)
	        {
	            GameObject.Find("Door").GetComponent<Food>().ham = true;
	        }
	        if (string.Compare(order, "waffle", true) == 0)
	        {
	            GameObject.Find("Door").GetComponent<Food>().bfast = true;
	        }
	        if (string.Compare(order, "cake", true) == 0)
	        {
	            GameObject.Find("Door").GetComponent<Food>().pie = true;
        	}
		}
        GameObject.Find("Initialization").GetComponent<CursorTime>().showCursor = true;
        GameObject.Find("Main Camera").GetComponent<MouseLook>().enabled = true;
        GameObject.Find("First Person Controller").GetComponent<MouseLook>().enabled = true;
    }

}
