using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashPlatformScript : MonoBehaviour
{
    public bool hasTrash;
    // Start is called before the first frame update
    void Start()
    {
        hasTrash = false;
        
    }

    void Update()
    {
        hasTrash=false;
        Collider[] hitColliders = Physics.OverlapBox(transform.position, transform.localScale / 2, Quaternion.identity);

        if (hitColliders.Length > 0)
        {
            foreach (var hitCollider in hitColliders)
            {
                if (hitCollider.gameObject.CompareTag("TrashCan"))
                {
                    hasTrash = true;
                }
            }
        }

        if (hasTrash)
        {
            GetComponent<Renderer>().material.color = Color.green;
        }
        else
        {
            GetComponent<Renderer>().material.color = Color.red;
        }

    }
}
