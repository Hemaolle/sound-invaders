using UnityEngine;
using System.Collections;

public class Score : MonoBehaviour {
	
	public static int score;
	public static int limit1 = 10;
	public static int limit2 = 20;
	public static int limit3 = 30;
	public static int limit4 = 40;
	
	public GUIText scoreText;
	public GUIText multiplierText;
	
	private static int _streak = 0;
	private static int _multiplier = 1;
	private static GUIText staticScoreText;
	private static GUIText staticMultiplierText;
	// Use this for initialization
	void Start () {
		staticScoreText = GameObject.Find("Score").GetComponent<GUIText>();
		staticMultiplierText = GameObject.Find("Multiplier").GetComponent<GUIText>();
	}
	
	// Update is called once per frame
	void Update () {
	}
	
	public static void IncreaseScore(int amount) {
		score += amount;
		staticScoreText.text = "SCORE  " + score;
	}
	
	public static void SetMultiplier(int newMultiplier) {
		_multiplier = newMultiplier;
		staticMultiplierText.text = "MULTIPLIER " + _multiplier + "X";
	}
	
	public static void Hit(){
		_streak++;
		if(_streak > limit1)
			SetMultiplier(2);
		if(_streak > limit2)
			SetMultiplier(3);
		if(_streak > limit3)
			SetMultiplier(4);
		if(_streak > limit4)
			SetMultiplier(5);
		IncreaseScore(10 * _multiplier);
	}
	
	public static void Miss(){
		if(_multiplier == 1)
			GameOver();
		_streak = 0;
		SetMultiplier(1);
	}
	
	public static void GameOver(){
		(FindObjectOfType(typeof(GameOver)) as GameOver).GameIsOver();
	}
}
