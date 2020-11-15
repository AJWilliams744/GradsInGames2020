using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FXManager : MonoBehaviour
{
    [SerializeField] private AudioSource FX;
    [SerializeField] private AudioClip ButtonPress;
    
    public void ButtonPressed()
    {
        FX.clip = ButtonPress;
        FX.Play();
    }
}
