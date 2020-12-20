using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Marker : MonoBehaviour, PlayerItem
{
    [SerializeField] private LayerMask decalLayerMask;
    [SerializeField] private GameObject decalPrefab;
    [SerializeField] private float decalRange = 20f;
    private GameObject[] allDecals;

    private GameObject mainCamera;
    void PlayerItem.MainFire()
    {
        RaycastHit hit;
        // Does the ray intersect any objects excluding the player layer
        if (Physics.Raycast(mainCamera.transform.position, mainCamera.transform.forward, out hit, decalRange, decalLayerMask))
        {

            Vector3 angle = new Vector3(hit.normal.x, decalPrefab.transform.eulerAngles.y, Quaternion.Euler(hit.normal).z); // Original image is rotated y 90, this fixes that

            Debug.DrawRay(mainCamera.transform.position, mainCamera.transform.forward * 500, Color.yellow);
            Instantiate(decalPrefab, (hit.point + hit.normal * 0.1f), Quaternion.Euler(angle));
        }
    }

    void PlayerItem.SecondaryFire()
    {
        
    }

    private void Start()
    {
        mainCamera = GameObject.FindGameObjectWithTag("MainCamera");
        
    }

}
