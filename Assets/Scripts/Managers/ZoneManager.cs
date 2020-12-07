using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoneManager : MonoBehaviour
{
    [SerializeField] private ZoneTrigger[] allZones;
    
    public ZoneTrigger[] GetZones()
    {
        return allZones;
    }

    public void TriggerZones(int currentZone)
    {
        for(int i = 0; i < currentZone; i++)
        {
            allZones[i].LoadTrigger();
        }
    }
}
