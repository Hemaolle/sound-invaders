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
	
	private static int _killCount = 0;
	private static int _spawnSpeedCounter = 0;
	private static int _dragCounter = 10;
	
	private static EnemySpawner _spawner;

	// Use this for initialization
	void Start () {
		staticScoreText = GameObject.Find("Score").GetComponent<GUIText>();
		staticMultiplierText = GameObject.Find("Multiplier").GetComponent<GUIText>();
		_spawner = GameObject.Find("EnemySpawner").GetComponent<EnemySpawner>();
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
		_killCount++;
		_spawnSpeedCounter++;
		_dragCounter++;
		
		if(_spawnSpeedCounter>20){
			_spawnSpeedCounter = 0;
			_spawner.increaseSpawnRate();
		}
		
		if(_dragCounter>20){
			_dragCounter = 0;
			_spawner.decreaseDrag();
		}
		
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
		_streak = 0;
		SetMultiplier(1);
	}
	
	public static void GameOver(){
		print ("Game over: Final Score " + score);
	}
}
