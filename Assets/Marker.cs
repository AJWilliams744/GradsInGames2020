using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Marker : MonoBehaviour, PlayerItem
{
    [SerializeField] private LayerMask decalLayerMask;
    [SerializeField] private GameObject decalPrefab;
    [SerializeField] private float decalRange = 20f;
    private GameObject[] allDecals;
    void PlayerItem.MainFire()
    {
        RaycastHit hit;
        // Does the ray intersect any objects excluding the player layer
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, decalRange, decalLayerMask))
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);
            Debug.Log("Did Hit"); //TO-DO Apply decal
        }
    }

    void PlayerItem.SecondaryFire()
    {
        
    }

}
