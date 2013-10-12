using UnityEngine;
using System.Collections;

public class Cannon : MonoBehaviour {
	
	public KeyCode activationKey;
	public Note note1;
	public Note note2;
	public NoteTuple noteTuple;
	
	private Vector3 originalScale;
	private bool activated = false;
	private float activeSizeMultiplier = 1.2f;
	private LineRenderer laser;
	private float laserShowTime = 0.3f;
	
	private static float activateCooldown = 0.1f;	
	private static int lastLaserActivator;
	private static float lastActivateTime;
	
	// Use this for initialization
	void Start () {
		originalScale = transform.localScale;
		laser = GameObject.Find("Laser").GetComponent<LineRenderer>();
		laser.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey(activationKey) && !activated) {// && Time.timeSinceLevelLoad - lastActivateTime > activateCooldown) {
			Activate();
		}
		
		if (Input.GetMouseButtonDown(0) && activated)
	    {
	        RaycastHit hit = new RaycastHit();
	        if(Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit))
	        {
	            if(hit.collider.tag == "Enemy") {
					ShootLaser(hit.collider.gameObject);
				}					
	        }
	    }
	}
	
	private void ShootLaser(GameObject target) {
		laser.SetPosition(0, transform.position + Vector3.forward);
		laser.SetPosition(1, target.collider.transform.position + Vector3.forward);
		laser.enabled = true;
		lastLaserActivator = this.GetInstanceID();
		Invoke("DisableLaser", laserShowTime);
	}
	
	private void Activate() {
		foreach (Cannon cannon in (FindObjectsOfType(typeof (Cannon)) as Cannon[]))
				cannon.InActivate();					
		activated = true;
		transform.localScale = originalScale * 1.2f;
		Debug.Log("Cannon activated");
		StaticAudioPlayer.PlayNote(0.5f, note1.GetStOffset());
		StaticAudioPlayer.PlayNote(0.5f, note2.GetStOffset());
		//lastActivateTime = Time.timeSinceLevelLoad;
	}
	
	public void InActivate() {
		activated = false;
		transform.localScale = originalScale;
	}
	
	public void DisableLaser() {
		if (lastLaserActivator == this.GetInstanceID())
			laser.enabled = false;	
	}
}
