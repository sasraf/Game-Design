using System.Collections.Generic;
using UnityEngine;
using System.Collections;

public class Player1Movement : MonoBehaviour {

	public float speed;             // Floating point variable to store the player's movement speed.

	public float jump;				// Floating point variable to store the player's jump speed.

	private Rigidbody2D rb2d;       // Store a reference to the Rigidbody2D component required to use 2D Physics.

	// Use this for initialization
	void Start()
	{
		//G et and store a reference to the Rigidbody2D component so that we can access it.
		rb2d = GetComponent<Rigidbody2D> ();
	}
		

	// FixedUpdate is called at a fixed interval and is independent of frame rate. Put physics code here.
	void FixedUpdate()
	{
		// Sets vector movement to 0
		Vector2 movement = new Vector2 (0, 0);

		// Checks if left key is being pressed down
		if (Input.GetKey (KeyCode.LeftArrow)) {
			movement = new Vector2 (-1, 0);
		} 

		// Checks if right arrow is being pressed down
		else if (Input.GetKey (KeyCode.RightArrow)) {
			movement = new Vector2 (1, 0);	
		} 

		// Checks if space is pressed
		if (Input.GetKeyDown(KeyCode.Keypad0) && rb2d.velocity.y == 0) {
			movement = new Vector2 (0, jump);
		}

		// Applies movement vector to rigidbody.
		rb2d.AddForce (movement * speed);
	}
}