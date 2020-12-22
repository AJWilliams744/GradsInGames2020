using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class DarkDimension : BaseDimension, Dimension
{
    [SerializeField] private GameObject GameArea;
    [SerializeField] private float startFadeTime = 2;
    [SerializeField] private float endFadeTime = 10;

    [SerializeField] private ZoneManager zoneManager;


    public override void ChoiceSelected(GiftChoices choice)
    {
        base.ChoiceSelected(choice);

        GameArea.SetActive(true);
        StartCoroutine(FadeGlobalLight(1, 0, endFadeTime));
    }


    public void SwitchTriggered(string name)
    {
        methodPasser[] methods = new methodPasser[1];
        methods[0] = LoadNextScene;

        isLevelCompleted = true;
        SaveDimension();

        StartCoroutine(WaitToTrigger(methods, 6));
    }

    public void NormalStart()
    {
        GameArea.SetActive(false);
        StartCoroutine(FadeGlobalLight(0, 1, startFadeTime));
        SaveDimension();
    }

    public void LoadProgress()
    {
        DimensionStorage dimensionSave = GameSave_Manager.LoadDimension(dimensionName);

       // print(dimensionSave.notes.Count);

        //foreach (Note nt in dimensionSave.notes)
        //{
        //    print(nt.Collected);
        //}

        if (dimensionSave == null) { NormalStart(); return; }

        foreach (Note nt in dimensionSave.notes)
        {
            if (nt.Collected)
            {
                FindNoteByID(nt.ID).Collected = true;
            }
        }

        if (dimensionSave.currentCheckPoint == 0) { NormalStart(); return; } // Ignore origin check point (Has no zone)

        hasGift = dimensionSave.hasGift;

        if (hasGift) { GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerItem_Manager>().AddItem(giftPrefab); }

        GameArea.SetActive(true);

        zoneManager.TriggerZones(dimensionSave.currentCheckPoint);
        checkPointSystem.SetProgress(dimensionSave.currentCheckPoint);

        PlayerDead();

        gm.NextSong();

        SaveDimension(); //Create an empty location for player to return if quit;
    }

    public override void SaveDimension() //Save whenever something important happens
    {
        base.SaveDimension();

        int buildIndex = SceneManager.GetActiveScene().buildIndex;

        DimensionStorage gameFile = GameSave_Manager.CreateDimensionSaveGameObject(checkPointSystem.GetCurrentInt(), notes, isLevelCompleted, hasGift, buildIndex);

        //print(gameFile.notes.Count);

        //foreach (Note nt in gameFile.notes)
        //{
        //    print(nt.Collected);
        //}

        GameSave_Manager.SaveDimension(gameFile, dimensionName);
    }

    public override void FoundNote(Note note)
    {
        base.FoundNote(note);
        SaveDimension();
    }

}
