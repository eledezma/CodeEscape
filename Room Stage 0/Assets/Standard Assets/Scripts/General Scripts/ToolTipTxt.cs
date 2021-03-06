﻿
using UnityEngine;
using System.Collections;

public class ToolTipTxt : MonoBehaviour
{
    public string toolTipText = "";
    public string info = "";

    private string currentToolTipText = "";
    private GUIStyle guiStyleFore;
    private GUIStyle guiStyleBack;
    private bool nextTo = false;
    bool clickable = false;
    bool Enabled = false;

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
            if (clickable && !Enabled)
            {
                Enabled = true;
            }
            else if (clickable && Enabled)
            {
                Enabled = false;
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
        //	Enabled = false;
    }

    void OnGUI()
    {
        GUI.UnfocusWindow();
        if ((Enabled) && (info != ""))
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