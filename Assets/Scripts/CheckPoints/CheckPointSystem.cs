using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPointSystem : MonoBehaviour
{
    [SerializeField] private Transform[] checkPoints;
    [SerializeField] private int currentCheckPoint = 0;
    
    public Transform GetCurrentCheckLocation()
    {
        return checkPoints[currentCheckPoint];
    }

    public int GetCurrentInt()
    {
        return currentCheckPoint;
    }

    public void SetProgress(int newCheckPoint)
    {
        if(newCheckPoint < checkPoints.Length & newCheckPoint > -1)
        {
            currentCheckPoint = newCheckPoint;
        }
    }

    public void TriggerNextPoint()
    {
        if(currentCheckPoint + 1 > checkPoints.Length - 1) { return; }

        currentCheckPoint++;
        
    }

}
