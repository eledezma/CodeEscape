
using UnityEngine;
using System.Collections;

public class ToolTipTxtSkeleton : MonoBehaviour
{
    public string toolTipText = "";
    public string info = "";

    private string currentToolTipText = "";
    private GUIStyle guiStyleFore;
    private GUIStyle guiStyleBack;
    private bool nextTo = false;
    bool clickable = false;
    bool enabled = false;

    void Start()
    {
        guiStyleFore = new GUIStyle();
        guiStyleFore.normal.textColor = Color.white;
        guiStyleFore.alignment = TextAnchor.UpperCenter;
        guiStyleFore.wordWrap = true;
        guiStyleFore.fontStyle = FontStyle.Italic;
        guiStyleFore.fontSize = 15;

        guiStyleBack = new GUIStyle();
        guiStyleBack.normal.textColor = Color.black;
        guiStyleBack.alignment = TextAnchor.UpperCenter;
        guiStyleBack.wordWrap = true;
        guiStyleBack.fontStyle = FontStyle.Italic;
        guiStyleBack.fontSize = 15;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (clickable && !enabled)
            {
                enabled = true;
                Screen.lockCursor = true;
                GameObject.Find("Main Camera").GetComponent<MouseLook>().enabled = false;
                GameObject.Find("First Person Controller").GetComponent<MouseLook>().enabled = false;
                GameObject.Find("Initialization").GetComponent<CursorTime>().showCursor = false;
                GameObject.Find("First Person Controller").GetComponent<CharacterMotor>().enabled = false;
                //Screen.showCursor = false;
            }
            else if (clickable && enabled)
            {
                enabled = false;
                GameObject.Find("Main Camera").GetComponent<MouseLook>().enabled = true;
                GameObject.Find("First Person Controller").GetComponent<MouseLook>().enabled = true;
                GameObject.Find("Initialization").GetComponent<CursorTime>().showCursor = true;
                GameObject.Find("First Person Controller").GetComponent<CharacterMotor>().enabled = true;
                Screen.lockCursor = false;
                //Screen.showCursor = true;
            }
        }
    }
    void OnTriggerEnter()
    {
        nextTo = true;
    }
    void OnMouseEnter()
    {
        currentToolTipText = toolTipText;

        clickable = true;
    }

    void OnMouseExit()
    {
        currentToolTipText = "";
        clickable = false;
        //	enabled = false;
    }

    void OnGUI()
    {
        GUI.UnfocusWindow();
        if ((enabled) && (info != ""))
        {
            GUI.Box(new Rect(Screen.width * 0.35f, Screen.height * 0.35f, Screen.width * 0.3f, Screen.height * 0.3f), currentToolTipText);
            GUI.Label(new Rect(Screen.width * 0.35f, Screen.height * 0.35f, Screen.width * 0.3f, Screen.height * 0.3f), "\n\n" + info);
        }
        else if (currentToolTipText != "")
        {
            float x = Event.current.mousePosition.x;
            float y = Event.current.mousePosition.y;
            GUI.Label(new Rect(x - 149, y + 40, 300, 60), currentToolTipText, guiStyleBack);
            GUI.Label(new Rect(x - 150, y + 40, 300, 60), currentToolTipText, guiStyleFore);
        }
    }
}