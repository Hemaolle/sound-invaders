using UnityEngine;
using System.Collections;

public class HighScoreListController : MonoBehaviour {
	
	public string [] levelnames;
	public int [] levelIndices;
	
	public TextMesh levelNumberText;
	
	private int selected = 0;
	
	// Use this for initialization
	void Start () {
		(FindObjectOfType(typeof (HighScore)) as HighScore).DisplayHighScores(levelIndices[selected]);
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.LeftArrow)) {
			ChangeSelectedLevel(-1);
		}
		if (Input.GetKeyDown(KeyCode.RightArrow)) {
			ChangeSelectedLevel(1);
		}
	}
	
	public void ChangeSelectedLevel(int change) {
		selected += change;
		if (selected < 0)
			selected = levelnames.Length - 1;
		else if (selected > levelnames.Length - 1)
			selected = 0;
		levelNumberText.text = levelnames[selected];
		(FindObjectOfType(typeof (HighScore)) as HighScore).DisplayHighScores(levelIndices[selected]);
	}
}
