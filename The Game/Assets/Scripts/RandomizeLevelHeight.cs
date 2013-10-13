using UnityEngine;
using System.Collections;

public class RandomizeLevelHeight : MonoBehaviour {

	private bool randomized = false;
	private int middleNote;
	// Use this for initialization

	public int GetLevelMiddleNote() {
		if (!randomized) {
			randomized = true;
			middleNote = Random.Range(0,12);
		}
		return middleNote;
	}
	
}
