using UnityEngine;
using System.Collections;

public class Questions : MonoBehaviour {
	public bool answered;
	GameObject[] NumQuestions;
	GameObject[] NumQuesTrig;
	public int questionNumber;
	public int correctNum;
	bool guiEnabled = false;
	public bool atWall = false;
	public AudioClip missionComplete;
	TextEditor editor;
	public Texture2D cursorImage;
	string code;

	bool added = false;
	bool deleted = false;
	string output = "Door is open";
	
	public static string question1 = "Which of these is a method that can be used to print somtething on the screen?";
	static string[] answer1 = {"System.out.display()","System.out.print()","System.out.write()","System.displaySomethingPlease()"};
	public static string question2 = "What's the output of the following code?\n"+
		"\n"+
			"System.out.println(\"A\");\n"+
			"System.out.print(\"B\");\n"+
			"System.out.print(\"C\");\n";
	static string[] answer2 = {"ABC","A\nB\nC","A\nBC","AB\nC"};
	public static string question3 = "What class can be used to get input from the user?";
	static string[]  answer3 = {"Scanner","Input","Console","Text"};
	public static string question4 = "Which of the follwing is a double?";
	static string[]  answer4 = {"III","3","three","3.0"};
	public static string question5 = "If boolean1 was false and boolean2 was true, which of the the print out statements gets executed?"+
		"\n"+
			"if(boolean1){\n"+
			"\tif(boolean2){\n"+
			"\t\tSystem.out.print(\"A\");\n"+
			"\t}\n"+
			"\telse{\n"+
			"\t\tSystem.out.print(\"B\")\n"+
			"\t}\n"+
			"}\n"+
			"else{\n"+
			"\tif(!boolean2){\n"+
			"\t\tSystem.out.print(\"C\")\n"+
			"\t}\n"+
			"}\n";
	static string[] answer5 = {"A","B","C","None of the above"};
	public static  string question6 = "What's the output of the following code?\n"+
		"\n"+
			"for(int i=0;i<7;i++){\n"+
			"\tSystem.out.print(\"A\");\n"+
			"}\n";
	static string[] answer6 = {"AAAAA","AAAAAA","AAAAAAA","AAAAAAAA"};
	public static string question7 = "What are all the possible values that the random method (int)(Math.random()*3)+2 generates?\n";
	static string[]answer7 = {"1,2,3","2,3,4","2,3,4,5","3,4,5"};
	public static string question8 = "What's the output of the following code:\n"+
		"\n"+
			"int numbers[] = {3,5,7,9};\n"+
			"System.out.print(numbers[1]+numbers[2]);";

	static string[] answer8 = {"8","35","12","57"};
	public static string question9 = "Which of these is used to access a private variable from another class?";
	static string[] answer9 = {"Another variable","Set method","Key","Get method"};
	public static string question10 = "What programming language was introduced in the game?";
	static string[] answer10 = {"C++","Java","Python","Prolog"};

	static string[][] answers = {answer1,answer2,answer3,answer4,answer5,answer6,answer7,answer8,answer9,answer10};
	static string[] questions = {question1,question2,question3,question4,question5,question6,question7,question8,question9,question10};

