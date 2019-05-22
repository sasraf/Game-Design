using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSelect : MonoBehaviour {

	public string characterName = gameObject.name;

	public bool Clicked()
	{
		if (Input.GetMouseButtonDown (0)) {
			return true;
		} 
		else {
			return false;
		}

	}

	public string getName()
	{
		return characterName;
	}
}
