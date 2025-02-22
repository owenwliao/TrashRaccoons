using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TrashInteractor : MonoBehaviour
{
    public TextMeshProUGUI ScoreText;
    public TextMeshProUGUI DumpsterText;
    public int CurrentTrashBags = 0;
    private float initialY = 1.13f;

    // Start is called before the first frame update
    void Start()
    {
        ScoreText.text = "Trash Inventory: " + CurrentTrashBags;        
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
            if(Physics.Raycast(transform.position, transform.forward, out hit, 4) && hit.collider.gameObject.CompareTag("TrashBag") && CurrentTrashBags < 2)
            {
                Debug.Log("TrashBag");
                Destroy(hit.collider.gameObject);
                CurrentTrashBags++;

                if(CurrentTrashBags == 2)
                {
                    ScoreText.text = "Trash Inventory: " + CurrentTrashBags + " - Deliver to dumpster";
                }
                else
                {
                    ScoreText.text = "Trash Inventory: " + CurrentTrashBags;
                }
            }
        }

        RaycastHit hit2;

        // if raycast hits, it checks if it hit an object with the tag Dumpster
        if(Physics.Raycast(transform.position, transform.forward, out hit2, 2) && hit2.collider.gameObject.CompareTag("Dumpster"))
        {
            DumpsterText.text =  "Dumpster : " + hit2.collider.gameObject.GetComponent<DumpsterScript>().TrashBags;

            if(Input.GetMouseButton(0) && CurrentTrashBags > 0)
            {
                hit2.collider.gameObject.GetComponent<DumpsterScript>().TrashBags += CurrentTrashBags;
                Debug.Log("Dumpster");
                CurrentTrashBags = 0;
                ScoreText.text = "Trash Inventory: " + CurrentTrashBags;
            }
        }
        else
        {
            DumpsterText.text = "";
        }
    }

}
