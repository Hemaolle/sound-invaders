using UnityEngine;
using System.Collections;

public class BackToMenu : MonoBehaviour {

	void OnMouseDown() {
		Application.LoadLevel("Menu");	
	}
}
