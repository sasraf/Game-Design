using System.Collections.Generic;
using UnityEngine;
using System.Collections;

public class Player1Movement : MonoBehaviour {

	public float speed;             // Floating point variable to store the player's movement speed.

	public float jump;				// Floating point variable to store the player's jump speed.

    public bool canShoot;           // Bool variable to check if you can shoot

    private GameObject ball;        // Game object variable to track the ball

	private Rigidbody2D rb2d;       // Store a reference to the Rigidbody2D component required to use 2D Physics.

	private int facing;

	// Use this for initialization
	void Start()
	{
		//G et and store a reference to the Rigidbody2D component so that we can access it.
		rb2d = GetComponent<Rigidbody2D>();
        ball = GameObject.FindGameObjectWithTag("Ball");
		facing = -1;
	}
		
	private void Flip()
	{
		// Multiply the player's x local scale by -1.
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
		facing = facing * -1;
	}

	// FixedUpdate is called at a fixed interval and is independent of frame rate. Put physics code here.
	void FixedUpdate()
	{
		// Sets vector movement to 0
		int movement = 0;
		float yVelocity = rb2d.velocity.y;

		// Checks if left key is being pressed down
		if (Input.GetKey (KeyCode.LeftArrow)) {

			// If facing the other way, flip
			if (facing != -1) {
				Flip ();
			}

			movement = -1;
		} 

		// Checks if right arrow is being pressed down
		else if (Input.GetKey (KeyCode.RightArrow)) {

			// If facing the other way, flip
			if (facing != 1) {
				Flip ();
			}
				
			movement = 1;
		} 

		// Checks if space is pressed
		if (Input.GetKeyDown(KeyCode.UpArrow) && rb2d.velocity.y == 0) {

			// Adds jump to current yVelocity
			yVelocity = jump + yVelocity;
		}

		// Apply velocity
		rb2d.velocity = new Vector2(movement * speed, yVelocity);
	}

    public void hitBall()
    {
        if (canShoot == true && Input.GetKey(KeyCode.Space))
        {
            ball.GetComponent<Rigidbody2D>().AddForce(new Vector2(-400, 500));
        }
    }
}