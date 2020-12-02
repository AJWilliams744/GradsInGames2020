using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerExtraControls : MonoBehaviour
{
    [SerializeField] private PlayerItem_Manager itemManager;
    // Start is called before the first frame update

    private void Update()
    {
        if (Input.GetButtonDown("MainFire"))
        {
            itemManager.ItemMainFire();
        }
        if (Input.GetButtonDown("SecondaryFire"))
        {
            itemManager.ItemSecondaryFire();
        }
    }


}
