using UnityEngine;
using System.Collections;

public class ScannerInfoLevel2 : MonoBehaviour
{
    public bool guiEnabeled = true;
    public string info = "The Scanner class is part of the java.util package." +
        "\nScanner's in java are used to get user input, but" +
        "\n that is not their only purpose. The method nextLine()" +
        "\n is part of the Scanner class and is used to get the " +
        "\n next line the user enters as the input.";
    // Use this for initialization
    void Start()
    {
        GameObject.Find("Main Camera").GetComponent<MouseLook>().enabled = false;
        GameObject.Find("First Person Controller").GetComponent<MouseLook>().enabled = false;
        GameObject.Find("First Person Controller").GetComponent<CharacterMotor>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void OnGUI()
    {
        if (guiEnabeled)
        {
            GUILayout.Box("Info");
            GUILayout.TextArea(info);
            //if(GUILayout.Button("Submit")){
            if (Input.GetKeyDown("e"))
            {
                resume();
                //CursorTime.showCursor = false;
            }
        }
    }
    public void resume()
    {
        Time.timeScale = 1.0f;
        guiEnabeled = false;
        GameObject.Find("Main Camera").GetComponent<MouseLook>().enabled = true;
        GameObject.Find("First Person Controller").GetComponent<MouseLook>().enabled = true;
        GameObject.Find("Initialization").GetComponent<CursorTime>().enabled = true;
        GameObject.Find("First Person Controller").GetComponent<MakeOrder>().enabled = true;
        GameObject.Find("First Person Controller").GetComponent<scannerUi>().enabled = true;
        GameObject.Find("Wall_Jack_S2").GetComponent<ToolTipTxt>().enabled = true;
        GameObject.Find("Terminal_Stage2").GetComponent<ToolTipTxt>().enabled = true;
        GameObject.Find("First Person Controller").GetComponent<CharacterMotor>().enabled = true;
    }
}

