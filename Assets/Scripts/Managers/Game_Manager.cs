using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(UI_Manager))]
[RequireComponent(typeof(Dimension))]
public class Game_Manager : MonoBehaviour
{
    private UI_Manager UIManager;
    [SerializeField] private Game game;
    [SerializeField] private Player_Manager playerManager;
    [SerializeField] private MusicManager musicManager;
    [SerializeField] private GameObject laptop;

    [SerializeField] private GameObject noteFoundUI;

    private Dimension dimensionInterface;
    private Transform laptopReturnTransform;

    private delegate void methodPasser();


    private float laptopMoveSpeed = 2f;

    // Start is called before the first frame update
    void Awake()
    {
        UIManager = GetComponent<UI_Manager>();
        dimensionInterface = GetComponent(typeof(Dimension)) as Dimension;

        // dimensionInterface.NormalStart();

        List<Note> notes = CreateNotes();

        dimensionInterface.LinkNotes(notes); //Links the references to the dimension not the values

        dimensionInterface.LoadProgress(); //Only 1 notes exists at one time, any changes propagate through the whole system

        ConnectNotesToGameObjects(notes); //Uses the loaded data and not the base data if called after       
       
        // game = GetComponent<Game>();
    }

    public void SetUIInteractScreen(bool value)
    {
        UIManager.SetInteractOnScreen(value);
    }

    public void StartLaptopInteract(Transform lookAtTransform, Transform returnTransform)
    {
        DisablePlayer();
        laptopReturnTransform = returnTransform;
        playerManager.MoveToLocation(lookAtTransform, laptopMoveSpeed);
        game.enabled = true;
    }   

    public void EndLaptopInteract()
    {
        methodPasser[] methodsToCall = new methodPasser[2];

        methodsToCall[0] = EnablePlayer;
        methodsToCall[1] = SwitchOffLaptop;

        if (laptopReturnTransform != null)
        {
            StartCoroutine(WaitToTrigger(methodsToCall, laptopMoveSpeed));
            playerManager.MoveToLocation(laptopReturnTransform, laptopMoveSpeed);
        }

        musicManager.NextSong();
        //CreateNotes();
    }

    public void PlayerDead()
    {
        dimensionInterface.PlayerDead();
    }

    public void TeleportPlayer(Transform newLocation)
    {
        playerManager.TeleportPlayer(newLocation);
    }

    public void ChoiceSelected(GiftChoices choice)
    {
        dimensionInterface.ChoiceSelected(choice);
    }

    private void DisablePlayer()
    {        
        playerManager.DisablePlayer();
        UIManager.SetInteractOnScreen(false);        
    }

    private void EnablePlayer()
    {
        playerManager.EnablePlayer();
        UIManager.SetInteractOnScreen(true);
    }

    private void SwitchOffLaptop()
    {
        Destroy(laptop.GetComponent<LaptopInteract>());
    }

    private IEnumerator WaitToTrigger(methodPasser[] methodsToCall, float time)
    {       
        yield return new WaitForSeconds(time);

        foreach(methodPasser method in methodsToCall)
        {
            method?.Invoke(); // If not null
        }

       // methodToCall();
    }

    public void SwitchTriggered(string name)
    {
        if(dimensionInterface == null) { return; }
        dimensionInterface.SwitchTriggered(name);
    }

    public void FoundNote(Note note)
    {
        //print("GOUND");
        noteFoundUI.SetActive(true);
        dimensionInterface.FoundNote(note);
    }

    public List<Note> CreateNotes()
    {
        List<Note> notes = CreateNoteListCopy(game.GetNotes()); //Dont effect the base data, otherwise reset wont reset notes

        return notes;
    }

    private void ConnectNotesToGameObjects(List<Note> notes) //Link list to in scene objects
    {
        GameObject[] noteLocations = GameObject.FindGameObjectsWithTag("NoteLocation");
        NoteInteract[] noteInteracts = new NoteInteract[noteLocations.Length];

        foreach (GameObject obj in noteLocations)
        {
            NoteInteract noteInteract = obj.GetComponent<NoteInteract>();

            if (noteInteract.GetNoteId() < 0 || noteInteract.GetNoteId() > noteLocations.Length - 1)
            {
                Debug.LogError("Note ID miss match");
            }
            else
            {
                noteInteracts[noteInteract.GetNoteId()] = noteInteract;
            }

        }

        foreach (Note nt in notes)
        {
            if (nt.ID > noteInteracts.Length - 1)
            {
                Debug.LogError("Note ID miss match");
            }
            else
            {
                noteInteracts[nt.ID].SetNote(nt);
                // nt.Title = "AAAAAAAAAAAAA"; Linking Test to see if old data changes
            }

        }

    }

    private List<Note> CreateNoteListCopy(List<Note> _notes)
    {
        List<Note> newNotes = new List<Note>();

        foreach(Note nt in _notes)
        {
            Note newNote = new Note();
            newNote.ID = nt.ID;
            newNote.Title = nt.Title;
            newNote.Collected = nt.Collected;
            newNote.Contents = nt.Contents;

            newNotes.Add(newNote);
        }

        return newNotes;
    }

    public List<Note> GetNotes()
    {
        return dimensionInterface.GetNotes();
    }

    public void ResetDimension() //TO-DO Add gift choice stat
    {
        dimensionInterface.ResetDimension();
        print("loading");
        PlayerPrefs.SetInt("Scene", SceneManager.GetActiveScene().buildIndex);
        SceneManager.LoadScene("LoadingScene");
    }

    public string GetDimensionName()
    {
        return game.GetDimensionName();
    }

    public void NextSong()
    {
        musicManager.NextSong();
    }
}
