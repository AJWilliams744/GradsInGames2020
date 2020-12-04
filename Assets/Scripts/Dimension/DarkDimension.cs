using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Game_Manager))]
public class DarkDimension : BaseDimension, Dimension
{
    [SerializeField] private CheckPointSystem checkPointSystem;

    [SerializeField] private GameObject GameArea;
    [SerializeField] private Light globalLight;

    [SerializeField] private float startFadeTime = 2;
    [SerializeField] private float endFadeTime = 10;

    public void PlayerDead()
    {
        gm.TeleportPlayer(checkPointSystem.GetCurrentCheckLocation());
    }

    public void NextCheckPoint()
    {
        checkPointSystem.TriggerNextPoint();
    }

    public void ChoiceSelected(GiftChoices choice)
    {
        switch (choice)
        {
            case GiftChoices.Take:

                if(giftPrefab.tag == "PlayerItemGift")
                {
                    GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerItem_Manager>().AddItem(giftPrefab);
                } //TO-DO create world gift items
               
                break;

            case GiftChoices.Leave: //TO-DO Check save for completing with no gift
                break;

            default:
                break;
        }

        GameArea.SetActive(true);
        StartCoroutine(FadeGlobalLight(1, 0, endFadeTime));
    }

    private void Start()
    {
        GameArea.SetActive(false);
        StartCoroutine(FadeGlobalLight(0, 1, startFadeTime));
    }

    private IEnumerator FadeGlobalLight(float startIntensity, float endIntensity,float time)
    {
        globalLight.intensity = startIntensity;
        for(float i = 0; i < time; i += Time.deltaTime)
        {
            globalLight.intensity = Mathf.Lerp(startIntensity, endIntensity, i / time);
            yield return new WaitForEndOfFrame();
        }
        globalLight.intensity = endIntensity;

    }

    public void SwitchTriggered(string name)
    {
        methodPasser[] methods = new methodPasser[1];
        methods[0] = LoadNextScene;

        StartCoroutine(WaitToTrigger(methods, 6));
    }

    

    private void LoadNextScene()
    {
        print("loading");
        PlayerPrefs.SetInt("Scene", SceneManager.GetActiveScene().buildIndex + 1);
        SceneManager.LoadScene("LoadingScene");
    }

}
