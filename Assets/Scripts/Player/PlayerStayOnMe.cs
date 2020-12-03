using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStayOnMe : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        print("ON");
        if(other.tag == "Player")
        {
            print("IN");
            other.transform.parent = transform.parent;
        }
        
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            other.transform.parent = null;
        }
    }
}
