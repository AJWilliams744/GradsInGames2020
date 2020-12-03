using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Manager : MonoBehaviour
{
    [SerializeField] private MonoBehaviour[] AllScriptsToDisable; //When player is disabled
    [SerializeField] private GameObject Camera;
    [SerializeField] private PlayerMovement playerMovement;

    private Game_Manager gm;

    private void Start()
    {
        gm = GameObject.FindGameObjectWithTag("GameManager").GetComponent<Game_Manager>();
    }

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

    public void MoveToLocation(Transform lookAtTransform, float speed)
    {
        StartCoroutine(MoveOverTime(lookAtTransform.position, speed));
    }

    private IEnumerator MoveOverTime(Vector3 newPos, float time) //TODO - Work out to rotate quaternion correctly
    {
        Vector3 originalPos = transform.position;       

        //Quaternion camXRot = Quaternion.Euler(new Vector3(Camera.transform.rotation.x, 0, 0));
        //Quaternion playerYRot = Quaternion.Euler(new Vector3(0, transform.eulerAngles.y, 0)); ;

        //Quaternion newX = Quaternion.Euler(new Vector3(newRot.eulerAngles.x,0,0));
        //Quaternion newY = Quaternion.Euler(new Vector3(0,newRot.eulerAngles.y, 0)); 

      
        float localTime = Time.deltaTime;

        while (localTime < time)
        {            
            transform.position = Vector3.Lerp(originalPos, newPos, localTime / time);
            //transform.rotation = Quaternion.Slerp(playerYRot, newY, localTime / time);

            //Camera.transform.rotation = Quaternion.Slerp(camXRot, newX, localTime / time);
            
            localTime += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "KillZone")
        {
            gm.PlayerDead();
        }

    }

    public void TeleportPlayer(Transform newLocation)
    {
        playerMovement.TeleportPlayer(newLocation);
    }
}
