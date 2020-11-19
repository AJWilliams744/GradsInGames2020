using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPointSystem : MonoBehaviour
{
    [SerializeField] private Transform[] checkPoints;
    private int currentCheckPoint = 0;
    
    public Transform GetCurrentCheckLocation()
    {
        return checkPoints[currentCheckPoint];
    }

    public void ResetProgress()
    {

    }

    public void TriggerNextPoint()
    {

    }

}
