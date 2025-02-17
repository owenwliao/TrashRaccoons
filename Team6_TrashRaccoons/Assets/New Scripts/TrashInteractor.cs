using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TrashInteractor : MonoBehaviour
{
    public TextMeshProUGUI ScoreText;
    public int TrashBagScore = 0;

    private float initialY = 1.13f;

    // Start is called before the first frame update
    void Start()
    {
        ScoreText.text = "Trash Score: " + TrashBagScore;        
    }

    //set mask to the mask of the object you
    //want to look at in the editor.

    void FixedUpdate()
    {
        if(Input.GetMouseButton(1))
        {
            RaycastHit hit;

            // if raycast hits, it checks if it hit an object with the tag Player
            if(Physics.Raycast(transform.position, transform.forward, out hit, 2) && hit.collider.gameObject.CompareTag("TrashCan"))
            {
                Debug.Log("TrashCan");
                hit.collider.gameObject.transform.position = new Vector3(hit.collider.gameObject.transform.position.x , initialY, hit.collider.gameObject.transform.position.z);
                hit.collider.gameObject.transform.rotation = Quaternion.Euler(-90f, 0.0f, hit.collider.gameObject.transform.rotation.z);
            }
        }

        if(Input.GetMouseButton(0))
        {
            Debug.Log("Mouse Clicked");
            RaycastHit hit;

            // if raycast hits, it checks if it hit an object with the tag Player
            if(Physics.Raycast(transform.position, transform.forward, out hit, 4) && hit.collider.gameObject.CompareTag("TrashBag"))
            {
                Debug.Log("TrashBag");
                Destroy(hit.collider.gameObject);
                TrashBagScore++;
                ScoreText.text = "Trash Score: " + TrashBagScore;
            }
        }
    }

}
