using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseDimension : MonoBehaviour
{
    protected Game_Manager gm;
    protected delegate void methodPasser();

    [SerializeField] protected GameObject giftPrefab;

    private void Awake()
    {
        gm = GetComponent<Game_Manager>();
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
}
