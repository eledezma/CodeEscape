using UnityEngine;
using System.Collections;

public class DiceRotateLoaded : MonoBehaviour
{

    public bool rot;
    public bool delay;
    public bool loaded;
    public GameObject dice;
    public bool diceComplete;
    // Use this for initialization

    void Start()
    {
        diceComplete = false;
    }

    void Update()
    {
        if (rot)
        {
            RandomTime();
        }

        if (delay)
        {
            StartCoroutine(DelayTime());
            delay = false;
        }

    }

    void RandomTime()
    {
        int sw = Random.Range(1, 5);
        switch (sw)
        {
            case 1:
                transform.Rotate(new Vector3(90, 0, 0));
                break;
            case 2:
                transform.Rotate(new Vector3(-90, 0, 0));
                break;
            case 3:
                transform.Rotate(new Vector3(0, 90, 0));
                break;
            case 4:
                transform.Rotate(new Vector3(0, -90, 0));
                break;
        }


    }

    IEnumerator DelayTime()
    {
        yield return new WaitForSeconds(5f);
        rot = false;
        if (loaded)
		{
			yield return new WaitForSeconds(1f);
			Debug.Log(dice.GetComponent<Die_d6>().value);
			while (dice.GetComponent<Die_d6>().value != 6)
			{
				int sw = Random.Range(1, 5);
				switch (sw)
				{
				case 1:
					transform.Rotate(new Vector3(90, 0, 0));
					break;
				case 2:
					transform.Rotate(new Vector3(-90, 0, 0));
					break;
				case 3:
					transform.Rotate(new Vector3(0, 90, 0));
					break;
				case 4:
					transform.Rotate(new Vector3(0, -90, 0));
					break;
				}
				
				yield return new WaitForSeconds(0.5f);
				Debug.Log(dice.GetComponent<Die_d6>().value);
				
			}
			diceComplete = true;

		}
            //StartCoroutine(Get6());
        else if (!loaded)
            diceComplete = true;
    }

	/*
    IEnumerator Get6()
    {
        while (dice.GetComponent<Die_d6>().value != 6)
        {
            int sw = Random.Range(1, 5);
            switch (sw)
            {
                case 1:
                    transform.Rotate(new Vector3(90, 0, 0));
                    break;
                case 2:
                    transform.Rotate(new Vector3(-90, 0, 0));
                    break;
                case 3:
                    transform.Rotate(new Vector3(0, 90, 0));
                    break;
                case 4:
                    transform.Rotate(new Vector3(0, -90, 0));
                    break;
            }

            yield return new WaitForSeconds(0.5f);
            Debug.Log("Wait for 0.5 seconds");

        }
        diceComplete = true;
    }
    */
}