using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(UI_Manager))]
public class Game_Manager : MonoBehaviour
{
    private UI_Manager UIManager;
    [SerializeField] private Player_Manager playerManager;
    // Start is called before the first frame update
    void Start()
    {
        UIManager = GetComponent<UI_Manager>();

    }

    public void SetUIInteractScreen(bool value)
    {
        UIManager.SetInteractOnScreen(value);
    }

    public void StartLaptopInteract()
    {
        playerManager.DisablePlayer();
        UIManager.SetInteractOnScreen(false);
        playerManager.MoveToLaptop();
    }   

   
}
