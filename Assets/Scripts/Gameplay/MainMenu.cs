using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private Game game;
    [SerializeField] private Animator CameraAnim;
    [SerializeField] private GameObject MainMenuCanvas;

    [SerializeField] private  MusicManager musicManager;
    [SerializeField] private FXManager fXManager;

    [SerializeField] private float waitTime = 7f; // Time after play presssed game starts

    void Start()
    {
        game.enabled = false;
    }

    // Hide Menu, start animation and start game once animation is complete
    public void PlayGamePressed()
    {
        fXManager.ButtonPressed();
        MainMenuCanvas.SetActive(false);
        CameraAnim.SetTrigger("StartGame");
        StartCoroutine(StartGame());  //Wait for the animation to finish before triggering     
    }

    public void QuitGamePressed()
    {
        fXManager.ButtonPressed();
        Application.Quit();
    }

    //Allow for camera to reach laptop before starting
    IEnumerator StartGame()
    {               
        yield return new WaitForSeconds(waitTime);
        game.enabled = true;
        musicManager.NextSong();
    }
}
