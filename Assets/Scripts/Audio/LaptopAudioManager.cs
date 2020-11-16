using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaptopAudioManager : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;

    [SerializeField] private AudioClip typing;
    [SerializeField] private AudioClip waiting;

    public void StartTyping()
    {
        audioSource.clip = typing;
        audioSource.Play();
    }
    public void StartWaiting()
    {
        audioSource.clip = waiting;
        audioSource.Play();
    }
    public void Stop()
    {
        audioSource.Stop();
    }
   
   

}
