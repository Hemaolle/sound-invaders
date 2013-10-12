using UnityEngine;
using System.Collections;

public class MenuItem : MonoBehaviour {
	
	public int index;
	public Behaviours behaviour;
	public enum Behaviours{ Quit, None }
	
	
	private bool activated = false;
	private Vector3 originalScale;
	private float scaleMultiplier = 1.2f;
	private Menu menu;
	private MenuItemBehaviour behaviourObj;
	
	// Use this for initialization
	void Start () {	
		originalScale = transform.localScale;
		menu = transform.parent.GetComponent<Menu>();
		switch (behaviour) {
			
		case Behaviours.Quit:
			behaviourObj = new QuitBehaviour();
		break;
			
		default:
			behaviourObj = new NoBehaviour();
		break;
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnMouseEnter() {
		menu.Activate(index);
	}
	
	void OnMouseExit() {
		menu.Deactivate();
	}
	
	void OnMouseDown() {
		menu.Execute(index);
	}
	
	public void Activate() {
		activated = true;
		transform.localScale = scaleMultiplier * originalScale;
	}
	
	public void DeActivate() {
		activated = false;	
		transform.localScale = originalScale;	
	}
	
	public void Execute() {
		behaviourObj.Execute();	
	}
	
	private interface MenuItemBehaviour {
		void Execute();	
	}
	
	private class QuitBehaviour : MenuItemBehaviour {
		
		public void Execute() {
			Debug.Log("Quit");
			Application.Quit();
		}
	}
	
	private class NoBehaviour : MenuItemBehaviour {
		public void Execute() 	{
			Debug.Log("Do nothing");
		}
	}
}
