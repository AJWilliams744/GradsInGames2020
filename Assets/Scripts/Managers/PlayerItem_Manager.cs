using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerItem_Manager : MonoBehaviour
{
    [Tooltip("Leave blank if not starting Item")] 
    [SerializeField] private MonoBehaviour startingPlayerItem;
    private PlayerItem playerItem;

    private void Start()
    {
        if(startingPlayerItem != null)
        {
            if(startingPlayerItem is PlayerItem)
            {
                playerItem = startingPlayerItem as PlayerItem;
            }
            else
            {
                Debug.LogWarning("Start Item is not a Player Item");
            }
            
        }
        
    }
    public void ItemMainFire()
    {
        if( playerItem != null)
        {
            playerItem.MainFire();
        }       
    }

    public void ItemSecondaryFire()
    {
        if (playerItem != null)
        {
            playerItem.SecondaryFire();
        }            
    }

    public void SetPlayerItem(PlayerItem newItem)
    {
        playerItem = newItem;
    }

}
