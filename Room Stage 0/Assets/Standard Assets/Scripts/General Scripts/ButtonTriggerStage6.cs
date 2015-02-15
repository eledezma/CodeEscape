using UnityEngine;
using System.Collections;

public class ButtonTriggerStage6 : MonoBehaviour {

	public AudioClip ButtonClick;
	public GameObject button;
	public GameObject turret;
	public AnimationClip PushDown;
	public AnimationClip PushUp;
	public bool buttondown;
	public int turret_case;
	public int forStart;
	public int forFinish;
	public bool numIsConstant;
	public int numOfBullets;
	string objectName;
	bool less;
	
	// Use this for initialization
	void Start () 
	{
		buttondown = false;
		turret_case = 1;
		forStart = 0;
		forFinish = 0;
		numIsConstant = true;
		numOfBullets = 1;
		objectName = this.gameObject.name;
		less = false;
	}
	
	// Update is called once per frame
	void Update () 
	{
		/*if (Input.GetKeyDown ("9") && objectName != "ResetTrigger")
			StartCoroutine (test ());*/
	}

	IEnumerator test()
	{
			if (forStart > forFinish)
				less = true;
			else
				less = false;
			turret.GetComponent<TurretTurn>().turretActive = true;
			buttondown = true;
			if (button.animation.isPlaying)
				yield return new WaitForSeconds (0.5f);
			audio.PlayOneShot(ButtonClick);
			button.animation.Play (PushDown.name);
			if (objectName == "ResetTrigger")
				turret.GetComponent<TurretTurn>().reset = true;
			else
			{
				if (less)
				{
					for (int i = forStart; i >= forFinish; i--)
					{
						switch(turret_case)
						{
						case 1:
							if (numIsConstant)
							{
								StartCoroutine (turret.GetComponentInChildren<TurretShoot>().shoot(numOfBullets));
							    float wait = 0.5f * numOfBullets;
								yield return new WaitForSeconds(wait);
								StartCoroutine (turret.GetComponentInChildren<TurretShoot>().turn());
								yield return new WaitForSeconds (1f);
							}
							else
							{
								StartCoroutine (turret.GetComponentInChildren<TurretShoot>().shoot(i));
								float wait = 0.5f * i;
								yield return new WaitForSeconds(wait);
							    StartCoroutine (turret.GetComponentInChildren<TurretShoot>().turn());
								yield return new WaitForSeconds (1f);
							}
							break;
						case 2:
							if (numIsConstant)
							{
								StartCoroutine (turret.GetComponentInChildren<TurretShoot>().turn());
								yield return new WaitForSeconds (1f);
								StartCoroutine (turret.GetComponentInChildren<TurretShoot>().shoot(numOfBullets));
								float wait = 0.5f * numOfBullets;
								yield return new WaitForSeconds(wait);
							}
							else
							{
								StartCoroutine (turret.GetComponentInChildren<TurretShoot>().turn());
								yield return new WaitForSeconds (1f);
								StartCoroutine (turret.GetComponentInChildren<TurretShoot>().shoot(i));
								float wait = 0.5f * i;
								yield return new WaitForSeconds(wait);
							}
							break;
						case 3:
							if (numIsConstant)
							{
								StartCoroutine (turret.GetComponentInChildren<TurretShoot>().shoot(numOfBullets));
								float wait = 0.5f * numOfBullets;
								yield return new WaitForSeconds(wait);
							}
							else
							{
								StartCoroutine (turret.GetComponentInChildren<TurretShoot>().shoot(i));
								float wait = 0.5f * i;
								yield return new WaitForSeconds(wait);
							}
							break;
						case 4:
							StartCoroutine (turret.GetComponentInChildren<TurretShoot>().turn());
							yield return new WaitForSeconds (1f);
							break;
						default:
							break;
						}
					}
				}
				else
				{
					for (int i = forStart; i <= forFinish; i++)
					{
						switch(turret_case)
						{
						case 1:
							if (numIsConstant)
							{
								StartCoroutine (turret.GetComponentInChildren<TurretShoot>().shoot(numOfBullets));
								float wait = 0.5f * numOfBullets;
								yield return new WaitForSeconds(wait);
								StartCoroutine (turret.GetComponentInChildren<TurretShoot>().turn());
								yield return new WaitForSeconds (1f);
							}
							else
							{
								StartCoroutine (turret.GetComponentInChildren<TurretShoot>().shoot(i));
								float wait = 0.5f * i;
								yield return new WaitForSeconds(wait);
								StartCoroutine (turret.GetComponentInChildren<TurretShoot>().turn());
								yield return new WaitForSeconds (1f);
							}
							break;
						case 2:
							if (numIsConstant)
							{
								StartCoroutine (turret.GetComponentInChildren<TurretShoot>().turn());
								yield return new WaitForSeconds (1f);
								StartCoroutine (turret.GetComponentInChildren<TurretShoot>().shoot(numOfBullets));
								float wait = 0.5f * numOfBullets;
								yield return new WaitForSeconds(wait);
							}
							else
							{
								StartCoroutine (turret.GetComponentInChildren<TurretShoot>().turn());
								yield return new WaitForSeconds (1f);
								StartCoroutine (turret.GetComponentInChildren<TurretShoot>().shoot(i));
								float wait = 0.5f * i;
								yield return new WaitForSeconds(wait);
							}
							break;
						case 3:
							if (numIsConstant)
							{
								StartCoroutine (turret.GetComponentInChildren<TurretShoot>().shoot(numOfBullets));
								float wait = 0.5f * numOfBullets;
								yield return new WaitForSeconds(wait);
							}
							else
							{
								StartCoroutine (turret.GetComponentInChildren<TurretShoot>().shoot(i));
								float wait = 0.5f * i;
								yield return new WaitForSeconds(wait);
							}
							break;
						case 4:
							StartCoroutine (turret.GetComponentInChildren<TurretShoot>().turn());
							yield return new WaitForSeconds (1f);
							break;
						default:
							break;
						}
					}
				}
			}
			if (button.animation.isPlaying)
				yield return new WaitForSeconds (0.5f);
			button.animation.Play (PushUp.name);
			buttondown = false;
			yield return new WaitForSeconds (1f);
			turret.GetComponent<TurretTurn>().turretActive = false;
	}
	
