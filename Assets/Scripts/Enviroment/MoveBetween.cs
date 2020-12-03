using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBetween : MonoBehaviour
{
    [SerializeField] private GameObject link1;
    [SerializeField] private GameObject link2;

    [SerializeField] private float speed;

    private void OnEnable()
    {
        StartCoroutine(Moving());
    }

    private void OnDisable()
    {
        StopAllCoroutines();
    }

    private IEnumerator Moving()
    {
        while (true)
        {
            for (float i = 0; i < speed; i += Time.deltaTime)
            {
                gameObject.transform.position = Vector3.Lerp(link1.transform.position, link2.transform.position, i / speed);
                yield return new WaitForEndOfFrame();
            }

            for (float i = 0; i < speed; i += Time.deltaTime)
            {
                gameObject.transform.position = Vector3.Lerp(link2.transform.position, link1.transform.position, i / speed);
                yield return new WaitForEndOfFrame();
            }

        }
    }
}
