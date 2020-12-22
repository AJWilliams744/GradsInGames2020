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


        gameManager = StaticClasses.GetGameManager();

        gameManager.SwitchTriggered("WorldTree");
        gameManager.NextSong();
        
       
    }

}
