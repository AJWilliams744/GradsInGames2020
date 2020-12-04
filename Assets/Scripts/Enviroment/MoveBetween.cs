using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBetween : MonoBehaviour
{
    [SerializeField] private GameObject link1;
    [SerializeField] private GameObject link2;

    [Tooltip("Time taken to travel between both points")]
    [SerializeField] private float timeTaken;

    private void OnEnable()
    {
        StartMoving();
    }

    private void OnDisable()
    {
        StopMoving();
    }

    private IEnumerator Moving()
    {
        while (true)
        {
            for (float i = 0; i < timeTaken; i += Time.deltaTime)
            {
                gameObject.transform.position = Vector3.Lerp(link1.transform.position, link2.transform.position, i / timeTaken);
                yield return new WaitForEndOfFrame();
            }

            for (float i = 0; i < timeTaken; i += Time.deltaTime)
            {
                gameObject.transform.position = Vector3.Lerp(link2.transform.position, link1.transform.position, i / timeTaken);
                yield return new WaitForEndOfFrame();
            }

        }
    }

    public void StopMoving()
    {
        StopAllCoroutines();
    }

    public void StartMoving()
    {
        StartCoroutine(Moving());
    }
}
