using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirectionChanger : MonoBehaviour
{
    private GameObject playerBody;
    private GameObject playerHead;

    // Start is called before the first frame update
    void Start()
    {
        playerBody = GameObject.Find("raccoon");   
        playerHead = GameObject.Find("FirstPersonCharacter");
    }

    // Update is called once per frame
    void Update()
    {
        // Set the rotation of the UI arrow to match the difference in rotation between the player's body and head
        transform.rotation = Quaternion.Euler(0, 0, (playerHead.transform.rotation.eulerAngles.y - playerBody.transform.rotation.eulerAngles.y)+90);

    }
}
