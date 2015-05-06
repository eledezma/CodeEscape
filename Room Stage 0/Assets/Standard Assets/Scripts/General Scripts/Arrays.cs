using UnityEngine;
using System.Collections;

public class Arrays : MonoBehaviour
{
    int value = 0;
    int position = 0;
	public int[] boxes = new int[5];
    public static bool puzzleComplete = false;
    bool guiEnabled = false;
    public static bool atWall6 = false;
    bool showError = false;
    bool converted = false;
    public bool reset = false;
    public Texture2D cursorImage;
    TextEditor editor;
    public static string ind = "";
    public static string val = "";
    static string var = "";
    public string code;
    string errorString = "";
    string cantType = "You can not add code here.";
    string outOfRange = "The index is outside the range of the array.";
    string oneShoot = "You can only launch one burger at a time.";
    string invalid = "invalid character.";
    int index = 1;

    //Ray outwardRay;
    //RaycastHit hit;

    void OnTriggerEnter(Collider col2)
    {
        if (col2.gameObject.name == "Wall_Jack_S6")
        {
            atWall6 = true;
            GameObject.Find("Arm Camera").camera.enabled = false;
        }
    }

    void OnTriggerExit(Collider col2)
    {
        if (col2.gameObject.name == "Wall_Jack_S6")
        {
            atWall6 = false;
            guiEnabled = false;
            GameObject.Find("Arm Camera").camera.enabled = true;
        }
    }

    void Start()
    {
		int i = 0;
		while(i<5)
		{
			boxes[i]=1;
			i++;
		}
        code = "public class game{\n" +
                "\tpublic static void main(String[] args){\n" +
                "\t\tint steps[] = new steps(5);\n" +
                "\t\tfor(int i=0;i<steps.Length;i++){\n" +
                "\t\t\tint steps[i] = 1;\n" +
                "\t\t}\n" +
                "\t\t\n" +
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
					StartCoroutine(jackin());
                }
            }
		}
    }
    //*******************************************************


    //Includes all the GUI elements
    //*******************************************************
    public void OnGUI()
    {
		if (atWall6 && Input.GetKeyDown("e"))
		{
			GameObject.Find("Initialization").GetComponent<CursorTime>().showCursor = false;
			//If at wall terminal show default cursor instead
		}


		/*
		if (!atWall6)
		{  //If not at wall terminal jack in - "show crosshair"

        } 
		else if (Input.GetKeyDown("e"))
        {
            GameObject.Find("Initialization").GetComponent<CursorTime>().showCursor = false;
            //If at wall terminal show default cursor instead
        }
		*/

        if (guiEnabled)
        {
            GUI.Box(new Rect(0, 0, Screen.width, Screen.height), "Arrays Puzzle");



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


            GUI.Label(new Rect(Screen.width * 0.12f, Screen.height * 0.34f, Screen.width * 0.04f, Screen.height * 0.05f), ("index"));                     //print statement title
            ind = GUI.TextField(new Rect(Screen.width * 0.12f, Screen.height * 0.38f, Screen.width * 0.04f, Screen.height * 0.05f), ind);
            GUI.Label(new Rect(Screen.width * 0.16f, Screen.height * 0.34f, Screen.width * 0.04f, Screen.height * 0.05f), ("value"));                     //print statement title
            val = GUI.TextField(new Rect(Screen.width * 0.16f, Screen.height * 0.38f, Screen.width * 0.04f, Screen.height * 0.05f), val);

            if (GUI.Button(new Rect(Screen.width * 0.02f, Screen.height * 0.38f, Screen.width * 0.1f, Screen.height * 0.05f), "Assign index"))
            {
                GUI.FocusControl("Textarea");
                
                if (!isNumber(ind))
                {
                    errorString = invalid;
                    showError = true;
                }
                else
                {
                    int.TryParse(ind, out index);
					int.TryParse(val, out value);

					if (index > 4 || index < 0)
                    {
                        errorString = outOfRange;
                        showError = true;
                    }
                    else
                    {
                        string s = "steps[" + index + "] = " + value + ";\n\t\t";
						boxes[index] = value;
						editor = goToNextLine(editor, code);
                        code = addToCode(code, editor, s);
                    }
                }

            }


            
            // Button that activates the user's code
            if (GUI.Button(new Rect(Screen.width * 0.6f, Screen.height * 0.9f, Screen.width * 0.08f, Screen.height * 0.05f), "Submit"))
            {
                //assign the actual turret index to whatever is in the ind field
				GameObject.Find("Initialization").GetComponent<CubeCreationStage8>().moveBlock1(boxes[0]);
				GameObject.Find("Initialization").GetComponent<CubeCreationStage8>().moveBlock2(boxes[1]);
				GameObject.Find("Initialization").GetComponent<CubeCreationStage8>().moveBlock3(boxes[2]);
				GameObject.Find("Initialization").GetComponent<CubeCreationStage8>().moveBlock4(boxes[3]);
				GameObject.Find("Initialization").GetComponent<CubeCreationStage8>().moveBlock5(boxes[4]);
				
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


            // Button that restores the code in the indArea to its original state
            if (GUI.Button(new Rect(Screen.width * 0.8f, Screen.height * 0.9f, Screen.width * 0.08f, Screen.height * 0.05f), "Reset") || reset)
            {
                code = restoreCode();
                converted = false;
                showError = false;
				int i = 0;
				while(i<5)
				{
					boxes[i]=1;
					i++;
				}
            }



        }

    }

    //Adds new Code to the indArea based on the user input
    //*******************************************************
    public string addToCode(string s, TextEditor e, string added)
    {
        s = s.Insert(e.pos, added);
        return s;
    }

    public string restoreCode()
    {
		string dummy = code = "public class game{\n" +
			"\tpublic static void main(String[] args){\n" +
				"\t\tint steps[] = new steps(5);\n" +
				"\t\tfor(int i=0;i<steps.Length;i++){\n" +
				"\t\t\tint steps[i] = 1;\n" +
				"\t\t}\n" +
				"\t\t\n" +
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

    public TextEditor goToNextLine(TextEditor e, string s)
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
        GameObject.Find("Initialization").GetComponent<CursorTime>().showCursor = true;
        GameObject.Find("Main Camera").GetComponent<MouseLook>().enabled = true;
        GameObject.Find("First Person Controller").GetComponent<MouseLook>().enabled = true;
		GameObject.Find ("First Person Controller").GetComponent<CharacterMotor> ().enabled = true;
    }

    public bool isNumber(string input)
    {
        bool b = true;
        char[] a = input.ToCharArray();
        for (int i = 0; i < input.Length; i++)
        {
            if (!(((a[i].CompareTo('0') >= 0) && (a[i].CompareTo('9') <= 0)) || ((a[i].CompareTo('.') == 0))))
            {
                b = false;
            }
        }
        return b;
    }

	IEnumerator jackin()
	{
		atWall6 = false;
		GameObject.Find("Main Camera").GetComponent<MouseLook>().enabled = false;
		GameObject.Find("First Person Controller").GetComponent<MouseLook>().enabled = false;
		GameObject.Find("First Person Controller").GetComponent<CharacterMotor>().enabled = false;
		yield return new WaitForSeconds (1.0F);
		Time.timeScale = 0.0f;
		guiEnabled = true;
		GameObject.Find("Initialization").GetComponent<CursorTime>().showCursor = false;
		atWall6 = true;
	}

}

