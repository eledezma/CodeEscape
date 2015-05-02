using UnityEngine;
using System.Collections;

public class ReturnToLevel : MonoBehaviour
{

    public int level;

    // Use this for initialization
    void Start()
    {
        System.IO.StreamReader file = new System.IO.StreamReader(Application.dataPath + "/Resources/currentlevel.sav");
        string text = file.ReadLine(); //this is the content as string
        char[] delimiter = { ':' };
        string[] textArr = text.Split(delimiter);
        level = int.Parse(textArr[1]);
		Application.LoadLevel (level);


		if (!System.IO.File.Exists (Application.dataPath + "/Resources/currentlevel.sav")) 
		{
			string line = "LoadedLevel:1";
			System.IO.File.WriteAllText(Application.dataPath + "/Resources/currentlevel.sav", line);
		}

        //Debug.Log (x);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
