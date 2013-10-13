using UnityEngine;
using System.Collections;

public class GrowWhenMouseOver : MonoBehaviour {
	
	private Vector3 originalScale;
	private float scaleMultiplier = 1.2f;
	
	// Use this for initialization
	void Start () {
		originalScale = transform.localScale;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnMouseEnter() {
		transform.localScale = scaleMultiplier * originalScale;
	}
	
	void OnMouseExit() {
		transform.localScale = originalScale;
	}
}
