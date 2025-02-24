using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolManScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            if(GameObject.Find("FirstPersonCharacter").GetComponent<TrashInteractor>().CurrentTrashBags > 0)
            {
                transform.parent.GetComponent<PatrolHandlerScript>().isFollowingPlayer = true;
            }
        }
    }
}
