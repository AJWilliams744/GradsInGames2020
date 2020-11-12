using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private Game game;
    [SerializeField] private Animator CameraAnim;
    [SerializeField] private GameObject MainMenuCanvas;

    [SerializeField] private float waitTime = 7f;


    private bool gameStarted = false;
    void Start()
    {
        game.enabled = false;
    }

    // Update is called once per frame
    public void PlayGamePressed()
    {
        MainMenuCanvas.SetActive(false);
        CameraAnim.SetTrigger("StartGame");
        StartCoroutine(StartGame());       
    }

    public void QuitGamePressed()
    {
        Application.Quit();
    }

    //Allow for camera to reach laptop before starting
    IEnumerator StartGame()
    {
               
        yield return new WaitForSeconds(waitTime);
        game.enabled = true;
    }
}
