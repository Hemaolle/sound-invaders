using UnityEngine;
using System.Collections;

public class PlaySound : MonoBehaviour {

	public void PlayNote(float semitoneOffset) {
		audio.pitch = Mathf.Pow (2f, semitoneOffset/12.0f);
		audio.Play ();
	}
}
