using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolHandlerScript : MonoBehaviour
{
    public Transform[] patrolPoints;
    public float speed;
    private int currentPoint;
    private Transform patrolMan;
    public bool isFollowingPlayer = false;


    // Start is called before the first frame update
    void Start()
    {
        patrolMan = transform.GetChild(0);

        patrolPoints = new Transform[transform.childCount-1];
        for (int i = 0; i < transform.childCount-1; i++)
        {
            patrolPoints[i] = transform.GetChild(i+1);
        }

        patrolMan.position = patrolPoints[0].position;
        currentPoint = 0;   
        speed = 3.0f;
    }

    // Update is called once per frame
    void Update()
    {
        if(isFollowingPlayer)
        {
            patrolMan.transform.rotation = Quaternion.Slerp(patrolMan.transform.rotation, Quaternion.LookRotation(GameObject.FindGameObjectWithTag("Player").transform.position - patrolMan.position), speed*Time.deltaTime);
            patrolMan.position = Vector3.MoveTowards(patrolMan.position, GameObject.FindGameObjectWithTag("Player").transform.position, speed * Time.deltaTime);
            patrolMan.position = new Vector3(patrolMan.position.x, 0, patrolMan.position.z);
        }
        else{
            Patrol();
        }

        if(Vector3.Distance(GameObject.FindGameObjectWithTag("Player").transform.position, patrolMan.position) > 25)
        {
            isFollowingPlayer = false;
        }
    }

    void Patrol()
    {

        if (patrolMan.position == patrolPoints[currentPoint].position)
        {
            currentPoint++;
            if (currentPoint >= patrolPoints.Length)
            {
                currentPoint = 0;
            }

        }
        patrolMan.transform.rotation = Quaternion.Slerp(patrolMan.transform.rotation, Quaternion.LookRotation(patrolPoints[currentPoint].position - patrolMan.position), speed*Time.deltaTime);
        patrolMan.position = Vector3.MoveTowards(patrolMan.position, patrolPoints[currentPoint].position, speed * Time.deltaTime);
    }


}
