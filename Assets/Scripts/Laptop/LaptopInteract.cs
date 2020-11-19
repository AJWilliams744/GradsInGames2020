using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaptopInteract : MonoBehaviour, Interactable
{
    private Game_Manager gameManager;
    [SerializeField] private Transform playerLookTransform;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<Game_Manager>();
        if (!gameManager)
        {
            Debug.LogError("No Game Manager in Scene");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Interact()
    {
        gameManager.StartLaptopInteract(playerLookTransform);
    }
}
