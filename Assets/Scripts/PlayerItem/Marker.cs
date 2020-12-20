using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Marker : MonoBehaviour, PlayerItem
{
    [SerializeField] private LayerMask decalLayerMask;
    [SerializeField] private GameObject decalPrefab;
    [SerializeField] private float decalRange = 20f;

    [SerializeField] private int maxDecalCount = 20;

    private GameObject[] allDecals;

    private int currentDecalIndex = 0;

    private GameObject mainCamera;
    void PlayerItem.MainFire()
    {
        RaycastHit hit;
        // Does the ray intersect any objects excluding the player layer
        if (Physics.Raycast(mainCamera.transform.position, mainCamera.transform.forward, out hit, decalRange, decalLayerMask))
        {
            // Original image is rotated y 90, this fixes that
            Vector3 angle = new Vector3(hit.normal.x, decalPrefab.transform.eulerAngles.y, Quaternion.Euler(hit.normal).z); 

            Debug.DrawRay(mainCamera.transform.position, mainCamera.transform.forward * 500, Color.yellow);

            GameObject aDecal = Instantiate(decalPrefab, (hit.point + hit.normal * 0.1f), Quaternion.Euler(angle));

            HandleDecalCount(aDecal);
        }
    }

    private void HandleDecalCount(GameObject newDecal)
    {
        if(currentDecalIndex >= maxDecalCount - 1)
        {
            currentDecalIndex = 0;
        }       
        
        currentDecalIndex += 1;

        if(allDecals[currentDecalIndex] == null) //If first cycle just add the decal
        {
            allDecals[currentDecalIndex] = newDecal;
        }
        else //if not cycle destroy old decal and replace with new one
        {
            Destroy(allDecals[currentDecalIndex]);
            allDecals[currentDecalIndex] = newDecal;
        }            
        
    }

    void PlayerItem.SecondaryFire()
    {
        for (int i = 0; i < maxDecalCount; i++)
        {
            if (allDecals[i] != null) { Destroy(allDecals[i]); }
        }
    }

    private void Start()
    {
        mainCamera = GameObject.FindGameObjectWithTag("MainCamera");
        allDecals = new GameObject[20];
    }

}
