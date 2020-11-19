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

    private Dimension dimensionInterface;

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

    public void StartLaptopInteract(Transform lookAtTransform)
    {
        playerManager.DisablePlayer();
        UIManager.SetInteractOnScreen(false);
        playerManager.MoveToLaptop(lookAtTransform);
        game.enabled = true;
    }   

    public void PlayerDead()
    {
        dimensionInterface.PlayerDead();
    }

    public void TeleportPlayer(Transform newLocation)
    {
        playerManager.TeleportPlayer(newLocation);
    }

   
}
