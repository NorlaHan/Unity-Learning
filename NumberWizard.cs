using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NumberWizard : MonoBehaviour {
	int max;
	int min;
	int guess;
	int round = 1;
	int cheat = 0;
	int losses = 0;
	int wins = 0;
	int NowGuess;
	int randomness;

	public int MaxGuessesAllowed = 10;
	public int MaxLossess = 10;
	public Text text;
	public Text contex;
	public Text title;

	// Use this for initialization
	void Start () {
//		Welcome ();
		StartGame ();
	}
	void Welcome (){
//		print ("Welcome to Number Wizard!");
//		print ("Choose a number in your mind");
//		print ("But, DO NOT tell me :D");			
	}

	void StartGame () {
		InitializeVariable ();
//		print ("The hightest number you can pick is " + max + ".");
//		print ("The lowest number you can pick is " + min + ".");
//		print ("================   Round " + Round + "   ================");
		GuessNumber();	
	}

	//Set all min max guss to starting point.
	void InitializeVariable () {
		min = 1;
		max = 1000;
		guess = 500;
		NowGuess = 0;
	}

	//Do all the gussing
	void GameResult(){
		if (NowGuess >= MaxGuessesAllowed) {
			Application.LoadLevel ("Win");
			wins =(wins + 1);
			round = (round + 1);
		} else if (losses >= MaxLossess) {
			Application.LoadLevel ("Lose");
		}
	}


	void GuessNumber ()
	{
		// When NW guesses too much player wins
		GameResult();

		guess = Random.Range(min , max+1);
		//		print ("Is it highter or lower tnan " + guess + " ?");
		//		print ("Press UP arrow for higher, DOWN arrow for lower,and RETURN for equal.");
		//print ("min : " + min + "Max : " + max);
		NowGuess = (NowGuess + 1);
		if (losses == 0) {
			title.text = ("Round" + round + "\n\n" + "Number Wizard has a grim smile on his face." );
		} else if (losses >= 1) {
			title.text = (	"Round" + round + "\n\n" + "Number Wizard Laughs at you.\n" + 
							" I win " + losses + " times, after " + (MaxLossess - losses) + " rounds and your soul is mine.");
		}
		contex.text = (	"This is my " + NowGuess + " guesses. I think the number is ");
		
		text.text = guess.ToString() ;
	}

	//Check wheather the player is cheating. 
	void CheatDetect () {
		if (min > max) {
			RageQuit ();
		//} else if (min == max) {
			//RageQuit ();
		}
	}

	//If the cheating is comfirmed. Game over.
	void RageQuit () {
		//		print ("Hey! You CHEAT!");
		//		print ("Let's play fair and square again ok?");
		//		print ("Here we go.");
		//		print ("========================================");
		InitializeVariable ();
		round = (round + 1);
		cheat = (cheat + 1);
		Application.LoadLevel ("Cheat");
		//		print ("You Cheat " + Cheat +" times :(");
		//		print ("================   Round " + Round + "   ================");
	}
	// Update is called once per frame
	void Update ()
	{
//		if (Input.GetKeyDown (KeyCode.UpArrow)) {
//			min = guess + 1;
//			CheatDetect ();
//			GuessNumber ();
//		} else if (Input.GetKeyDown (KeyCode.DownArrow)) {
//			max = guess - 1;
//			CheatDetect ();
//			GuessNumber ();
//		} else if (Input.GetKeyDown (KeyCode.Return)) {
//			print ("Yeah, I Won. let's start another round!");
//			print ("========================================");
//			round = (round + 1);
//			Wins = (Wins + 1);
//			print ("I won " + Wins + " times.");
//			StartGame ();
//		}
	}

	public void GuessHigher(){
		min = guess + 1;
		CheatDetect ();
		GuessNumber ();
	}

	public void GuessLower(){
		max = guess - 1;
		CheatDetect ();
		GuessNumber ();
	}
	// when player admit NW gets the number, player lose.
	public void GuessEqual ()
	{
//		print ("Yeah, I Won. let's start another round!");
//		print ("========================================");
//		Wins = (Wins + 1);
//		print ("I won " + Wins + " times.");
//		StartGame ();
		round = (round + 1);
		losses = (losses + 1);
		if (losses >= MaxLossess) {
			Application.LoadLevel ("Lose");
		} else if (losses < MaxLossess) {
			InitializeVariable();
			GuessNumber();
		}
	}
}
