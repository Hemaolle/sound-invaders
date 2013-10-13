using UnityEngine;
using System.Collections;

public class HighScoreLevelArrow : MonoBehaviour {
	
	public HighScoreListController highScoreController;
	public int levelChange = 1;
	
	void OnMouseDown() {
		highScoreController.ChangeSelectedLevel(levelChange);
	}
}
