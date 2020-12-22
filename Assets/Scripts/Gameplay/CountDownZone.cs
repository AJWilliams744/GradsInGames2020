using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CountDownZone : MonoBehaviour
{
    [SerializeField] private bool isStartZone;

    [SerializeField] private CountDownZoneParent zoneParent;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            if (isStartZone)
            {
                zoneParent.StartCountDown();
            }
            else
            {
                zoneParent.StopCountDown();
            }
            
        }


    }

}
