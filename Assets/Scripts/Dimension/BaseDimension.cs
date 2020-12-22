using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Game_Manager))]
public class BaseDimension : MonoBehaviour
{
    protected string dimensionName;

    protected Game_Manager gm;
    protected delegate void methodPasser();
    [SerializeField] protected CheckPointSystem checkPointSystem;
    [SerializeField] protected GameObject giftPrefab;
    [SerializeField] private GameObject PauseMenu;
    [SerializeField] private Light globalLight;
    protected bool isLevelCompleted;
    protected bool hasGift;
    protected List<Note> notes;

    [SerializeField] private GameObject savingText;

    private Coroutine showSavingCoroutine;

    private void Awake()
    {
        if(gm == null) { GetGameManager(); }
       
    }

    private void GetGameManager()
    {
        gm = GetComponent<Game_Manager>();

        dimensionName = gm.GetDimensionName();

#if UNITY_EDITOR
        // GameSave_Manager.DeleteDimension(dimensionName);
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


    protected IEnumerator FadeGlobalLight(float startIntensity, float endIntensity, float time)
    {
        globalLight.intensity = startIntensity;
        for (float i = 0; i < time; i += Time.deltaTime)
        {
            globalLight.intensity = Mathf.Lerp(startIntensity, endIntensity, i / time);
            yield return new WaitForEndOfFrame();
        }
        globalLight.intensity = endIntensity;

    }

    public virtual void ChoiceSelected(GiftChoices choice)
    {
        switch (choice)
        {
            case GiftChoices.Take:

                if (giftPrefab.tag == "PlayerItemGift")
                {
                    GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerItem_Manager>().AddItem(giftPrefab);

                } //TO-DO create world gift items
                hasGift = true;
                break;

            case GiftChoices.Leave: //TO-DO Check save for completing with no gift
                break;

            default:
                break;
        }

    }

    public void PlayerDead()
    {
        gm.TeleportPlayer(checkPointSystem.GetCurrentCheckLocation());
    }


    public void RemoveGift()
    {
        GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerItem_Manager>().RemoveGift();
    }

    protected void LoadNextScene()
    {
        print("loading");
        PlayerPrefs.SetInt("Scene", SceneManager.GetActiveScene().buildIndex + 1);

        //PlayerPrefs.SetInt("Scene", 0);
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

    public void ResetDimension()
    {
        GameSave_Manager.DeleteDimension(dimensionName);
    }

    public virtual void SaveDimension() //Save whenever something important happens
    {
        if (gm == null) { GetGameManager(); }

        StartCoroutine(ShowSavingText());
        
        print(dimensionName);
        //int buildIndex = SceneManager.GetActiveScene().buildIndex;

        //DimensionStorage gameFile = GameSave_Manager.CreateDimensionSaveGameObject(0, notes, isLevelCompleted, hasGift, buildIndex);

        //GameSave_Manager.SaveDimension(gameFile, dimensionName);
    }

    public void NextCheckPoint()
    {
        checkPointSystem.TriggerNextPoint();
        SaveDimension();
    }

    private IEnumerator ShowSavingText()
    {
        savingText.SetActive(true);
        for (float i = 0; i < 4; i += Time.unscaledDeltaTime) //Should dissapear on pause menu
        {
            yield return new WaitForEndOfFrame();
        }
        savingText.SetActive(false);
    }

}
