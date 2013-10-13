using UnityEngine;
using System.Collections;

public class GameOver : MonoBehaviour {
	
	private static bool gameOver = false;
	
	void Start() {
		guiText.enabled = false;
		collider.enabled = false;
		renderer.enabled = false;
	}
	
	void Update() {
		if(Input.GetKey(KeyCode.G))
			GameIsOver();
	}	
	
	public void GameIsOver() {
		guiText.enabled = true;
		collider.enabled = true;		
		renderer.enabled = true;
		gameOver = true;
		
		Invoke("ShowHighScore", 2f);
	}
	
	public void ShowHighScore() {
		guiText.enabled = false;
		collider.enabled = false;	
		(FindObjectOfType(typeof(HighScore)) as HighScore).InsertNewHighScore(Score.score);
	}
	
	public static bool IsGameOver(){
		return gameOver;	
	}
}
