using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoneTrigger : MonoBehaviour
{
    [SerializeField] AudioSource zoneAppearSource;
    [SerializeField] private GameObject[] stages;
    [SerializeField] private bool isDelayed = false;
    [SerializeField] private float delayTimmer = 1f;

    private Dimension currentDimension;

    private void OnTriggerEnter(Collider other)
    {
        currentDimension.NextCheckPoint();

        if (isDelayed)
        {
            StartCoroutine(DelayedTrigger());
        }
        else
        {
            foreach(GameObject gm in stages)
            {
                gm.SetActive(true);
                zoneAppearSource.PlayOneShot(zoneAppearSource.clip);
            }
            Destroy(this);
        }
    }

    private IEnumerator DelayedTrigger()
    {
        foreach (GameObject gm in stages)
        {
            zoneAppearSource.PlayOneShot(zoneAppearSource.clip);
            gm.SetActive(true);
            yield return new WaitForSeconds(delayTimmer);
        }
        Destroy(this);
        
    }

    private void Awake()
    {
        foreach (GameObject gm in stages)
        {
            gm.SetActive(false);
        }
    }

    private void Start()
    {
        currentDimension = GameObject.FindGameObjectWithTag("GameManager").GetComponent<Dimension>();
    }

}
