using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class StaticClasses
{
    public static Game_Manager GetGameManager()
    {
        Game_Manager gameManager;

        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<Game_Manager>();
        if (!gameManager)
        {
            Debug.LogError("No Game Manager in Scene");
        }

        return gameManager;
    }
   
}