	static int[] correctAnswers = {2,3,1,4,4,3,2,3,4,2};
	static int userAnswer = 0;








	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "QuestionTrig")
		{
			GameObject.Find("Arm Camera").camera.enabled = false;
		//Arms.camera.enabled = false;
		}
	}
	
	void OnTriggerExit(Collider other)
	{
		if (other.gameObject.tag == "QuestionTrig")
		{
		//Arms.camera.enabled = true;
		GameObject.Find("Arm Camera").camera.enabled = true;
		}
	}

	void Start()
	{
		answered = false;
		questionNumber = 1;
		correctNum = 0;
		Screen.lockCursor = true;
		//Screen.showCursor = false;
	}
	//Switches the GUI on and off
	//*******************************************************
	void Update()
	{
		if (atWall)
		{
		/*
		if (Input.GetKeyDown("k"))
		{
			questionNumber++;
		}*/
			if (Input.GetKeyDown("e"))
			{
				//			Screen.lockCursor = false;  //Cursor is free to move when user goes into terminal
				/*if (guiEnabled)
				{
					resume();
				}
				else*/
				if (!guiEnabled)
				{
					StartCoroutine (jackin ());
				}
			}
		}

	}
	//*******************************************************
	
	
	//Includes all the GUI elements
	//*******************************************************
	public void OnGUI()
	{
		if(!answered){
		if (!atWall)
		{  //If not at wall terminal jack in - "show crosshair"
			//Vector3 mPos = Input.mousePosition;
			//GUI.DrawTexture (new Rect (mPos.x - 32, Screen.height - mPos.y - 32, 64, 64), cursorImage);
		}
		else if (atWall && Input.GetKeyDown("l"))
		{
			//GameObject.Find("Initialization").GetComponent<CursorTime>().showCursor = false;
			//If at wall terminal show default cursor instead
		}
		
		if (guiEnabled)
		{
			GUI.Box(new Rect(0, 0, Screen.width, Screen.height), "QUIZ");
			
			GUI.SetNextControlName("textarea");
			GUI.Label(new Rect(Screen.width*0.1f,Screen.height*0.1f,Screen.width*0.8f,Screen.height*0.5f),questions[questionNumber-1]);
			
				
			if (GUI.Button(new Rect(Screen.width * 0.20f, Screen.height * 0.6f, Screen.width * 0.25f, Screen.height * 0.2f), answers[questionNumber-1][0]))
			{
					//tariq here the user picked first choice
					userAnswer = 1;
					answered =true;
					resume ();
				
			}
			
			if (GUI.Button(new Rect(Screen.width * 0.55f, Screen.height * 0.6f, Screen.width * 0.25f, Screen.height * 0.2f), answers[questionNumber-1][1]))
			{
					userAnswer=2;
					answered = true;
					resume ();
			}

			if (GUI.Button(new Rect(Screen.width * 0.20f, Screen.height * 0.8f, Screen.width * 0.25f, Screen.height * 0.2f), answers[questionNumber-1][2]))
				{
					userAnswer=3;
					answered = true;
					resume ();
				}
				
			if (GUI.Button(new Rect(Screen.width * 0.55f, Screen.height * 0.8f, Screen.width * 0.25f, Screen.height * 0.2f), answers[questionNumber-1][3]))
				{
					userAnswer =4;
					answered = true;
					resume ();
				}
					
			}
		}
		else  // the user has answered
		{  


			string num = questionNumber.ToString();
			string tomb = "tombstone" + num;
			tomb = tomb + "/Wall Panel";
			string panel = "Platform" + num;
			string panelTrig = panel + "/Trigger";
			GameObject.Find (panelTrig).GetComponent<Level10FloorPanel>().isActive = false;
			GameObject.Find (tomb).GetComponent<QuestionStart>().isActive = false;
			atWall = false;
			if(userAnswer == correctAnswers[questionNumber-1])
			{
				//tariq the user answered correctly here
				correctNum++;
				GameObject.Find(panel).GetComponent<Level10Floor>().answer (true);
				if (correctNum == 7)
				{
					Destroy(GameObject.Find("MainFloor/FloorTrigger"));
					NumQuestions = GameObject.FindGameObjectsWithTag("Question");
					for (int i = 0; i < NumQuestions.Length; i++)
					{
						NumQuestions[i].GetComponent<Level10FloorPanel>().isActive = false;
					}
					GameObject.Find("SphereKill").GetComponent<MoveToRight>().complete ();
					NumQuesTrig = GameObject.FindGameObjectsWithTag ("QuestionTrig");
					for (int i = 0; i < NumQuesTrig.Length; i++)
					{
						NumQuesTrig[i].GetComponent<QuestionStart>().isActive = false;
					}
				}
				else
				{
					GameObject.Find("First Person Controller").GetComponent<GreenAndBlue4Eva>().greenTime = true;
				}
			}
			else
			{
				//tariq the user messed up
				GameObject.Find(panel).GetComponent<Level10Floor>().answer (false);
			
			}
			answered = false;
		}
	}
	
	//Adds new Code to the TextArea based on the user input
	//*******************************************************
	public string addToCode(string s, TextEditor e, string newString)
	{
		char[] a = s.ToCharArray();
		if (e.pos == 0)
		{
			s = s.Insert(e.pos, newString);
			added = true;
		}
		else if ((a[e.pos - 1] == '\n') || (a[e.pos - 1] == '\t'))
		{
			s = s.Insert(e.pos, newString);
			added = true;
		}
		else
			added = false;
		return s;
	}
	
	public string deleteFromCode(string s, TextEditor e)
	{
		char[] a = s.ToCharArray();
		if (a[e.pos] == '\t')
		{
			s = s.Remove(e.pos, 1);
			deleted = true;
		}
		else if ((e.pos != 0) && (a[e.pos - 1] == '\t'))
		{
			s = s.Remove(e.pos - 1, 1);
			deleted = true;
		}
		else
		{
			deleted = false;
		}
		return s;
	}

	// tariq call this whenever you open up a new question
	public void reset(){
		//userAnswer = 0;
		//answered = false;
	}

	public string restoreCode()
	{
		string dummy = "public static game{\n" +
			"public static void main(Sring[] args){\n" +
				"if (Door.open == false)\n" +
				"Door.open = true;\n" +
				"System.out.println(\"Door is open\");\n" +
				"}\n" +
				"}";
		return dummy;
	}
	
	public int countLinesBefore(string s, int position)
	{
		int lines = 0;
		char[] a = s.ToCharArray();
		for (int i = 0; i < position; i++)
		{
			if (i != a.Length)
			{
				if (a[i] == '\n')
					lines++;
			}
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
		GameObject.Find ("First Person Controller").GetComponent<Level10Health> ().guiEnabled = true;
		GameObject.Find("Initialization").GetComponent<CursorTime>().showCursor = true;
		GameObject.Find("Main Camera").GetComponent<MouseLook>().enabled = true;
		GameObject.Find("First Person Controller").GetComponent<MouseLook>().enabled = true;
		GameObject.Find ("First Person Controller").GetComponent<CharacterMotor> ().enabled = true;
	}

	IEnumerator jackin()
	{
		atWall = false;
		GameObject.Find("Main Camera").GetComponent<MouseLook>().enabled = false;
		GameObject.Find("First Person Controller").GetComponent<MouseLook>().enabled = false;
		GameObject.Find("First Person Controller").GetComponent<CharacterMotor>().enabled = false;
		GameObject.Find("First Person Controller").GetComponent<Level10Health>().guiEnabled = false;
		yield return new WaitForSeconds (1.3F);
		Time.timeScale = 0.0f;
		guiEnabled = true;
		GameObject.Find("Initialization").GetComponent<CursorTime>().showCursor = false; 
		Screen.lockCursor = false;
		atWall = true;
	}

}
