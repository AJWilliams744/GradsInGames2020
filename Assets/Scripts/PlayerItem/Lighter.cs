using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lighter : MonoBehaviour , PlayerItem
{
    private bool isFireOn = false;
    [SerializeField] private GameObject fire;
    [SerializeField] private GameObject baseLight;

    private bool isFocusOn = false;
    [SerializeField] GameObject fireLight;
    [SerializeField] GameObject focusLight;

    [SerializeField] ParticleSystem sparks;

    [SerializeField] LighterAudio_Manager lighterAudio;


    public void MainFire()
    {
        isFireOn = !isFireOn;
        fire.SetActive(isFireOn);
        baseLight.SetActive(isFireOn);

        if (isFireOn)
        {
            lighterAudio.FlickedOn();
            sparks.Play();
        }
        else
        {
            lighterAudio.FlickedOff();
        }
    }

    public void SecondaryFire()
    {
        isFocusOn = !isFocusOn;
        fireLight.SetActive(!isFocusOn);
        focusLight.SetActive(isFocusOn);
    }

    private void Start()
    {
        
    }
}
