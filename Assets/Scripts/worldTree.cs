using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class worldTree : MonoBehaviour
{
    private Game_Manager gameManager;

    private bool firstTime = true; //Stop it triggering before active is false

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            gameManager.SwitchTriggered("END");
        }
    }

    private void OnEnable()
    {

        
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<Game_Manager>();
        if (!gameManager)
        {
            Debug.LogError("No Game Manager in Scene");
        }

        gameManager.SwitchTriggered("WorldTree");
        gameManager.NextSong();
        
       
    }

}
