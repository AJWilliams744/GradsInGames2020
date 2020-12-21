using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndDimension : BaseDimension, Dimension
{
    [SerializeField] private StoryData badEnding;
    [SerializeField] private StoryData goodEnding;
    public void LoadProgress()
    {        
        gm.NextSong();

        SaveDimension(); //Create an empty location for player to return if quit;
    }

    public void NormalStart()
    {
       
    }

    public void SwitchTriggered(string name)
    {
        
    }

    public override void ChoiceSelected(GiftChoices choice)
    {
        
    }

    public override void SaveDimension()
    {
        int buildIndex = SceneManager.GetActiveScene().buildIndex;

        DimensionStorage gameFile = GameSave_Manager.CreateDimensionSaveGameObject(0, null, false, false, buildIndex);

        GameSave_Manager.SaveDimension(gameFile, dimensionName);
    }

    public void Start()
    {
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
    }

    private bool CheckForGoodEnding()
    {
        bool checkForGifts = false;

        List<string> dimensionNames = GameSave_Manager.GetAllDimensionNames();

        foreach(string dimensionName in dimensionNames)
        {
            DimensionStorage gameFile = GameSave_Manager.LoadDimension(dimensionName);
            if (hasGift) { checkForGifts = true; }
        }

        return !checkForGifts; //Gifts are evil
    }

}
