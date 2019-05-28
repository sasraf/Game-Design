using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallScript : MonoBehaviour
{

    private GameObject player;
    private GameObject player2;
    public GameObject goals;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        player2 = GameObject.FindGameObjectWithTag("Player2");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            player.GetComponent<Player1Movement>().canShoot = true;
        }
        if (collision.gameObject.tag == "Player2")
        {
            player2.GetComponent<Player2Movement>().canShoot = true;
        }
        if (collision.gameObject.tag == "LeftGoal")
        {
            Instantiate(goals, new Vector3(0, -2, 0), Quaternion.identity);
            if (GameController.instance.isGoal == false && GameController.instance.endMatch == false)
            {
                GameController.instance.scoreForLeft++;
            }
        }
        if (collision.gameObject.tag == "RightGoal")
        {
            Instantiate(goals, new Vector3(0, -2, 0), Quaternion.identity);
            if (GameController.instance.isGoal == false && GameController.instance.endMatch == false)
            {
                GameController.instance.scoreForRight++;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            player.GetComponent<Player1Movement>().canShoot = false;
        }
        if (collision.gameObject.tag == "Player2")
        {
            player2.GetComponent<Player2Movement>().canShoot = false;
        }
    }
}
