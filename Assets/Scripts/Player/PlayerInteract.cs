using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class PlayerInteract : MonoBehaviour
{
    [SerializeField] private LayerMask layerMask;
    [SerializeField] private float PlayerReach;

    private Interactable interact;
    private bool InteractOnScreen;
    private RaycastHit hit;

    private Game_Manager gameManager;

    private void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<Game_Manager>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        gameManager.SetUIInteractScreen(false);
        interact = null;


        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, PlayerReach, layerMask))
        {
            interact = hit.transform.gameObject.GetComponent(typeof(Interactable)) as Interactable;
            if (interact != null)
            {            
                gameManager.SetUIInteractScreen(true);
            }           
            
        }
    }

    private void Update()
    {
        if (Input.GetButtonDown("Interact") && interact != null)
        {
            interact.Interact();
        }
    }
}
