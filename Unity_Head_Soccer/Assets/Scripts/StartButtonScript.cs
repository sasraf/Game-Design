using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartButtonScript : MonoBehaviour {

	private bool player1Selected;
	private bool player2Selected;

	private CharacterManager thisManager;

	private bool readyToStart;

	// Use this for initialization
	void Start () {

		thisManager = (CharacterManager)gameObject.GetComponent(typeof(CharacterManager));

		player1Selected = false;
		player2Selected = false;
	}
	
	// Update is called once per frame
	void Update () {

		player1Selected = thisManager.player1IsSelected ();
		player2Selected = thisManager.player2IsSelected ();

		if (player1Selected && player2Selected) {
			readyToStart = true;
		}

		if (Input.GetKeyDown (KeyCode.Return) && readyToStart == true) {
			SceneManager.LoadScene (sceneName:"Game");
		}
	}
}
