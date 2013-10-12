using UnityEngine;
using System.Collections;

public class EnemyController : MonoBehaviour {
	
	
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnMouseOver () {
		if (Input.GetMouseButtonDown(0)){
            Debug.Log("Pressed left click.");
		}
   		if (Input.GetMouseButtonDown(1)) {
      		print("right");
			StaticAudioPlayer.PlayNote(100, 3);
   		}
	}
}
