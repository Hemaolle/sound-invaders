using UnityEngine;
using System.Collections;

public class Cannon : MonoBehaviour {
	
	public KeyCode activationKey;
	
	private Vector3 originalScale;
	private bool activated = false;
	private float activeSizeMultiplier = 1.2f;
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey(activationKey)) {
			foreach (Cannon cannon in FindObjectOfType<Cannon>())
				
			
			activated = true;
			transform.localScale = originalScale * 1.2f;
		}			
	}
	
	public void InActivate() {
		activated = false;
		transform.localScale = originalScale;
	}
}
