using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaptopLightManager : MonoBehaviour
{
    [SerializeField] private GameObject laptopLight;

    public void SwitchOffLight()
    {
        laptopLight.SetActive(false);
    }

    public void SwitchOnLight()
    {
        laptopLight.SetActive(true);

    }
}
