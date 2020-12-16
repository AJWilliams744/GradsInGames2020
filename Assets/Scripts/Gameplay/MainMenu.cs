using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private Game game;
    [SerializeField] private Animator CameraAnim;
    [SerializeField] private GameObject MainMenuCanvas;

    [SerializeField] private  MusicManager musicManager;
    [SerializeField] private FXManager fXManager;

    [SerializeField] private NotesMainMenu notesMenu;
    [SerializeField] private GameObject noteMenuCanvas;

    [SerializeField] private float waitTime = 7f; // Time after play presssed game starts

    [SerializeField] private GameObject resumeButton;
    [SerializeField] private GameObject playButton;

    private int resumeBuildIndex = 0;

    void Start()
    {
        game.enabled = false;
        Cursor.lockState = CursorLockMode.Confined;

        resumeBuildIndex = GetSavedGameBuildIndex();

        if(resumeBuildIndex > 0)
        {
            resumeButton.SetActive(true);
            playButton.SetActive(false);
        }
        else
        {
            resumeButton.SetActive(false);
            playButton.SetActive(true);
        }

    }

    private int GetSavedGameBuildIndex()
    {
        int highestBuildIndex = 0;

        List<string> allNames = GameSave_Manager.GetAllDimensionNames();

        foreach(string name in allNames)
        {
            DimensionStorage gameSave = GameSave_Manager.LoadDimension(name);
            
            if(gameSave.buildIndex > highestBuildIndex)
            {
                highestBuildIndex = gameSave.buildIndex;
            }
        }

        return highestBuildIndex;
    }

    // Hide Menu, start animation and start game once animation is complete
    public void PlayGamePressed()
    {
        fXManager.ButtonPressed();
        MainMenuCanvas.SetActive(false);
        CameraAnim.SetTrigger("StartGame");
        StartCoroutine(StartGame());  //Wait for the animation to finish before triggering     
    }

    public void NotesButtonPressed()
    {
        MainMenuCanvas.SetActive(false);
        noteMenuCanvas.SetActive(true);

    }

    public void NotesBackButtonPressed()
    {
        MainMenuCanvas.SetActive(true);
        noteMenuCanvas.SetActive(false);
    }

    public void QuitGamePressed()
    {
        fXManager.ButtonPressed();
        Application.Quit();
    }

    //Allow for camera to reach laptop before starting
    IEnumerator StartGame()
    {
        musicManager.NextSong();
        yield return new WaitForSeconds(waitTime);
        game.enabled = true;       

    }

    public void ResumeGamePressed()
    {
        print("loading");
        PlayerPrefs.SetInt("Scene", resumeBuildIndex);
        SceneManager.LoadScene("LoadingScene");
    }

    public void NewGamePressed()
    {
        GameSave_Manager.DeleteAllDimensions();
        PlayGamePressed();
    }
}