	IEnumerator OnTriggerEnter (Collider other)
	{
		if (other.gameObject.tag == "Player" && !buttondown && !turret.GetComponent<TurretTurn>().turretActive)
		{
			if (forStart > forFinish)
				less = true;
			else
				less = false;
			turret.GetComponent<TurretTurn>().turretActive = true;
			buttondown = true;
			if (button.animation.isPlaying)
				yield return new WaitForSeconds (0.5f);
			audio.PlayOneShot(ButtonClick);
			button.animation.Play (PushDown.name);
			if (objectName == "ResetTrigger")
				turret.GetComponent<TurretTurn>().reset = true;
			else
			{
				if (less)
				{
					for (int i = forStart; i >= forFinish; i--)
					{
						switch(turret_case)
						{
						case 1:
							if (numIsConstant)
							{
								StartCoroutine (turret.GetComponentInChildren<TurretShoot>().shoot(numOfBullets));
								float wait = 0.5f * numOfBullets;
								yield return new WaitForSeconds(wait);
								StartCoroutine (turret.GetComponentInChildren<TurretShoot>().turn());
								yield return new WaitForSeconds (1f);
							}
							else
							{
								StartCoroutine (turret.GetComponentInChildren<TurretShoot>().shoot(i));
								float wait = 0.5f * i;
								yield return new WaitForSeconds(wait);
								StartCoroutine (turret.GetComponentInChildren<TurretShoot>().turn());
								yield return new WaitForSeconds (1f);
							}
							break;
						case 2:
							if (numIsConstant)
							{
								StartCoroutine (turret.GetComponentInChildren<TurretShoot>().turn());
								yield return new WaitForSeconds (1f);
								StartCoroutine (turret.GetComponentInChildren<TurretShoot>().shoot(numOfBullets));
								float wait = 0.5f * numOfBullets;
								yield return new WaitForSeconds(wait);
							}
							else
							{
								StartCoroutine (turret.GetComponentInChildren<TurretShoot>().turn());
								yield return new WaitForSeconds (1f);
								StartCoroutine (turret.GetComponentInChildren<TurretShoot>().shoot(i));
								float wait = 0.5f * i;
								yield return new WaitForSeconds(wait);
							}
							break;
						case 3:
							if (numIsConstant)
							{
								StartCoroutine (turret.GetComponentInChildren<TurretShoot>().shoot(numOfBullets));
								float wait = 0.5f * numOfBullets;
								yield return new WaitForSeconds(wait);
							}
							else
							{
								StartCoroutine (turret.GetComponentInChildren<TurretShoot>().shoot(i));
								float wait = 0.5f * i;
								yield return new WaitForSeconds(wait);
							}
							break;
						case 4:
							StartCoroutine (turret.GetComponentInChildren<TurretShoot>().turn());
							yield return new WaitForSeconds (1f);
							break;
						default:
							break;
						}
					}
				}
				else
				{
					for (int i = forStart; i <= forFinish; i++)
					{
						switch(turret_case)
						{
						case 1:
							if (numIsConstant)
							{
								StartCoroutine (turret.GetComponentInChildren<TurretShoot>().shoot(numOfBullets));
								float wait = 0.5f * numOfBullets;
								yield return new WaitForSeconds(wait);
								StartCoroutine (turret.GetComponentInChildren<TurretShoot>().turn());
								yield return new WaitForSeconds (1f);
							}
							else
							{
								StartCoroutine (turret.GetComponentInChildren<TurretShoot>().shoot(i));
								float wait = 0.5f * i;
								yield return new WaitForSeconds(wait);
								StartCoroutine (turret.GetComponentInChildren<TurretShoot>().turn());
								yield return new WaitForSeconds (1f);
							}
							break;
						case 2:
							if (numIsConstant)
							{
								StartCoroutine (turret.GetComponentInChildren<TurretShoot>().turn());
								yield return new WaitForSeconds (1f);
								StartCoroutine (turret.GetComponentInChildren<TurretShoot>().shoot(numOfBullets));
								float wait = 0.5f * numOfBullets;
								yield return new WaitForSeconds(wait);
							}
							else
							{
								StartCoroutine (turret.GetComponentInChildren<TurretShoot>().turn());
								yield return new WaitForSeconds (1f);
								StartCoroutine (turret.GetComponentInChildren<TurretShoot>().shoot(i));
								float wait = 0.5f * i;
								yield return new WaitForSeconds(wait);
							}
							break;
						case 3:
							if (numIsConstant)
							{
								StartCoroutine (turret.GetComponentInChildren<TurretShoot>().shoot(numOfBullets));
								float wait = 0.5f * numOfBullets;
								yield return new WaitForSeconds(wait);
							}
							else
							{
								StartCoroutine (turret.GetComponentInChildren<TurretShoot>().shoot(i));
								float wait = 0.5f * i;
								yield return new WaitForSeconds(wait);
							}
							break;
						case 4:
							StartCoroutine (turret.GetComponentInChildren<TurretShoot>().turn());
							yield return new WaitForSeconds (1f);
							break;
						default:
							break;
						}
					}
				}
			}
			if (button.animation.isPlaying)
				yield return new WaitForSeconds (0.5f);
			button.animation.Play (PushUp.name);
			buttondown = false;
			yield return new WaitForSeconds (1f);
			turret.GetComponent<TurretTurn>().turretActive = false;
		}
	}
	

