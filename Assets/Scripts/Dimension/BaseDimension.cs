using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BaseDimension : MonoBehaviour
{
    [SerializeField] protected string dimensionName;

    protected Game_Manager gm;
    protected delegate void methodPasser();

    [SerializeField] protected GameObject giftPrefab;
    [SerializeField] private GameObject PauseMenu;

    protected bool isLevelCompleted;
    protected bool hasGift;
    protected Note[] notes;

    private void Awake()
    {
        gm = GetComponent<Game_Manager>();
    }

    public string GetDimensionName()
    {
        return dimensionName;
    }

    protected IEnumerator WaitToTrigger(methodPasser[] methodsToCall, float time)
    {
        yield return new WaitForSeconds(time);

        foreach (methodPasser method in methodsToCall)
        {
            method?.Invoke(); // If not null
        }

        // methodToCall();
    }

    public void RemoveGift()
    {
        GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerItem_Manager>().RemoveGift();
    }

    protected void LoadNextScene()
    {
        print("loading");
        PlayerPrefs.SetInt("Scene", SceneManager.GetActiveScene().buildIndex + 1);
        SceneManager.LoadScene("LoadingScene");
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            PauseMenu.SetActive(true);
        }
    }

 
}
