using UnityEngine;
using System.Collections;

public class EnemyController : MonoBehaviour {
	public GameObject explosion;
	public int penalty = 300;
	public AudioClip boomSound;
	
	private NoteTuple _interval;
	private bool dying = false;
	
	void OnMouseOver () {
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
			StaticAudioPlayer.Play(boomSound);
			string part = "Particle" + _interval.Interval().ToString();
			print ("part: " +part);
			GameObject boom = (GameObject)Instantiate(explosion, transform.position, Quaternion.Euler(Vector3.zero));
			ParticleSystem[] systems = boom.GetComponentsInChildren<ParticleSystem>();
			for(int i = 0; i < systems.Length; i++){
				//systems[i].renderer.material = (Material)Resources.Load(part);
			}
			Destroy(gameObject);
			Score.Hit();
		}else if(!cannonInterval.Equals(_interval) && !dying){
			r.AddForce(Vector3.down * penalty);
			Score.Miss();
		}
	}
	
	void OnTriggerEnter(Collider other) {
		if(other.name == "DestroyArea"){
			GameObject boom = (GameObject)Instantiate(explosion, transform.position, Quaternion.Euler(Vector3.zero));
			StaticAudioPlayer.Play(boomSound);
        	Destroy(gameObject);
			if(Score.multiplier == 1 && !GameOver.IsGameOver())
				Score.GameOver();
			Score.Miss();
		}
    }
	
	public void setDrag(float newDrag){
		rigidbody.drag = newDrag;
	}

}


