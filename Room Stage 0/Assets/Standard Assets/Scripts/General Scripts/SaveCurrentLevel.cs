using UnityEngine;
using System.Collections;

public class SaveCurrentLevel : MonoBehaviour {

	// Use this for initialization
	void Start () {
		string line = "LoadedLevel:" + Application.loadedLevel;
		System.IO.File.WriteAllText (Application.dataPath + "/Resources/currentlevel.sav", line);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
