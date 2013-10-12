using UnityEngine;
using System.Collections;

[System.Serializable]
public class NoteTuple {
	
	public Note note1;
	public Note note2;
	
	bool Equals(NoteTuple another) {
		if ((note1.GetStOffset() == another.note1.GetStOffset() && 
			note2.GetStOffset() == another.note2.GetStOffset()) || 
			(note1.GetStOffset() == another.note2.GetStOffset() &&
			note2.GetStOffset() == another.note1.GetStOffset()))
			return true;
		else
			return false;
	}
}
