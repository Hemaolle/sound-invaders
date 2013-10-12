using UnityEngine;
using System.Collections;

public class EnemyController : MonoBehaviour {
	
	private NoteTuple _interval;
	private bool dying = false;
	
	void OnMouseOver () {
		if (Input.GetMouseButtonDown(0)){
            Debug.Log("Pressed left click.");
		}
   		if (Input.GetMouseButtonDown(1) && !dying) {
      		print("right");
			StaticAudioPlayer.PlayNote(0.5f, _interval.note1.GetStOffset());
			StaticAudioPlayer.PlayNote(0.5f, _interval.note2.GetStOffset());
   		}
	}
	
	public void setInterval(NoteTuple interval){
		_interval = interval;
	}
	
	public void Shot(NoteTuple cannonInterval) {
		if(cannonInterval.Equals(_interval) && !dying){
			dying = true;
			Rigidbody r = GetComponent<Rigidbody>();
			r.isKinematic = true;
			//Destroy(gameObject);
		}
	}
	
	void OnTriggerEnter(Collider other) {
		if(other.name == "DestroyArea"){
        	Destroy(gameObject);
		}
    }
}


