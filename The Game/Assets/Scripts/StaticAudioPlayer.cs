/***************************************************************
 * Finds the AudioPlayer component and uses it to play audio.
 * 
 * Author: Oskari Leppäaho
 * Version: 0.1
 ***************************************************************/

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public static class StaticAudioPlayer {
	
	 static AudioPlayer audioPlayer;
	
	 static public void Play(string path) {
		InitializeAudioPlayer();
		audioPlayer.Play(path);	
	}
	
	static public void Play(AudioClip clip) {
		Play (clip, 1f, 0f);
	}
	
	static public void Play(AudioClip clip, float volume, float semitoneOffset) {
		InitializeAudioPlayer();
		audioPlayer.Play(clip, volume, semitoneOffset);
	}
	
	static public void PlayLooping(AudioClip clip) {
		PlayLooping(clip, 0.5f);
	}
	
	static public void PlayLooping(AudioClip clip, float volume) {
		InitializeAudioPlayer();		
		audioPlayer.PlayLooping(clip, volume);
	}
	
	static private void InitializeAudioPlayer() {
		if(audioPlayer == null)
		{
			audioPlayer = GameObject.Find("AudioSources").GetComponent<AudioPlayer>();			
		}
	}
}
