/***************************************************************
 * Is supposed to have multiple game objects as children, which
 * each have one AudioSource component attached. When Play is
 * called, plays the AudioSource attached to the component with
 * given path under the game object this script is attached to.
 * 
 * Another possibility is to give an AudioClip as parameter
 * and instantiate a prefab with an AudioSource attached, then 
 * play the given AudioClip from newly instanciated gameObject,
 * then destroy the gameObject. This makes possible playing the
 * same sound effect multiple times repeatedly on top of itself.
 * 
 * Author: Oskari Leppäaho
 * Version: 0.1
 ***************************************************************/



using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AudioPlayer : MonoBehaviour {
	
	public GameObject audioSourcePrefab;
	
	private Dictionary<string,AudioSource> _audioSources;
	
	
	// Use this for initialization
	public void Start () {
		_audioSources = new Dictionary<string, AudioSource>();
		TraverseHierarchy(transform, "");
	}
	
	// Loop through all the child game objects adding their AudioSource components
	// to the dictionary.
	private void TraverseHierarchy(Transform root, string path) {
		foreach (Transform child in root) {
			if(child.audio != null)
				_audioSources.Add(path.Substring(1) + "/" + child.gameObject.name, child.audio);
			TraverseHierarchy(child, path + "/" + child.gameObject.name);
		}
	}
	
	public void Play(string path) {		
		_audioSources[path].Play();
	}
	
	public void Play(AudioClip clip) {
		Play (clip, 0.5f, 0f);	
	}
	
	public void Play(AudioClip clip, float volume) {
		Play (clip, volume, 0f);	
	}
	
	public void Play(AudioClip clip, float volume, float semitoneOffset) {
		GameObject go = (GameObject)Instantiate(audioSourcePrefab,transform.position,Quaternion.identity);
		AudioSource audioSource = go.GetComponent<AudioSource>();		
		audioSource.clip = clip;
		audioSource.volume = volume;
		audioSource.Play();
		audioSource.pitch = Mathf.Pow (2f, semitoneOffset/12.0f);
		StartCoroutine(DestroyGameobjectWithDelay(go,clip.length));
	}
	
	public void PlayLooping(AudioClip clip) {
		PlayLooping(clip, 0.5f);	
	}
	
	public void PlayLooping(AudioClip clip, float volume) {
		GameObject go = (GameObject)Instantiate(audioSourcePrefab,transform.position,Quaternion.identity);
		AudioSource audioSource = go.GetComponent<AudioSource>();
		audioSource.loop = true;
		audioSource.volume = volume;
		audioSource.clip = clip;
		audioSource.Play();
	}
			
	IEnumerator DestroyGameobjectWithDelay(GameObject go, float delay) {
		yield return new WaitForSeconds(delay);
		Destroy(go);
	}
}
