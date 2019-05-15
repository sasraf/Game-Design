using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public float horizontalAxis, speed;
    private Rigidbody2D rigidPlayer;
    // Start is called before the first frame update
    void Start()
    {
        rigidPlayer = GetComponent<Rigidbody2D>(); 
    }

    private void FixedUpdate()
    {

    }
    // Update is called once per frame
    void Update()
    {
        rigidPlayer.velocity = new Vector2(Time.deltaTime * speed * horizontalAxis, rigidPlayer.velocity.y);
    }

    public void Move(int value)
    {
        horizontalAxis = value;
    }

    public void StopMoving()
    {
        horizontalAxis = 0;
    }

}
