using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour {
	public int minTime = 1;
	public int maxTime = 3;
	public int enemyCount = 10;
	public int[] intervals;
	public GameObject enemy;
	
	private int _cloneCount = 0;
	private float _lastTime;
	private float _currentInterval;
	//private GameObject[] _enemies;
	//private float[] _timeIntervals;
	
	// Use this for initialization
	void Start () {
		//_enemies = new GameObject[enemyCount];
		spawn();
	}
	
	// Update is called once per frame
	void Update () {
		if(Time.time - _lastTime > _currentInterval && _cloneCount < enemyCount){
			spawn ();
		}
			
	}
	
	void spawn(){
		_lastTime = Time.time;
		//_timeIntervals = new float[enemyCount];
		_currentInterval = Random.Range(minTime, maxTime);
		int _rndX = Random.Range(-10, 10);
		
		//_timeIntervals[0] = _currentInterval;
		//_enemies[0] = (GameObject)Instantiate(enemy, new Vector3(_rndX, 10, 0), Quaternion.Euler(Vector3.zero));
		GameObject clone = (GameObject)Instantiate(enemy, new Vector3(_rndX, 10, 0), Quaternion.Euler(Vector3.zero));
		_cloneCount++;
	}
}
