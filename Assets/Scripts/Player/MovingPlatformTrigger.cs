using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatformTrigger : MonoBehaviour
{

    [SerializeField] private MoveBetween moveBetween;
    [SerializeField] private GameObject[] helperLights;
    [SerializeField] private GameObject[] outsideLights;
    
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            moveBetween.StopMoving();
            SwitchHelperLight(true);
            SwitchOutsideLight(false);
        }
        
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            moveBetween.StartMoving();
            SwitchHelperLight(false);
            SwitchOutsideLight(true);
        }
    }

    private void SwitchHelperLight(bool value)
    {
        foreach (GameObject gm in helperLights)
        {
            gm.SetActive(value);
        }
    }

    private void SwitchOutsideLight(bool value)
    {
        foreach (GameObject gm in outsideLights)
        {
            gm.SetActive(value);
        }
    }
}
