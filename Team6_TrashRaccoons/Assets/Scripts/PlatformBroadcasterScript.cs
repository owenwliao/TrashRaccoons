using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformBroadcasterScript : MonoBehaviour
{

    public bool broadcastingTrash = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       broadcastingTrash = transform.Find("Platform").GetComponent<TrashPlatformScript>().hasTrash;   

    }

    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("DayPatrol"))
        {
            if(!broadcastingTrash)
            {
                GameObject.Find("GameHandler").GetComponent<GameHandlerScript>().threatLevel++;
            }
        }
    }
}
