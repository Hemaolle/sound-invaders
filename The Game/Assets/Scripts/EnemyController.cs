using UnityEngine;
using System.Collections;

public class EnemyController : MonoBehaviour {
	public GameObject explosion;
	
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
		Rigidbody r = GetComponent<Rigidbody>();
		if(cannonInterval.Equals(_interval) && !dying){
			dying = true;
			//r.isKinematic = true;
			GameObject boom = (GameObject)Instantiate(explosion, transform.position, Quaternion.Euler(Vector3.zero));
			Destroy(gameObject);
					
		}else if(!cannonInterval.Equals(_interval) && !dying)
			r.AddForce(Vector3.down * 300);
	}
	
	void OnTriggerEnter(Collider other) {
		if(other.name == "DestroyArea"){
        	Destroy(gameObject);
		}
    }

}


