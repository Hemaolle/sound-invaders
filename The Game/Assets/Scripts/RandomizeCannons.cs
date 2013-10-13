using UnityEngine;
using System.Collections;

public class RandomizeCannons : MonoBehaviour {
	
	public GameObject[] cannons;
	public KeyCode[] keyCodes;
	public GameObject[] cannonLocations;
	
	private ArrayList usedCannons;
	
	// Use this for initialization
	void Awake () {
		usedCannons = new ArrayList();
		int newCannonIndex;
		for (int i = 0; i < cannonLocations.Length; i++) {
			do {
				newCannonIndex = Random.Range(0, cannons.Length);
			} while(usedCannons.Contains(newCannonIndex));
			GameObject newCannon = Instantiate(cannons[newCannonIndex], cannonLocations[i].transform.position, Quaternion.identity) as GameObject;
			DestroyImmediate(cannonLocations[i]);
			usedCannons.Add(newCannonIndex);
			newCannon.GetComponent<Cannon>().activationKey = keyCodes[i];
		}
		print ("New cannons randomized");
	}
}
