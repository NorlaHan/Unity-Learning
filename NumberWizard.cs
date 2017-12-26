using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NumberWizard : MonoBehaviour {
	int max;
	int min;
	int guess;
	int Round = 1;
	int Cheat = 0;
	int Wins = 0;
	// Use this for initialization
	void Start () {
		Welcome ();
		StartGame ();
	}
	void Welcome (){
		print ("Welcome to Number Wizard!");
		print ("Choose a number in your mind");
		print ("But, DO NOT tell me :D");			
	}

	void StartGame () {
		InitializeVariable ();
		print ("The hightest number you can pick is " + max + ".");
		print ("The lowest number you can pick is " + min + ".");
		print ("================   Round " + Round + "   ================");
		GuessNumber();	
	}

	//Set all min max guss to starting point.
	void InitializeVariable () {
		min = 1;
		max = 1000;
		guess = 500;
	}

	//Do all the gussing
	void GuessNumber () {
		guess = (min + max) / 2;
		print ("Is it highter or lower tnan " + guess + " ?");
		print ("Press UP arrow for higher, DOWN arrow for lower,and RETURN for equal.");
		//print ("min : " + min + "Max : " + max);
	}

	//Check wheather the player is cheating. 
	void CheatDetect () {
		if (min > max) {
			RageQuit ();
		//} else if (min == max) {
			//RageQuit ();
		}
	}

	//If the cheating is comfirmed. Start over again.
	void RageQuit () {
		print ("Hey! You CHEAT!");
		print ("Let's play fair and square again ok?");
		print ("Here we go.");
		print ("========================================");
		InitializeVariable ();
		Round = (Round + 1);
		Cheat = (Cheat + 1);
		print ("You Cheat " + Cheat +" times :(");
		print ("================   Round " + Round + "   ================");
	}
	// Update is called once per frame
	void Update ()
	{
		if (Input.GetKeyDown (KeyCode.UpArrow)) {
			min = guess + 1;
			CheatDetect ();
			GuessNumber ();
		} else if (Input.GetKeyDown (KeyCode.DownArrow)) {
			max = guess - 1;
			CheatDetect ();
			GuessNumber ();
		} else if (Input.GetKeyDown (KeyCode.Return)) {
			print ("Yeah, I Won. let's start another round!");
			print ("========================================");
			Round = (Round + 1);
			Wins = (Wins + 1);
			print ("I won " + Wins + " times.");
			StartGame ();
		}
	}
}
