using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaptopInteract : BaseInteract, Interactable
{
   
    [SerializeField] private Transform playerLookTransform;
    [SerializeField] private Transform playerReturnTransform;
    // Start is called before the first frame update
    

    public void Interact()
    {
        gameManager.StartLaptopInteract(playerLookTransform, playerReturnTransform);
    }

    public Transform GetReturnTransform()
    {
        return playerReturnTransform;
    }

    //public void Leave()
    //{
    //    gameManager.EndLaptopInteract(playerReturnTransform);
    //}
}
