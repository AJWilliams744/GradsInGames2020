using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseInteract : MonoBehaviour
{
    protected Game_Manager gameManager;
    // Start is called before the first frame update
    public virtual void Start()
    {
        gameManager = StaticClasses.GetGameManager();
    }
}

