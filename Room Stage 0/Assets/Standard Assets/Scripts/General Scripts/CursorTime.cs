using UnityEngine;
using System.Collections;

public class CursorTime : MonoBehaviour
{

    public bool showCursor;
    public Texture2D cursorImage;
    //public bool mouseTime;
    // Use this for initialization
    void Start()
    {
        showCursor = true;
        //mouseTime = true;
    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnGUI()
    {
        if (showCursor)
        {
            Vector3 mPos = Input.mousePosition;
            GUI.DrawTexture(new Rect(mPos.x - 32, Screen.height - mPos.y - 32, 64, 64), cursorImage);
            Screen.lockCursor = true;
            Screen.lockCursor = false;
            Screen.showCursor = false;

        }
        else
        {
            Screen.showCursor = true;

        }

    }

}
