using UnityEngine;
using System.Collections;

public class HighScore : MonoBehaviour {
	
	public Texture okTexture;
	public GameObject backToMenu;
	public TextMesh title;
	
	public string[] names;
	public int[] scores;
	
	public GUIText[] nameTexts;
	public GUIText[] scoreTexts;
	public GUIText[] numberTexts;
	
	private string nameString = "Level{0}Name{1}";
	private string scoreString = "Level{0}Score{1}";
	private string playerName = "Nam";
	private int scoreIndex;
	private bool newHighScore = false;
	private bool visible = false;
	
	public void loadScores(int level) {
		names = new string[10];
		scores = new int[10];
		for(int i = 0; i < 10; i++) {
			if(PlayerPrefs.HasKey(string.Format (nameString, level, i))) {
				names[i] = PlayerPrefs.GetString(string.Format (nameString, level, i));
				scores[i] = PlayerPrefs.GetInt(string.Format (scoreString, level, i));
			}
			else {
				names[i] = "";
				scores[i] = 0;
			}
		}			
	}
	
	public void saveScores(int level) {
		for(int i = 0; i < 10; i++) {
			PlayerPrefs.SetString(string.Format (nameString, level, i), names[i]);
			//Debug.Log ("Saved " + names[i] + " on key " + string.Format (nameString, level, i));
			PlayerPrefs.SetInt(string.Format (scoreString, level, i), scores[i]);
			Debug.Log ("Saved " + scores[i] + " on key " + string.Format (scoreString, level, i));
		}			
	}
	
	public void populateNameAndScoreTexts() {
		for(int i = 0; i < 10; i++) {
			nameTexts[i].text = names[i];
			scoreTexts[i].text = "" + scores[i];	
		}
	}
	
	public int insertScore(int score, out bool changed) {
		changed = false;
		int i;
		
		for(i = 0; i < 10; i++) {
			if(scores[i] < score) {
				MoveScoresForward(i);
				MoveNamesForward(i);
				changed = true;
				break;
			}			
		}
		
		if(changed) {		
			scores[i] = score;
			names[i] = "";
		}
		return i;
	}
	
	
	
	public void setName(string name, int index) {
		names[index] = name;	
	}
	
	private void MoveScoresForward(int index) {
		for(int i = 8; i > index - 1; i--)
			scores[i + 1] = scores[i];
	}
	
	private void MoveNamesForward(int index) {
		for(int i = 8; i > index - 1; i--)
			names[i + 1] = names[i];
	}
	
	// Use this for initialization
	void Awake () {
		foreach(GUIText text in nameTexts)
			text.enabled = false;
		foreach(GUIText text in scoreTexts)
			text.enabled = false;
		foreach(GUIText text in numberTexts)
			text.enabled = false;
		backToMenu.renderer.enabled = false;
		backToMenu.collider.enabled = false;
		if (title != null)
			title.renderer.enabled = false;
		/*loadScores(1);
		populateNameAndScoreTexts();
		bool changed;
		scoreIndex = insertScore(Random.Range(10, 5000), out changed);
		populateNameAndScoreTexts();*/
	}
	
	public void InsertNewHighScore(int score) {
		foreach(GUIText text in nameTexts)
			text.enabled = true;
		foreach(GUIText text in scoreTexts)
			text.enabled = true;
		foreach(GUIText text in numberTexts)
			text.enabled = true;
		loadScores(Application.loadedLevel);
		scoreIndex = insertScore(score, out newHighScore);
		populateNameAndScoreTexts();
		visible = true;
		backToMenu.renderer.enabled = true;
		backToMenu.collider.enabled = true;
		title.renderer.enabled = true;
		title.text = "LEVEL " + Application.loadedLevelName + " HIGH SCORES";
	}
	
	public void DisplayHighScores(int level) {
		foreach(GUIText text in nameTexts)
			text.enabled = true;
		foreach(GUIText text in scoreTexts)
			text.enabled = true;
		foreach(GUIText text in numberTexts)
			text.enabled = true;
		loadScores(level);
		populateNameAndScoreTexts();
		visible = true;
		backToMenu.renderer.enabled = true;
		backToMenu.collider.enabled = true;
	}
	
	void OnGUI() {
		//string textAreaString = GUI.TextArea (new Rect (Screen.width / 2.0f - Screen.width * 0.1f ,Screen.height / 2.0f - Screen.height * 0.3f, 100f, 30f), "Name");
		 //playerName = GUI.TextField(new Rect(Screen.width / 2.0f - Screen.width * 0.1f ,Screen.height / 2.0f - Screen.height * 0.3f, 100f, 30f), playerName, 3);
		if (visible && newHighScore) {
			playerName = GUI.TextField(new Rect(Screen.width/2f - Screen.width * 0.2f, Screen.height/2f + Screen.height * 0.3f, Screen.width * 0.2f, Screen.height * 0.05f), playerName, 3);
			
		  	if (GUI.Button(new Rect(Screen.width/2f + Screen.width * 0.15f, Screen.height/2f + Screen.height * 0.3f, Screen.width * 0.1f, Screen.height * 0.05f), okTexture)) {
				setName(playerName, scoreIndex);
				populateNameAndScoreTexts();
				saveScores(Application.loadedLevel);
			}
		}
        	
	}
	
	
	
	// Update is called once per frame
	void Update () {
	
	}
}
