using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterManager : MonoBehaviour
{

    // Use this for initialization

    public string player1;
    public string player2;

    GameObject france = GameObject.FindGameObjectWithTag("France");
    GameObject germany = GameObject.FindGameObjectWithTag("Germany");
    GameObject germany2 = GameObject.FindGameObjectWithTag("Germany2");
    GameObject llama = GameObject.FindGameObjectWithTag("Llama");
    GameObject norway = GameObject.FindGameObjectWithTag("Norway");
    GameObject squidward = GameObject.FindGameObjectWithTag("Squidward");

    CharacterSelect franceScript = (CharacterSelect)france.GetComponent(typeof(CharacterSelect));
    CharacterSelect germanyScript = (CharacterSelect)germany.GetComponent(typeof(CharacterSelect));
    CharacterSelect germanyScript2 = (CharacterSelect)germany2.GetComponent(typeof(CharacterSelect));
    CharacterSelect llamaScript = (CharacterSelect)llama.GetComponent(typeof(CharacterSelect));
    CharacterSelect norwayScript = (CharacterSelect)norway.GetComponent(typeof(CharacterSelect));
    CharacterSelect squidwardScript = (CharacterSelect)squidward.GetComponent(typeof(CharacterSelect));

    void Start()
    {
        player1 = null;
        player2 = null;
    }

    // Update is called once per frame
    void Update()
    {
        if (franceScript.Clicked())
        {
            if (player1 == null)
            {
                player1 = franceScript.getName();
            }
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

    public string getPlayer1()
    {
        return player1;
    }

    public string getPlayer2()
    {
        return player2;
    }
}

