using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : MonoBehaviour, Interactable
{
    [SerializeField] Animator animClip;
    [SerializeField] AudioSource switchSource;
    private Game_Manager gameManager;
    public void Interact()
    {
        animClip.SetTrigger("On");
        gameManager.SwitchTriggered(gameObject.name);
        switchSource.PlayOneShot(switchSource.clip);
    }

    void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<Game_Manager>();
        if (!gameManager)
        {
            Debug.LogError("No Game Manager in Scene");
        }
    }


}
