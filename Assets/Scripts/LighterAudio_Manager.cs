using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LighterAudio_Manager : MonoBehaviour
{

    [SerializeField] private AudioSource lighterSource;
    [SerializeField] private AudioSource lighterFlickSource;

    public void FlickedOn()
    {

        lighterFlickSource.Play();        
        lighterSource.Play();
    }

    public void FlickedOff()
    {
        lighterSource.Stop();
    }

}
