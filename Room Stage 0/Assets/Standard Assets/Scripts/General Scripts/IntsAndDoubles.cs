using UnityEngine;
using System.Collections;

public class IntsAndDoubles : MonoBehaviour
{
    double value = 0;
    int position = 0;
    public static bool puzzleComplete = false;
    bool guiEnabled = false;
    public static bool atWall6 = false;
    bool showError = false;
    bool converted = false;
    public bool reset = false;
    public Texture2D cursorImage;
    TextEditor editor;
    public static string text = "";
    static string var = "";
    public string code;
    string errorString = "";
    string cantType = "You can not add code here.";
    string badInput = "You can not assign a double value to an int";
    string oneShoot = "You can only launch one burger at a time.";
    string invalid = "invalid character.";
    static float power = 1;

    //Ray outwardRay;
    //RaycastHit hit;

    void OnTriggerEnter(Collider col2)
    {
        if (col2.gameObject.name == "Wall_Jack_S2")
        {
            atWall6 = true;
            GameObject.Find("Arm Camera").camera.enabled = false;
        }
    }

    void OnTriggerExit(Collider col2)
    {
        if (col2.gameObject.name == "Wall_Jack_S2")
        {
            atWall6 = false;
            guiEnabled = false;
            GameObject.Find("Arm Camera").camera.enabled = true;
        }
    }

    void Start()
    {
        if (converted)
        {
            power = GameObject.Find("turret").GetComponentInChildren<TurretShoot>().bulletImpulse / 25;
        }
        else
        {
            power = (int)(GameObject.Find("turret").GetComponentInChildren<TurretShoot>().bulletImpulse / 25);
        }

        code = "public class game{\n" +
            "\tpublic static void main(String[] args){\n" +
                "\t\tif(buttonClicked){\n" +
                "\t\t\tint power = " + power + ";\n" +
                "\t\t\tlaunchBurger(power);\n" +
                "\t\t}\n" +
                "\t}\n" +
                "}";

    }

