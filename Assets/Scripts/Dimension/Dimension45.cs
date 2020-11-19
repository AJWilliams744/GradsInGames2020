using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Game_Manager))]
public class Dimension45 : MonoBehaviour, Dimension
{
    [SerializeField] private CheckPointSystem checkPointSystem;
    private Game_Manager gm;

    private void Awake()
    {
        gm = GetComponent<Game_Manager>();
    }

    public void PlayerDead()
    {
        gm.TeleportPlayer(checkPointSystem.GetCurrentCheckLocation());
    }
}
