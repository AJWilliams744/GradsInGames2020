using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    [SerializeField] private AudioClip[] MusicTracks;
    [SerializeField] private AudioSource audioSource;

    private int currentSong = 0;

    private void Start()
    {
        audioSource.clip = MusicTracks[currentSong];
        audioSource.Play();
    }

    public void NextSong()
    {
        currentSong += 1;
        if(currentSong > MusicTracks.Length)
        {
            currentSong = 0;
        }

        StartCoroutine(FadeSong(MusicTracks[currentSong], 2f));
    }

    public void Stop()
    {
        audioSource.Stop();
    }

    //Fades in song over face duration in seconds
    private IEnumerator FadeSong(AudioClip nextSong, float fadeDuration)
    {
        float volume = audioSource.volume;
        float volumeFadeValue = volume / 10;

        for(int i = 0; i < 10; i++)
        {
            audioSource.volume -= volumeFadeValue;
            yield return new WaitForSeconds(fadeDuration/10);
        }

        audioSource.clip = nextSong;
        audioSource.Play();

        for (int i = 0; i < 10; i++)
        {
            audioSource.volume += volumeFadeValue;
            yield return new WaitForSeconds(fadeDuration/10);
        }

    }

}