    //Switches the GUI on and off
    //*******************************************************
    void Update()
    {
        if (Input.GetKeyDown("o"))
        {
            GameObject.Find("Enemy").GetComponent<Enemy>().enabled = true;
            GameObject.Find("Enemy").GetComponent<MeshRenderer>().enabled = true;
        }
        if (atWall6)
        {
            if (Input.GetKeyDown("e"))
            {
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


        // else if (!MakeOrder.atOrderWall && !atScanner) {

        //Screen.lockCursor = true;
        //Screen.lockCursor = false; //Cursor remains locked if not in terminal
        //	}
    }
    //*******************************************************


    //Includes all the GUI elements
    //*******************************************************
    public void OnGUI()
    {
        //	if (Input.GetMouseButtonDown (0) && editor.pos != 0) {
        //			position = editor.pos;
        //	}
        //if(!(Physics.Raycast(outwardRay, out hit,15f))){
        if (!atWall6)
        {  //If not at wall terminal jack in - "show crosshair"

        }
        else
            if (Input.GetKeyDown("e"))
            {
                GameObject.Find("Initialization").GetComponent<CursorTime>().showCursor = false;
                //If at wall terminal show default cursor instead
            }


        if (guiEnabled)
        {
            GUI.Box(new Rect(0, 0, Screen.width, Screen.height), "Ints and Doubles Puzzle");


            //GUI.Label(new Rect(500, 500, 200, 200), string.Format("Selected text: {0}\n",showError));

            if (showError)
            {
                GUI.Label(new Rect(Screen.width * 0.4f, Screen.height * 0.45f, Screen.width * 0.2f, Screen.height * 0.1f), errorString);
                if (GUI.Button(new Rect(Screen.width * 0.47f, Screen.height * 0.55f, Screen.width * 0.06f, Screen.height * 0.04f), "sorry"))
                {
                    showError = false;
                }
            }

            GUI.SetNextControlName("textarea");
            GUI.TextArea(new Rect(Screen.width * 0.2f, Screen.width * 0.04f, Screen.width * 0.75f, Screen.height * 0.75f), code);

            if (showError)
            {
                GUI.Label(new Rect(Screen.width * 0.4f, Screen.height * 0.45f, Screen.width * 0.2f, Screen.height * 0.1f), errorString);
                if (GUI.Button(new Rect(Screen.width * 0.47f, Screen.height * 0.55f, Screen.width * 0.06f, Screen.height * 0.04f), "sorry"))
                {
                    showError = false;
                }
            }
            editor = (TextEditor)GUIUtility.GetStateObject(typeof(TextEditor), GUIUtility.keyboardControl);
            editor.SelectNone();

            GUI.skin.label.fontSize = 12;


            //*******************************************************
            if (GUI.Button(new Rect(Screen.width * 0.02f, Screen.height * 0.18f, Screen.width * 0.1f, Screen.height * 0.05f), "Change int to double"))
            {
                //		GUI.FocusControl ("textarea");
                //		editor = goToNexpowertyLine(editor,code);				
                //		if ((countLinesBefore (code, editor.pos) >= 2) && (countLinesAfter (code, editor.pos) >= 2) && isBlankLine (code, editor.pos)) {
                //			int num = getNumOfTabs (code, editor.pos);
                code = "public class game{\n" +
                    "\tpublic static void main(String[] args){\n" +
                        "\t\tif(buttonClicked){\n" +
                        "\t\t\tdouble power = " + power + ";\n" +
                        "\t\t\tlaunchBurger(power);\n" +
                        "\t\t}\n" +
                        "\t}\n" +
                        "}";
                converted = true;
                showError = false;


            }



            GUI.Label(new Rect(Screen.width * 0.12f, Screen.height * 0.34f, Screen.width * 0.04f, Screen.height * 0.05f), ("value"));						//print statement title
            text = GUI.TextField(new Rect(Screen.width * 0.12f, Screen.height * 0.38f, Screen.width * 0.04f, Screen.height * 0.05f), text);

            if (GUI.Button(new Rect(Screen.width * 0.02f, Screen.height * 0.38f, Screen.width * 0.1f, Screen.height * 0.05f), "Assign power"))
            {
                GUI.FocusControl("textarea");
                editor = goToNexpowertyLine(editor, code);
                if (!isNumber(text))
                {
                    errorString = invalid;
                    showError = true;
                }
                else
                {
                    float.TryParse(text, out power);

                    if (text.Contains(".") && !converted)
                    {
                        errorString = badInput;
                        showError = true;
                    }
                    else if (converted)
                    {
                        code = "public class game{\n" +
                            "\tpublic static void main(String[] args){\n" +
                                "\t\tif(buttonClicked){\n" +
                                "\t\t\tdouble power = " + power + ";\n" +
                                "\t\t\tlaunchBurger(power);\n" +
                                "\t\t}\n" +
                                "\t}\n" +
                                "}";
                    }
                    else
                    {
                        code = "public class game{\n" +
                            "\tpublic static void main(String[] args){\n" +
                                "\t\tif(buttonClicked){\n" +
                                "\t\t\tint power = " + power + ";\n" +
                                "\t\t\tlaunchBurger(power);\n" +
                                "\t\t}\n" +
                                "\t}\n" +
                                "}";
                    }
                }

            }


            GUI.Label(new Rect(500, 500, 200, 200), string.Format("Selected text: {0}\nPos: {1}\nSelect pos: {2}\nLines Before: {3}\nLines After: {4}",
                                                                     position,
                                                                     editor.pos,
                                                                     0,
                                                                     countLinesBefore(code, editor.pos),
                                                                     countLinesAfter(code, editor.pos)));
            // Button that activates the user's code
            if (GUI.Button(new Rect(Screen.width * 0.6f, Screen.height * 0.9f, Screen.width * 0.08f, Screen.height * 0.05f), "Submit"))
            {
                //assign the actual turret power to whatever is in the text field
                GameObject.Find("turret").GetComponentInChildren<TurretShoot>().bulletImpulse = power * 25;

                resume();
            }

            // Button that closes the UI and disregards changes
            if (GUI.Button(new Rect(Screen.width * 0.7f, Screen.height * 0.9f, Screen.width * 0.08f, Screen.height * 0.05f), "Cancel"))
            {
                resume();
                code = restoreCode();
                converted = false;
                showError = false;
            }


            // Button that restores the code in the textArea to its original state
            if (GUI.Button(new Rect(Screen.width * 0.8f, Screen.height * 0.9f, Screen.width * 0.08f, Screen.height * 0.05f), "Reset") || reset)
            {
                code = restoreCode();
                converted = false;
                showError = false;
                GameObject.Find("turret").GetComponentInChildren<TurretShoot>().bulletImpulse = 50;
                power = 2;


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
                "\t\tif(buttonClicked){\n" +
                "\t\t\tint power = " + power + ";\n" +
                "\t\t\tlaunchBurger(power);\n" +
                "\t\t}\n" +
                "\t}\n" +
                "}";
        return dummy;
    }

    public int countLinesBefore(string s, int position)
    {
        int lines = 0;
        char[] a = s.ToCharArray();
        if (position == 0)
            position++;
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

    public TextEditor goToNexpowertyLine(TextEditor e, string s)
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
		GameObject.Find ("First Person Controller").GetComponent<Player> ().GuiEnabled = true;
        GameObject.Find("Initialization").GetComponent<CursorTime>().showCursor = true;
        GameObject.Find("Main Camera").GetComponent<MouseLook>().enabled = true;
        GameObject.Find("First Person Controller").GetComponent<MouseLook>().enabled = true;
    }

    public bool isNumber(string input)
    {
        bool b = true;
        char[] a = input.ToCharArray();
        for (int i = 0; i < input.Length; i++)
        {
            if (!(((a[i].CompareTo('0') > 0) && (a[i].CompareTo('9') < 0)) || ((a[i].CompareTo('.') == 0))))
            {
                b = false;
            }
        }
        return b;
    }

	IEnumerator jackin()
	{
		GameObject.Find("First Person Controller").GetComponent<Player>().GuiEnabled = false;
		atWall6 = false;
		yield return new WaitForSeconds (1.3F);
		Time.timeScale = 0.0f;
		guiEnabled = true;
		GameObject.Find("Initialization").GetComponent<CursorTime>().showCursor = false;
		GameObject.Find("Main Camera").GetComponent<MouseLook>().enabled = false;
		GameObject.Find("First Person Controller").GetComponent<MouseLook>().enabled = false;
		atWall6 = true;
	}

}

