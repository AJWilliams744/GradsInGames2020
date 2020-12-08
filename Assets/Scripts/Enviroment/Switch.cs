using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : BaseInteract, Interactable
{
    [SerializeField] Animator animClip;
    [SerializeField] AudioSource switchSource;
    public void Interact()
    {
        animClip.SetTrigger("On");
        gameManager.SwitchTriggered(gameObject.name);
        switchSource.PlayOneShot(switchSource.clip);
    }



}
