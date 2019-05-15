using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SelectionScript : MonoBehaviour
{
    public int teams = 6;
    public Sprite[] characters;
    public string[] teamName;
    public Vector3[] positions;
    // Start is called before the first frame update
    private void Awake()
    {
        for (int i = 0; i < teams; i++)
        {
            transform.position = positions[i];
        }
    }
    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {
        
    }

}
