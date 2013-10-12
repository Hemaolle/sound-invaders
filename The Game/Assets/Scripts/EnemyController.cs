using UnityEngine;
using System.Collections;

public class EnemyController : MonoBehaviour {
	
	private NoteTuple _interval;
	
	void OnMouseOver () {
		if (Input.GetMouseButtonDown(0)){
            Debug.Log("Pressed left click.");
		}
   		if (Input.GetMouseButtonDown(1)) {
      		print("right");
			StaticAudioPlayer.PlayNote(0.5f, _interval.note1.GetStOffset());
			StaticAudioPlayer.PlayNote(0.5f, _interval.note2.GetStOffset());
   		}
	}
	
	public void setInterval(NoteTuple interval){
		_interval = interval;
	}
}
