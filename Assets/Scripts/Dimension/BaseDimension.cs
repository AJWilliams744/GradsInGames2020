using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Game_Manager))]
public class BaseDimension : MonoBehaviour
{
    [SerializeField] protected string dimensionName;

    protected Game_Manager gm;
    protected delegate void methodPasser();

    [SerializeField] protected GameObject giftPrefab;
    [SerializeField] private GameObject PauseMenu;

    protected bool isLevelCompleted;
    protected bool hasGift;
    protected List<Note> notes;

    private void Awake()
    {
        gm = GetComponent<Game_Manager>();

#if UNITY_EDITOR
        GameSave_Manager.DeleteDimension(dimensionName);
#endif
    }

    public string GetDimensionName()
    {
        return dimensionName;
    }

    protected IEnumerator WaitToTrigger(methodPasser[] methodsToCall, float time)
    {
        yield return new WaitForSeconds(time);

        foreach (methodPasser method in methodsToCall)
        {
            method?.Invoke(); // If not null
        }

    }

    public void RemoveGift()
    {
        GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerItem_Manager>().RemoveGift();
    }

    protected void LoadNextScene()
    {
        print("loading");
        PlayerPrefs.SetInt("Scene", SceneManager.GetActiveScene().buildIndex + 1);
        SceneManager.LoadScene("LoadingScene");
    }

    private void Update()
    {
#if UNITY_EDITOR
        if (Input.GetKeyDown(KeyCode.T))
        {
            PauseMenu.SetActive(!PauseMenu.activeSelf);
           
        }
#else
        if (Input.GetButtonDown("Cancel"))
        {
            PauseMenu.SetActive(!PauseMenu.activeSelf);
        }

#endif
    }

    public virtual void FoundNote(Note note)
    {
        foreach(Note storedNote in notes)
        {
            if(storedNote.ID == note.ID)
            {
                storedNote.Collected = true;

                print(note.Title); 
                //Save Game
                
            }
        }
    }

    protected Note FindNoteByID(int id)
    {        
        return notes.Find(b => b.ID == id); //Taken from finding beat data in story data script
        
    }

    public void LinkNotes(List<Note> _notes)
    {
        notes = _notes;
    }

    public List<Note> GetNotes()
    {
        return notes;
    }
 
}
