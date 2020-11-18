using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Manager : MonoBehaviour
{
    [SerializeField] GameObject InteractGroup;
    public void SetInteractOnScreen(bool value)
    {
        InteractGroup.SetActive(value);
    }

    private void Start()
    {
        InteractGroup.SetActive(false);
    }
}
