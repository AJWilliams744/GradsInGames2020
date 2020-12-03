using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(UI_Manager))]
[RequireComponent(typeof(Dimension))]
public class Game_Manager : MonoBehaviour
{
    private UI_Manager UIManager;
    [SerializeField] private Game game;
    [SerializeField] private Player_Manager playerManager;
    [SerializeField] private GameObject laptop;

    private Dimension dimensionInterface;
    private Transform laptopReturnTransform;

    private delegate void methodPasser();


    private float laptopMoveSpeed = 2f;

    // Start is called before the first frame update
    void Start()
    {
        UIManager = GetComponent<UI_Manager>();
        dimensionInterface = GetComponent(typeof(Dimension)) as Dimension;
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



   
}
