using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Manager : MonoBehaviour
{
    [SerializeField] private MonoBehaviour[] AllScriptsToDisable; //When player is disabled

    public void DisablePlayer()
    {
        UpdateAllScripts(false);
    }

    public void EnablePlayer()
    {
        UpdateAllScripts(true);
    }

    private void UpdateAllScripts(bool value)
    {
        foreach (MonoBehaviour script in AllScriptsToDisable)
        {
            script.enabled = value;
        }
    }

    public void MoveToLaptop()
    {
        StartCoroutine(MoveOverTime(new Vector3(0, 0, 0), new Vector3(0, 0, 0), 5f));
    }

    private IEnumerator MoveOverTime(Vector3 newPos, Vector3 newRot, float time)
    {
        Vector3 originalPos = transform.position;
        Vector3 originalRot = transform.rotation.eulerAngles;

        float localTime = Time.deltaTime;

        while (localTime < time)
        {            
            transform.position = Vector3.Lerp(originalPos, newPos, localTime / time);
            localTime += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
    }
}