	IEnumerator OnTriggerStay (Collider other)
	{
		if (other.gameObject.tag == "Player" && !buttondown && !turret.GetComponent<TurretTurn>().turretActive)
		{
			if (forStart > forFinish)
				less = true;
			else
				less = false;
			turret.GetComponent<TurretTurn>().turretActive = true;
			buttondown = true;
			if (button.animation.isPlaying)
				yield return new WaitForSeconds (0.5f);
			audio.PlayOneShot(ButtonClick);
			button.animation.Play (PushDown.name);
			if (objectName == "ResetTrigger")
				turret.GetComponent<TurretTurn>().reset = true;
			else
			{
				if (less)
				{
					for (int i = forStart; i >= forFinish; i--)
					{
						switch(turret_case)
						{
						case 1:
							if (numIsConstant)
							{
								StartCoroutine (turret.GetComponentInChildren<TurretShoot>().shoot(numOfBullets));
								float wait = 0.5f * numOfBullets;
								yield return new WaitForSeconds(wait);
								StartCoroutine (turret.GetComponentInChildren<TurretShoot>().turn());
								yield return new WaitForSeconds (1f);
							}
							else
							{
								StartCoroutine (turret.GetComponentInChildren<TurretShoot>().shoot(i));
								float wait = 0.5f * i;
								yield return new WaitForSeconds(wait);
								StartCoroutine (turret.GetComponentInChildren<TurretShoot>().turn());
								yield return new WaitForSeconds (1f);
							}
							break;
						case 2:
							if (numIsConstant)
							{
								StartCoroutine (turret.GetComponentInChildren<TurretShoot>().turn());
								yield return new WaitForSeconds (1f);
								StartCoroutine (turret.GetComponentInChildren<TurretShoot>().shoot(numOfBullets));
								float wait = 0.5f * numOfBullets;
								yield return new WaitForSeconds(wait);
							}
							else
							{
								StartCoroutine (turret.GetComponentInChildren<TurretShoot>().turn());
								yield return new WaitForSeconds (1f);
								StartCoroutine (turret.GetComponentInChildren<TurretShoot>().shoot(i));
								float wait = 0.5f * i;
								yield return new WaitForSeconds(wait);
							}
							break;
						case 3:
							if (numIsConstant)
							{
								StartCoroutine (turret.GetComponentInChildren<TurretShoot>().shoot(numOfBullets));
								float wait = 0.5f * numOfBullets;
								yield return new WaitForSeconds(wait);
							}
							else
							{
								StartCoroutine (turret.GetComponentInChildren<TurretShoot>().shoot(i));
								float wait = 0.5f * i;
								yield return new WaitForSeconds(wait);
							}
							break;
						case 4:
							StartCoroutine (turret.GetComponentInChildren<TurretShoot>().turn());
							yield return new WaitForSeconds (1f);
							break;
						default:
							break;
						}
					}
				}
				else
				{
					for (int i = forStart; i <= forFinish; i++)
					{
						switch(turret_case)
						{
						case 1:
							if (numIsConstant)
							{
								StartCoroutine (turret.GetComponentInChildren<TurretShoot>().shoot(numOfBullets));
								float wait = 0.5f * numOfBullets;
								yield return new WaitForSeconds(wait);
								StartCoroutine (turret.GetComponentInChildren<TurretShoot>().turn());
								yield return new WaitForSeconds (1f);
							}
							else
							{
								StartCoroutine (turret.GetComponentInChildren<TurretShoot>().shoot(i));
								float wait = 0.5f * i;
								yield return new WaitForSeconds(wait);
								StartCoroutine (turret.GetComponentInChildren<TurretShoot>().turn());
								yield return new WaitForSeconds (1f);
							}
							break;
						case 2:
							if (numIsConstant)
							{
								StartCoroutine (turret.GetComponentInChildren<TurretShoot>().turn());
								yield return new WaitForSeconds (1f);
								StartCoroutine (turret.GetComponentInChildren<TurretShoot>().shoot(numOfBullets));
								float wait = 0.5f * numOfBullets;
								yield return new WaitForSeconds(wait);
							}
							else
							{
								StartCoroutine (turret.GetComponentInChildren<TurretShoot>().turn());
								yield return new WaitForSeconds (1f);
								StartCoroutine (turret.GetComponentInChildren<TurretShoot>().shoot(i));
								float wait = 0.5f * i;
								yield return new WaitForSeconds(wait);
							}
							break;
						case 3:
							if (numIsConstant)
							{
								StartCoroutine (turret.GetComponentInChildren<TurretShoot>().shoot(numOfBullets));
								float wait = 0.5f * numOfBullets;
								yield return new WaitForSeconds(wait);
							}
							else
							{
								StartCoroutine (turret.GetComponentInChildren<TurretShoot>().shoot(i));
								float wait = 0.5f * i;
								yield return new WaitForSeconds(wait);
							}
							break;
						case 4:
							StartCoroutine (turret.GetComponentInChildren<TurretShoot>().turn());
							yield return new WaitForSeconds (1f);
							break;
						default:
							break;
						}
					}
				}
			}
			if (button.animation.isPlaying)
				yield return new WaitForSeconds (0.5f);
			button.animation.Play (PushUp.name);
			buttondown = false;
			yield return new WaitForSeconds (1f);
			turret.GetComponent<TurretTurn>().turretActive = false;
		}
	}
}
