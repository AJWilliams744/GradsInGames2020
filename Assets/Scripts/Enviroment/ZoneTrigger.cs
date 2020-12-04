using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class ZoneTrigger : MonoBehaviour
{
    [Tooltip("Leave blank if no previous zone")]
    [SerializeField] GameObject previousZone;
    
    [SerializeField] AudioSource zoneAppearSource;
    [SerializeField] private GameObject[] stages;
    [SerializeField] private bool isDelayed = false;
    [SerializeField] private float delayTimmer = 1f;

    private bool triggered = false;

    private Dimension currentDimension;

    private void OnTriggerEnter(Collider other)
    {

        if (triggered) { return; }

        triggered = true;

        if(previousZone != null)
        {
            previousZone.SetActive(false);
        }
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
