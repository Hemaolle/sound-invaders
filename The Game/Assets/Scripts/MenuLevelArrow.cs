using UnityEngine;
using System.Collections;

public class MenuLevelArrow : MonoBehaviour {
	
	public Menu menu;
	public int levelChange = 1;
	
	void OnMouseDown() {
		menu.ChangeLevel(levelChange);
	}
}
