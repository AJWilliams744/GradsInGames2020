using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndDimension : BaseDimension, Dimension
{
    [SerializeField] private StoryData badEnding;
    [SerializeField] private StoryData goodEnding;

    [SerializeField] private GameObject endNote;
    public void LoadProgress()
    {    
       
    }

    public void NormalStart()
    {
       
    }

    public void SwitchTriggered(string name)
    {
        
    }

    public override void ChoiceSelected(GiftChoices choice)
    {
        print("HERE");
        endNote.SetActive(true);
        StartCoroutine(WaitToTravel());
    }

    private IEnumerator WaitToTravel()
    {
        for(float i=0; i < 30; i += Time.deltaTime)
        {
            yield return new WaitForEndOfFrame();
        }
        print("loading");
        PlayerPrefs.SetInt("Scene", 0);

        SceneManager.LoadScene("LoadingScene");
    }

    public override void SaveDimension()
    {
        base.SaveDimension();

        int buildIndex = SceneManager.GetActiveScene().buildIndex;

        DimensionStorage gameFile = GameSave_Manager.CreateDimensionSaveGameObject(0, notes, false, false, buildIndex);

        GameSave_Manager.SaveDimension(gameFile, dimensionName);
    }

    public void Start()
    {
        endNote.SetActive(false);
        StoryData currentStory;

        if (CheckForGoodEnding())
        {
            currentStory = goodEnding;
        }
        else
        {
            currentStory = badEnding;
        }

        gm.GetGame().SetStoryData(currentStory);
        SaveDimension(); //Create an empty location for player to return if quit;
    }

    private bool CheckForGoodEnding()
    {
        bool checkForGifts = false;

        List<string> dimensionNames = GameSave_Manager.GetAllDimensionNames();

        foreach(string dimensionName in dimensionNames)
        {
            DimensionStorage gameFile = GameSave_Manager.LoadDimension(dimensionName);
            if (gameFile.hasGift) { checkForGifts = true; }
        }

        //return false;
        return !checkForGifts; //Gifts are evil
    }

}
