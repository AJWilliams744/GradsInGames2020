using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Video;

public class LoadScreenManager : MonoBehaviour
{
    [SerializeField] private VideoPlayer video;
    [SerializeField] private RawImage image;
    void Start()
    {
        StartCoroutine(FadeIn());
    }

    private IEnumerator FadeIn()
    {
        Color full = new Color(0, 0, 0, 1);
        Color hide = new Color(0, 0, 0, 0);

        for(float i = 0; i < 101; i++)
        {
           // print(i / 100);
            image.color = Color.Lerp(full, hide, i/100  );
            yield return new WaitForSeconds(0.02f);
        }

        yield return new WaitForSeconds(4f);

        for (float i = 0; i < 101; i++)
        {
           // print(i / 100);
            image.color = Color.Lerp(hide, full, i / 100);
            yield return new WaitForSeconds(0.02f);
        }

        SceneManager.LoadScene(PlayerPrefs.GetInt("Scene"));

    }
}
