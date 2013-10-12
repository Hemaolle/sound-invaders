using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour {
	public int minTime = 1;
	public int maxTime = 3;
	public int enemyCount = 10;
	public int drag = 8;
	public GameObject enemy;
	
	private NoteTuple[] intervals;
	private int _cloneCount = 0;
	private float _lastTime;
	private float _currentInterval;
	//private GameObject[] _enemies;
	//private float[] _timeIntervals;
	
	private bool spawning = false;
	
	// Use this for initialization
	void Start () {
		//_enemies = new GameObject[enemyCount];
		Cannon[] cannons = FindObjectsOfType(typeof(Cannon)) as Cannon[];
		intervals = new NoteTuple[cannons.Length];
		for(int i = 0; i<cannons.Length; i++){
			intervals[i] = cannons[i].noteTuple;
		}
		spawn();
	}
	
	// Update is called once per frame
	void Update () {
		
		if(spawning && Time.time - _lastTime > _currentInterval && _cloneCount < enemyCount){
			spawn ();
		}
			
	}
	
	public void StartSpawning() {
		spawning = true;	
	}
	
	void spawn(){
		_lastTime = Time.time;
		//_timeIntervals = new float[enemyCount];
		_currentInterval = Random.Range(minTime, maxTime);
		int _rndX = Random.Range(-15, 15);
		
		//_timeIntervals[0] = _currentInterval;
		//_enemies[0] = (GameObject)Instantiate(enemy, new Vector3(_rndX, 10, 0), Quaternion.Euler(Vector3.zero));
		GameObject clone = (GameObject)Instantiate(enemy, new Vector3(_rndX, 10, 0), Quaternion.Euler(Vector3.zero));
		clone.rigidbody.drag = drag;
		clone.rigidbody.AddTorque(Vector3.forward*100);
		EnemyController ec = clone.GetComponentInChildren <EnemyController>();
		NoteTuple _rndInterval = intervals[Random.Range(0,intervals.Length)];
		//print (_rndInterval);
		ec.setInterval(_rndInterval);
		_cloneCount++;
	}
}
