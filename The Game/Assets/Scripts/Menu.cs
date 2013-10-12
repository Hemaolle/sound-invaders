using UnityEngine;
using System.Collections;

public class Menu : MonoBehaviour {
	
	public TextMesh levelText;
	public int levels;
	
	private int activated = 0;
	private bool someActivated = false;
	private int selectedLevel = 1;
	
	public GameObject[] menuItems;
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.DownArrow)) {
			if(someActivated) {				
				Activate(activated + 1);				
			}
			else {
				Activate(0);	
			}
		}
		
		if(Input.GetKeyDown(KeyCode.UpArrow)) {
			if(someActivated) {
				
				Activate(activated - 1);
				
			}
			else {
				Activate(menuItems.Length - 1);	
			}
		}
		
		if(menuItems[activated].GetComponent<MenuItem>().behaviour == MenuItem.Behaviours.Level) {
			
			if(Input.GetKeyDown(KeyCode.LeftArrow)) {
				ChangeLevel(-1);
			}
			
			if(Input.GetKeyDown(KeyCode.RightArrow)) {
				ChangeLevel(1);
			}
		}
		
		if(Input.GetKeyDown(KeyCode.Return)) {
			Execute(activated);
		}
	}
	
	public void Execute(int index) {
		menuItems[index].GetComponent<MenuItem>().Execute();
	}
	
	public void ChangeLevel(int change) {
		selectedLevel += change;
		if (selectedLevel < 1)
			selectedLevel = levels;
		else if (selectedLevel > levels)
			selectedLevel = 1;
		levelText.text = "" + selectedLevel;
	}
	
	public void Activate(int index) {
		if(someActivated)
			menuItems[activated].GetComponent<MenuItem>().DeActivate();
		activated = index;
		if (activated > menuItems.Length - 1)
			activated = 0;
		if (activated < 0)
			activated = menuItems.Length - 1;
		menuItems[activated].GetComponent<MenuItem>().Activate();
		someActivated = true;
	}
	
	public void Deactivate() {
		menuItems[activated].GetComponent<MenuItem>().DeActivate();
		someActivated = false;
	}
	
	public int GetSelectedLevel() {
		return selectedLevel;	
	}
}
