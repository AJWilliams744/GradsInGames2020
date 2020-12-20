using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class worldTree : MonoBehaviour
{
    private Game_Manager gameManager;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
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
