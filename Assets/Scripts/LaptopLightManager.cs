using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaptopLightManager : MonoBehaviour
{
    [SerializeField] private GameObject light;

    public void SwitchOffLight()
    {
        light.SetActive(false);
    }

    public void SwitchOnLight()
    {
        light.SetActive(true);

    }
}
