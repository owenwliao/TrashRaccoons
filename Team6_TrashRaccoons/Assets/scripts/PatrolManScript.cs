using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PatrolManScript : MonoBehaviour
{
    

    // Update is called once per frame
    void Update()
    {
        DrawCircle();
        
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

    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            SceneManager.LoadScene("DeathScene");
        }
    }

    void DrawCircle()
    {
        //Draw a circle around the patroller to show how far they can see
        float radius = 6.0f;
        int numSegments = 100;
        LineRenderer line = gameObject.GetComponent<LineRenderer>();
        line.positionCount = numSegments + 1;
        line.useWorldSpace = false;
        float deltaTheta = (float)(2.0 * Mathf.PI) / numSegments;
        float theta = 0f;

        //Change thickness of line
        line.startWidth = 0.1f;
        line.endWidth = 0.1f;

        //change color of line
        line.startColor = Color.blue;
        line.endColor = Color.blue;

        for (int i = 0; i < numSegments + 1; i++)
        {
            float x = radius * Mathf.Cos(theta);
            float z = radius * Mathf.Sin(theta);
            Vector3 pos = new Vector3(x, 0.5f, z);
            line.SetPosition(i, pos);
            theta += deltaTheta;
        }


    }
}
