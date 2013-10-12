using UnityEngine;
using System.Collections;

public class Score : MonoBehaviour {
	
	public static int score;
	public static int limit1 = 10;
	public static int limit2 = 20;
	public static int limit3 = 30;
	public static int limit4 = 40;
	
	private static int _streak = 0;
	private static int _multiplier = 1;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		guiText.text = "SCORE  " + score;
	}
	
	public static void IncreaseScore(int amount) {
		score += amount;	
	}
	
	public static void Hit(){
		_streak++;
		if(_streak > limit1)
			_multiplier = 2;
		if(_streak > limit2)
			_multiplier = 3;
		if(_streak > limit3)
			_multiplier = 4;
		if(_streak > limit4)
			_multiplier = 5;
		score += 10 * _multiplier;
	}
	
	public static void Miss(){
		if(_multiplier == 1)
			GameOver();
		_multiplier = 1;
	}
	
	public static void GameOver(){
		print ("Game over: Final Score " + score);
	}
}
