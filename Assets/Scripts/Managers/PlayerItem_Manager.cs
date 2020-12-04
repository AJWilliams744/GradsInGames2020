using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerItem_Manager : MonoBehaviour
{
    [Tooltip("Leave blank if not starting Item")] 
    [SerializeField] private MonoBehaviour startingPlayerItem;
    private PlayerItem playerItem;

    [SerializeField] private GameObject HandJointLocation;

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

    private void RemoveCurrentItem()
    {
        foreach(Transform child in HandJointLocation.transform)
        {
            Destroy(child.gameObject);
        }
        playerItem = null;
    }

    public void AddItem(GameObject prefab)
    {
        RemoveCurrentItem();
        GameObject clone = Instantiate(prefab, HandJointLocation.transform);
        playerItem = clone.GetComponent<PlayerItem>();

    }

    public void RemoveGift()
    {
        playerItem = null;
        RemoveCurrentItem();
    }

}
