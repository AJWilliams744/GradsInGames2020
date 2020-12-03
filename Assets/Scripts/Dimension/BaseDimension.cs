using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseDimension : MonoBehaviour
{
    protected Game_Manager gm;

    [SerializeField] protected GameObject giftPrefab;

    private void Awake()
    {
        gm = GetComponent<Game_Manager>();
    }
}
