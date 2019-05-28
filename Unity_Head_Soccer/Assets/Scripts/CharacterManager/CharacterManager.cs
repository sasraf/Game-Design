using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterManager : MonoBehaviour
{
	// Initializes a string to hold player name
    public string player1;
    public string player2;

	// Initializes a reference to each characters CharacterSelect script
	CharacterSelect franceScript; 
	CharacterSelect germanyScript;
	CharacterSelect germanyScript2;
	CharacterSelect llamaScript;
	CharacterSelect norwayScript;
	CharacterSelect squidwardScript;

	// Initializes player strings
    void Start()
    {
        player1 = null;
        player2 = null;

		franceScript = (CharacterSelect)GameObject.FindGameObjectWithTag("France").GetComponent(typeof(CharacterSelect));
		germanyScript = (CharacterSelect)GameObject.FindGameObjectWithTag("Germany").GetComponent(typeof(CharacterSelect));
		germanyScript2 = (CharacterSelect)GameObject.FindGameObjectWithTag("Germany2").GetComponent(typeof(CharacterSelect));
		llamaScript = (CharacterSelect)GameObject.FindGameObjectWithTag("Llama").GetComponent(typeof(CharacterSelect));
		norwayScript = (CharacterSelect)GameObject.FindGameObjectWithTag("Norway").GetComponent(typeof(CharacterSelect));
		squidwardScript = (CharacterSelect)GameObject.FindGameObjectWithTag("Squidward").GetComponent(typeof(CharacterSelect));

    }

    // Update is called once per frame
    void Update()
    {
		// Checks if a player is clicked
        if (franceScript.Clicked())
        {
			// If player 1 is not assigned, assigns player name to player1
            if (player1 == null)
            {
                player1 = franceScript.getName();
            }
			// If player 1 is assigned, assign player name to player 2
            else
            {
                player2 = franceScript.getName();
            }
        }
        else if (germanyScript.Clicked())
        {
            if (player1 == null)
            {
                player1 = germanyScript.getName();
            }
            else
            {
                player2 = germanyScript.getName();
            }
        }
        else if (germanyScript2.Clicked())
        {
            if (player1 == null)
            {
                player1 = germanyScript2.getName();
            }
            else
            {
                player2 = germanyScript2.getName();
            }
        }
        else if (llamaScript.Clicked())
        {
            if (player1 == null)
            {
                player1 = llamaScript.getName();
            }
            else
            {
                player2 = llamaScript.getName();
            }
        }
        else if (norwayScript.Clicked())
        {
            if (player1 == null)
            {
                player1 = norwayScript.getName();
            }
            else
            {
                player2 = norwayScript.getName();
            }
        }
        else if (squidwardScript.Clicked())
        {
            if (player1 == null)
            {
                player1 = squidwardScript.getName();
            }
            else
            {
                player2 = squidwardScript.getName();
            }
        }
    }

	// Get player1 string 
    public string getPlayer1()
    {
        return player1;
    }

	// Get player2 string
    public string getPlayer2()
    {
        return player2;
    }

	public bool player1IsSelected()
	{
		if (player1 == null) {
			return false;
		} else {
			return true;
		}
	}

	public bool player2IsSelected()
	{
		if (player2 == null) {
			return false;
		} else {
			return true;
		}
	}


}

