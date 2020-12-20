using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseInteract : MonoBehaviour
{
    protected Game_Manager gameManager;
    // Start is called before the first frame update
    public virtual void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<Game_Manager>();
        if (!gameManager)
        {
            Debug.LogError("No Game Manager in Scene");
        }
    }
}
