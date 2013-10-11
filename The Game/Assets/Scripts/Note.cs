using UnityEngine;
using System.Collections;

[System.Serializable]
public class Note {
	public NName nname;
	//public string test;
	public int octave;
	
	public enum NName { C, Cis, D, Dis, E, F, Fis, G, Gis, A, Ais, B, }
	
	public float GetStOffset() {
		//return 0;
		return (int)nname + octave * 12;
	}
}
