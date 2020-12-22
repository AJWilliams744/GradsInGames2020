using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private GameObject mainMenu;
    [SerializeField] private GameObject notesMenu;

    [SerializeField] private GameObject notePrefab;
    [SerializeField] private GameObject allNotesArea;

    [SerializeField] private GameObject selectedNoteArea; //TO-DO Put this functionality into another class (Note Menu Class)
    [SerializeField] private TMP_Text noteTitleArea;
    [SerializeField] private TMP_Text noteContentsArea;

    [SerializeField] private Slider mouseSensitivitySlider;
    [SerializeField] private Player_Manager playerManager;

    private Game_Manager gameManager;

    private void OnEnable()
    {
        PauseGame();
    }

    private void OnDisable()
    {
        ResumeGame();
    }

    public void PauseGame()
    {
        gameObject.SetActive(true);
        ShowMain();
        Time.timeScale = 0;
        Cursor.lockState = CursorLockMode.Confined;
    }

    public void ResumeGame()
    {
        gameObject.SetActive(false); //Incase called from somewhere else
        Time.timeScale = 1;
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void ShowMain()
    {
        mainMenu.SetActive(true);
        notesMenu.SetActive(false);
    }

    private void ShowNotes()
    {
        selectedNoteArea.SetActive(false);
        mainMenu.SetActive(false);
        notesMenu.SetActive(true);
    }

    public void Quit()
    {
        print("loading");
        PlayerPrefs.SetInt("Scene", 0);
        SceneManager.LoadScene("LoadingScene");
    }

    public void NotesMenu()
    {
        ShowNotes();
        ClearMenu();

        foreach(Note nt in gameManager.GetNotes())
        {
            GameObject noteCard;

            noteCard = Instantiate(notePrefab, allNotesArea.transform);
            noteCard.GetComponent<NoteButton>().SetNote(nt, NoteClick);
        }

    }

    public void NoteClick(Note _note)
    {
        selectedNoteArea.SetActive(true);
        if (_note.Collected)
        {
            noteTitleArea.text = _note.Title;
            noteContentsArea.text = _note.Contents;
        }
        else
        {
            noteTitleArea.text = "Unkown";
            noteContentsArea.text = "Unkown";
        }
    
    }

    public void NotesBack()
    {
        ClearMenu();
        ShowMain();
    }

    private void ClearMenu()
    {
        foreach (Transform obj in allNotesArea.transform)
        {
            Destroy(obj.gameObject);
        }
    }

    private void Start()
    {
        //gameObject.SetActive(false);

        mouseSensitivitySlider.onValueChanged.AddListener(delegate { playerManager.SetMouseSensitivity((int)mouseSensitivitySlider.value); });
    }
    private void Awake()
    {
        gameManager = StaticClasses.GetGameManager();
       

        if(PlayerPrefs.GetInt("MouseSensitivity") > 0)
        {
            mouseSensitivitySlider.value = PlayerPrefs.GetInt("MouseSensitivity");
            //print(PlayerPrefs.GetFloat("MouseSensitivity"));
        }
        else
        {
            PlayerPrefs.SetInt("MouseSensitivity", (int)mouseSensitivitySlider.value);
        }
    }

    public void ResetDimension()
    {
        gameManager.ResetDimension();
    }
}
