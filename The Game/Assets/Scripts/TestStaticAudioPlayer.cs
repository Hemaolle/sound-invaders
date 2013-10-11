using UnityEngine;
using System.Collections;

public class TestStaticAudioPlayer : MonoBehaviour {
	
	public AudioClip clip;
	public float semitoneOffset;
	
	void OnMouseDown() {
		Debug.Log("Clicked");
		StaticAudioPlayer.Play(clip, 0.5f, semitoneOffset);
	}
}
