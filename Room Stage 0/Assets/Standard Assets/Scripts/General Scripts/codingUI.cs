using UnityEngine;
using System.Collections;

public class codingUI : MonoBehaviour
{
    bool puzzle1Complete = false;
    bool guiEnabled = false;
    bool atWall = false;
    public AudioClip missionComplete;
    TextEditor editor;
    static string text = "";
    public static string output = "";
    public Texture2D cursorImage;
    int forStart;
    int forFinish;
    //GameObject Arms;
    public string code = "public class game{\n" +
            "\tpublic static void main(String[] args){\n" +
            "\t\t\n" +
            "\t}\n" +
            "}";

    void OnTriggerEnter(Collider other)
    {
        atWall = true;
        GameObject.Find("Arm Camera").camera.enabled = false;
        //Arms.camera.enabled = false;
    }

    void OnTriggerExit(Collider other)
    {
        atWall = false;
        guiEnabled = false;
        //Arms.camera.enabled = true;
        GameObject.Find("Arm Camera").camera.enabled = true;
    }

    void Start()
    { //I've commented this method out and nothing bad happens :o -Joseph
        Screen.lockCursor = true;
        //Screen.showCursor = false;
    }
    //Switches the GUI on and off
    //*******************************************************
    void Update()
    {
        if (atWall)
        {
            if (Input.GetKeyDown("e"))
            {
                //			Screen.lockCursor = false;  //Cursor is free to move when user goes into terminal
                if (guiEnabled)
                {
                    resume();
                }
                else
                {
					StartCoroutine(jackin ());
                }
            }
        }
        else
        {
            //Screen.showCursor = false;
            Screen.lockCursor = true;  //Hiding Cursor means redoing the way the crosshair was implemented -Josephs
            Screen.lockCursor = false; //Cursor remains locked if not in terminal
        }
    }
    //*******************************************************


    //Includes all the GUI elements
    //*******************************************************
    public void OnGUI()
    {
        if (!atWall)
        {  //If not at wall terminal jack in - "show crosshair"
            Vector3 mPos = Input.mousePosition;
            //GUI.DrawTexture (new Rect (mPos.x - 32, Screen.height - mPos.y - 32, 64, 64), cursorImage);
        }
        else if (atWall && Input.GetKeyDown("e"))
        {

            //If at wall terminal show default cursor instead
        }

        if (guiEnabled)
        {
            GUI.Box(new Rect(0, 0, Screen.width, Screen.height), "List of Functions");

            GUI.SetNextControlName("textarea");
            GUI.TextArea(new Rect(Screen.width * 0.2f, Screen.width * 0.04f, Screen.width * 0.75f, Screen.height * 0.75f), code);
            editor = (TextEditor)GUIUtility.GetStateObject(typeof(TextEditor), GUIUtility.keyboardControl);
            editor.SelectNone();

            /*	GUI.Label(new Rect(500, 500, 200, 200), string.Format("Selected text: {0}\nPos: {1}\nSelect pos: {2}\nLines Before: {3}\nLines After: {4}",
                                                      editor.SelectedText,
                                                      editor.pos,
                                                      0,
                                                      countLinesBefore(code,editor.pos),
                                                      countLinesAfter(code,editor.pos)));*/

            int temp;

            GUI.Label(new Rect(Screen.width * 0.12f, Screen.height * 0.14f, Screen.width * 0.04f, Screen.height * 0.05f), ("string"));						//print statement title
            text = GUI.TextField(new Rect(Screen.width * 0.12f, Screen.height * 0.18f, Screen.width * 0.04f, Screen.height * 0.05f), text);    			//print statement textfield

            // for loop starting value textfield
            //*******************************************************
            string fs = GUI.TextField(new Rect(Screen.width * 0.12f, Screen.height * 0.28f, Screen.width * 0.04f, Screen.height * 0.05f), forStart.ToString());
            if (int.TryParse(fs, out temp))
            {
                forStart = Mathf.Clamp(temp, 0, 100);
            }
            else if (fs == "")
            {
                forStart = 0;
            }
            //*******************************************************
            GUI.Label(new Rect(Screen.width * 0.12f, Screen.height * 0.24f, Screen.width * 0.04f, Screen.height * 0.05f), ("start"));  	//for loop parameter title

            //for loop ending value textfield
            //*******************************************************
            string ff = GUI.TextField(new Rect(Screen.width * 0.16f, Screen.height * 0.28f, Screen.width * 0.04f, Screen.height * 0.05f), forFinish.ToString());
            if (int.TryParse(ff, out temp))
            {
                forFinish = Mathf.Clamp(temp, 0, 100);
            }
            else if (ff == "")
            {
                forFinish = 0;
            }
            //*******************************************************
            GUI.Label(new Rect(Screen.width * 0.16f, Screen.height * 0.24f, Screen.width * 0.04f, Screen.height * 0.05f), ("finish"));  	//for loop parameter title

            // Button that inserts a print statement
            if (GUI.Button(new Rect(Screen.width * 0.02f, Screen.height * 0.18f, Screen.width * 0.1f, Screen.height * 0.05f), "Printout"))
            {
                GUI.FocusControl("textarea");
                editor = goToNextEmptyLine(editor, code);
                if (text.ToLower() == "hello world")
                {
                    puzzle1Complete = true;
                }

                if ((countLinesBefore(code, editor.pos) >= 2) && (countLinesAfter(code, editor.pos) >= 2) && isBlankLine(code, editor.pos))
                {
                    int num = getNumOfTabs(code, editor.pos);
                    code = addToCode(code, editor, "System.out.println(\"" + text + "\");\n" + addedTabs(num));
                    output = output.Insert(output.Length, text + "\n");
                }
            }

            // Button that inserts a for loop
            if (GUI.Button(new Rect(Screen.width * 0.02f, Screen.height * 0.28f, Screen.width * 0.1f, Screen.height * 0.05f), "For Loop"))
            {
                GUI.FocusControl("textarea");
                editor = goToNextEmptyLine(editor, code);
                int num = getNumOfTabs(code, editor.pos);
                if ((countLinesBefore(code, editor.pos) >= 2) && (countLinesAfter(code, editor.pos) >= 2) && isBlankLine(code, editor.pos))
                {
                    code = addToCode(code, editor, "For(int counter=" + fs + ";counter<=" + ff + ";counter++){\n" + addedTabs(num) + "\t\n" + addedTabs(num) + "}\n" + addedTabs(num));
                }
            }

            // Button inserts a while loop
            if (GUI.Button(new Rect(Screen.width * 0.02f, Screen.height * 0.38f, Screen.width * 0.1f, Screen.height * 0.05f), "While Loop"))
            {
                GUI.FocusControl("textarea");
                editor = goToNextEmptyLine(editor, code);
                int num = getNumOfTabs(code, editor.pos);
                if ((countLinesBefore(code, editor.pos) >= 2) && (countLinesAfter(code, editor.pos) >= 2) && isBlankLine(code, editor.pos))
                    code = addToCode(code, editor, "while(){\n" + addedTabs(num) + "\t\n" + addedTabs(num) + "}\n" + addedTabs(num));
            }


            // Button that activates the user's code
            if (GUI.Button(new Rect(Screen.width * 0.6f, Screen.height * 0.9f, Screen.width * 0.08f, Screen.height * 0.05f), "Submit"))
            {
                TextChanger.Update();
                if (puzzle1Complete)
                {
                    code = restoreCode();
                    GameObject.Find("ButtonTrigger").GetComponent<ButtonTrigger>().puzzleComplete = true;
                    audio.PlayOneShot(missionComplete);
                    puzzle1Complete = false;
                }
                resume();
            }

            // Button that closes the UI and disregards changes
            if (GUI.Button(new Rect(Screen.width * 0.7f, Screen.height * 0.9f, Screen.width * 0.08f, Screen.height * 0.05f), "Cancel"))
            {
                resume();
            }

            // Button that restores the code in the textArea to its original state
            if (GUI.Button(new Rect(Screen.width * 0.8f, Screen.height * 0.9f, Screen.width * 0.08f, Screen.height * 0.05f), "Reset"))
            {
                code = restoreCode();
                text = "";
                output = "";
                forStart = 0;
                forFinish = 0;
            }
        }
    }

