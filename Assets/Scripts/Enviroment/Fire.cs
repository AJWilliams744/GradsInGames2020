using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
    [SerializeField] private float minFireBrightness = 40;
    [SerializeField] private float maxFireBrightness = 80;
    [SerializeField] private float flickerSpeed = 0f;

    [SerializeField] private float minRandomRange = 0;
    [SerializeField] private float maxRandomRange = 1;

    [SerializeField] private Light flameLight;

    private void Start()
    {
        flameLight.intensity = maxFireBrightness;
        if(flickerSpeed != 0)
        {
            StartCoroutine(Flicker());
        }
        
    }

    private IEnumerator Flicker()
    {
        float midSpeed = flickerSpeed / 2;
        while (true)
        {
            float random = Random.Range(minRandomRange, maxRandomRange);
            for (float i = 0; i < midSpeed + random; i += Time.deltaTime)
            {
                flameLight.intensity = Mathf.Lerp(maxFireBrightness, minFireBrightness, i / (midSpeed + random));
                yield return new WaitForEndOfFrame();
            }

            random = Random.Range(minRandomRange, maxRandomRange);
            flameLight.intensity = minFireBrightness;
            for (float i = 0; i < midSpeed + random; i += Time.deltaTime)
            {
                flameLight.intensity = Mathf.Lerp(minFireBrightness, maxFireBrightness, i / (midSpeed + random));
                yield return new WaitForEndOfFrame();
            }
        }

    }

}
