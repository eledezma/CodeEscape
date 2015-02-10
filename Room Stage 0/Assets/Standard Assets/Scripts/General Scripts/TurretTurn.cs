using UnityEngine;
using System.Collections;

public class TurretTurn : MonoBehaviour {

	public AnimationClip turn1;
	public AnimationClip turn2;
	public AnimationClip turn3;
	public AnimationClip reverseTurn;
	public bool reset;
	public bool turn;
	int pos;
	
	// Use this for initialization
	void Start () {
		pos = 0;
		reset = false;
		turn = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (!this.gameObject.animation.isPlaying) {
			if (reset) {
				Reset ();
				reset = false;
			}
			if (turn) {
				Turn ();
				turn = false;
			}
		}
	}
	
	void Reset(){


		switch (pos)
		{
		case 0:
			break;
		case 1:
			this.gameObject.animation.Play (reverseTurn.name);
			pos = 0;
			break;
		default:
			this.gameObject.animation.Play (turn3.name);
			pos = 0;
			break;
		}

	}

	void Turn(){

		
		switch (pos)
		{
		case 0:
			this.gameObject.animation.Play (turn1.name);
			pos = 1;
			break;
		case 1:
			this.gameObject.animation.Play (turn2.name);
			pos = 2;
			break;
		default:
			this.gameObject.animation.Play (turn3.name);
			pos = 0;
			break;
		}
		
	}

		
		
	
}
