using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextChanger : MonoBehaviour {

	private Text text;
	private CharacterManager thisManager;

	// Use this for initialization
	void Start () {
		text = GetComponent<Text>();
		thisManager = (CharacterManager)GameObject.FindGameObjectWithTag("CharacterManager").GetComponent(typeof(CharacterManager));
	}
	
	// Update is called once per frame
	void Update () {

		if (!thisManager.player1IsSelected ()) {
			text.text = "Select Player 1";
		} else if (thisManager.player1IsSelected () && !thisManager.player2IsSelected()) {
			text.text = "Player 1: " + thisManager.getPlayer1() + " | Select Player 2";
		} else if (thisManager.player1IsSelected() && thisManager.player2IsSelected()) {
			text.text =  "Player 1: " + thisManager.getPlayer1() + " | Player 2: " + thisManager.getPlayer2();
		}
	}
}
