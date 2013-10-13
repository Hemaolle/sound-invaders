using UnityEngine;
using System.Collections;

public class Music : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Music[] musics = GameObject.FindObjectsOfType(typeof(Music)) as Music[];
		foreach(Music m in musics)
			if (m.gameObject.GetInstanceID() != gameObject.GetInstanceID())
				Destroy(gameObject);
		DontDestroyOnLoad(gameObject);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
