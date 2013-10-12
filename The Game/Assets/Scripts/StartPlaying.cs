using UnityEngine;
using System.Collections;

public class StartPlaying : MonoBehaviour {
	
	private EnemySpawner enemySpawner;
	
	// Use this for initialization
	void Start () {
		enemySpawner = FindObjectOfType(typeof(EnemySpawner)) as EnemySpawner;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0) || Input.GetMouseButtonDown(1) || Input.GetMouseButtonDown(2)) {
			Debug.Log("Clicked");
			enemySpawner.StartSpawning();
			Destroy(gameObject);	
		}
	}
}
