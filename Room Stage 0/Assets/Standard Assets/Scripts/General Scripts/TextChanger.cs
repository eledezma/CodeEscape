using UnityEngine;
using System.Collections;

public class TextChanger : MonoBehaviour
{

    static string inputmessage1 = "";

    static private TextMesh tm;

    void Start()
    {

        tm = GetComponent<TextMesh>();
        if (tm == null)
            Debug.Log("No 3D Text component found");
    }

    public static void Update()
    {

        print(inputmessage1);
        tm.text = codingUI.output;

    }
}