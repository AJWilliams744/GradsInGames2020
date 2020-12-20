using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeDimension : BaseDimension, Dimension
{
    [SerializeField] private GameObject gameAreaGate;
    [SerializeField] private GameObject gameArea;
    public override void  ChoiceSelected(GiftChoices choice)
    {
        base.ChoiceSelected(choice);
        gameAreaGate.SetActive(false);
        gameArea.SetActive(true);
    }

    public void LoadProgress()
    {
       
    }

    public void NormalStart()
    {
        
    }

    public void SwitchTriggered(string name)
    {
        
    }

    private void Start()
    {
        gameArea.SetActive(false);
    }

}
