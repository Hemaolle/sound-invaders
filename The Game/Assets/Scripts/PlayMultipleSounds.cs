using UnityEngine;
using System.Collections;

public class PlayMultipleSounds : MonoBehaviour {
	
	public PlaySound[] soundSources;
	
	public int numSounds;
	public Note[] notes;
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	void OnMouseDown() {
		for(int i = 0; i < numSounds; i++) {
			soundSources[i].PlayNote(notes[i].GetStOffset());
		}			
	}
}
