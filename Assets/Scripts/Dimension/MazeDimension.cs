using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MazeDimension : BaseDimension, Dimension
{
    [SerializeField] private GameObject gameAreaGate;
    [SerializeField] private GameObject gameArea;

    [SerializeField] private ZoneManager zoneManager;
    public override void  ChoiceSelected(GiftChoices choice)
    {
        base.ChoiceSelected(choice);
        gameAreaGate.SetActive(false);
        gameArea.SetActive(true);
    }

    public void LoadProgress()
    {
        DimensionStorage dimensionSave = GameSave_Manager.LoadDimension(dimensionName);

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

        if (hasGift) { GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerItem_Manager>().AddItem(giftPrefab);}

        gameArea.SetActive(true);

        zoneManager.TriggerZones(dimensionSave.currentCheckPoint);
        checkPointSystem.SetProgress(dimensionSave.currentCheckPoint);

        PlayerDead();

        gm.NextSong();

        SaveDimension(); //Create an empty location for player to return if quit;
    }
    public override void FoundNote(Note note)
    {
        base.FoundNote(note);
        SaveDimension();
    }

    public override void SaveDimension()
    {
        base.SaveDimension();

        int buildIndex = SceneManager.GetActiveScene().buildIndex;

        DimensionStorage gameFile = GameSave_Manager.CreateDimensionSaveGameObject(checkPointSystem.GetCurrentInt(), notes, isLevelCompleted, hasGift, buildIndex);

        GameSave_Manager.SaveDimension(gameFile, dimensionName);
    }

    public void NormalStart()
    {
        gameArea.SetActive(false);
    }

    public void SwitchTriggered(string name)
    {
        if(name == "WorldTree")
        {
            StartCoroutine(FadeGlobalLight(1, 0.1f, 3));
            return;
        }

        if (name == "END")
        {
            isLevelCompleted = true;
            SaveDimension();
            LoadNextScene();

        }
    }
}
