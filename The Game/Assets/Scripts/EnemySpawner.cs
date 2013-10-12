using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour {
	public float minTime = 300;
	public float maxTime = 600;
	public int drag = 12;
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
	}
	
	// Update is called once per frame
	void Update () {
		
		if(spawning && Time.time - _lastTime > _currentInterval){
			spawn ();
		}
			
	}
	
	public void StartSpawning() {
		spawning = true;	
	}
	
	void spawn(){
		_lastTime = Time.time;
		//_timeIntervals = new float[enemyCount];
		_currentInterval = Random.Range(minTime, maxTime)/100f;
		print ("Interval: " + _currentInterval);
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
	
	public void increaseSpawnRate(){
		minTime-= 0.1f;
		maxTime-= 0.1f;
		if(minTime < 0)
			minTime = 0;
		if(maxTime < 1)
			maxTime = 1;
	}
	
	public void decreaseDrag(){
		drag--;
		if(drag < 0)
			drag = 0;
	}
}
