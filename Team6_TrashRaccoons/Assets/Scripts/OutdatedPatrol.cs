using System.Collections;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Drawing;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements.Experimental;

public class PatrolDay : MonoBehaviour
{
    public float waitTime;
    public float speed;
    public GameObject[] path;
    private int size;
    private Vector3 currentPosition;
    private bool arrived;
    private int i;
    private Vector3 target;
    private bool patrol;
    private Vector3 facing;
    private bool ready;

    // Start is called before the first frame update
    void Start()
    {
        i = 0;
        size = path.Length;
        target = new Vector3(0f, 0f, 0f);
        patrol = true;
        arrived = false;
        ready = true;

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        currentPosition = gameObject.transform.position;
        if (patrol && ready)
        {
            target.z = path[i].transform.position.z;
            target.x = path[i].transform.position.x;
            transform.position = Vector3.MoveTowards(currentPosition, target, speed * Time.deltaTime);
            if(currentPosition == target)
            {
                arrived = true;
            }
            if(arrived)
            {
                //progress i++ or resets i; sets arrived to false
                if (i < (size - 1))
                {
                    i++;
                }
                else
                {
                    i = 0;
                }
                arrived = false;
                ready = false;
                StartCoroutine(Wait(waitTime));
            }
        }

        //this isn't smooth rotation after the waiting for some reason, fix target facing issue (has to do with current vs. target position)
        Vector3 newRot = Vector3.RotateTowards(transform.forward, target, 1 * Time.deltaTime, 0f);
        transform.rotation = Quaternion.LookRotation(target);
    }

    IEnumerator Wait(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        ready = true;
        
    }
}
