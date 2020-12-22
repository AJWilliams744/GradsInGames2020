using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteFound : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;
    private void OnEnable()
    {
        audioSource.PlayOneShot(audioSource.clip);
        StartCoroutine(waitToTurnOff());
    }

    private IEnumerator waitToTurnOff()
    {
        for(float i = 0; i < 3; i += Time.unscaledDeltaTime)
        {
            yield return new WaitForEndOfFrame();
        }
        gameObject.SetActive(false);
    }
}
