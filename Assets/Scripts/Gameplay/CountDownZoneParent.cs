using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CountDownZoneParent : MonoBehaviour
{
    private Game_Manager gameManager;

    private int currentTime;

    private Coroutine currentRoutine;

    [SerializeField] private int timmerStartValue;

    [SerializeField] private TMP_Text uiText;

    private IEnumerator CycleCountDown()
    {
        uiText.gameObject.SetActive(true);
        uiText.text = timmerStartValue.ToString();
        currentTime = timmerStartValue;

        while (true)
        {
            yield return new WaitForSeconds(1);
            currentTime -= 1;
            uiText.text = currentTime.ToString();

            if(currentTime <= 0)
            {
                gameManager.PlayerDead();
                uiText.gameObject.SetActive(false);
                StopAllCoroutines();
            }
        }
        
    }

    public void StartCountDown()
    {
        if(currentRoutine != null) { return; }
        currentRoutine = StartCoroutine(CycleCountDown());
    }

    public void StopCountDown()
    {
        StopAllCoroutines();
        currentRoutine = null;
        uiText.gameObject.SetActive(false);
    }

    private void Start()
    {
        uiText.gameObject.SetActive(false);
        gameManager = StaticClasses.GetGameManager();
    }
}
