using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrollerMove : MonoBehaviour
{
    Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        anim = gameObject.GetComponentInChildren<Animator>();
        Walking();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Walking()
    {
        anim.SetBool("walk", true);
    }

    void Idle()
    {
        anim.SetBool("walk", false);
    }
}