    //Adds new Code to the TextArea based on the user input
    //*******************************************************
    public string addToCode(string s, TextEditor e, string added)
    {
        s = s.Insert(e.pos, added);
        return s;
    }

    public string restoreCode()
    {
        string dummy = "public class game{\n" +
                "\tpublic static void main(String[] args){\n" +
                "\t\t\n" +
                "\t}\n" +
                "}";
        return dummy;
    }

    public int countLinesBefore(string s, int position)
    {
        int lines = 0;
        char[] a = s.ToCharArray();
        for (int i = 0; i < position - 1; i++)
        {
            if (a[i] == '\n')
                lines++;
        }
        return lines;
    }

    public int countLinesAfter(string s, int position)
    {
        int lines = 0;
        char[] a = s.ToCharArray();
        for (int i = position; i < s.Length; i++)
        {
            if (a[i] == '\n')
                lines++;
        }
        return lines;
    }

    public bool isBlankLine(string s, int index)
    {
        char[] a = s.ToCharArray();
        if (((a[index - 1] == '\t') || (a[index - 1] == '\n')) && (a[index] == '\n'))
            return true;
        else
            return false;
    }

    public int getNumOfTabs(string s, int index)
    {
        if (index <= 1)
            return 0;
        int tabs = 0;
        char[] a = s.ToCharArray();
        while (a[index - 1] != '\n' && index > 1)
        {
            if (a[index - 1] == '\t')
                tabs++;
            index--;
        }
        return tabs;
    }

    public TextEditor moveNextLine(TextEditor te, string s)
    {
        char[] a = s.ToCharArray();
        while (a[te.pos] != '\n')
            te.MoveRight();
        return te;
    }

    public string addedTabs(int num)
    {
        string tabs = "";
        while (num > 0)
        {
            tabs = tabs.Insert(0, "\t");
            num--;
        }
        return tabs;
    }

    public TextEditor goToNextEmptyLine(TextEditor e, string s)
    {
        char[] a = s.ToCharArray();
        int i;
        if (editor.pos < 1)
            i = editor.pos;
        else
            i = editor.pos - 1;
        for (; i < s.Length; i++)
        {
            if ((a[i] == '\t') && (a[i + 1] == '\n'))
            {
                e.pos = i + 1;
                return e;
            }
        }
        return e;
    }

    public void resume()
    {
        Time.timeScale = 1.0f;
        guiEnabled = false;
        GameObject.Find("Main Camera").GetComponent<MouseLook>().enabled = true;
        GameObject.Find("First Person Controller").GetComponent<MouseLook>().enabled = true;
        GameObject.Find("Initialization").GetComponent<CursorTime>().showCursor = true;
    }

	IEnumerator jackin()
	{
		atWall = false;
		yield return new WaitForSeconds (1.3F);
		Time.timeScale = 0.0f;
		guiEnabled = true;
		GameObject.Find("Initialization").GetComponent<CursorTime>().showCursor = false;
		GameObject.Find("Main Camera").GetComponent<MouseLook>().enabled = false;
		GameObject.Find("First Person Controller").GetComponent<MouseLook>().enabled = false;
		atWall = true;
	}
}
