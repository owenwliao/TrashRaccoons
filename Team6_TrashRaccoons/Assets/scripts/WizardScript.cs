using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using TMPro;

public class WizardScript : MonoBehaviour
{

    public TextMeshProUGUI WizardText;

    // Start is called before the first frame update
    void Start()
    {
        WizardText = GameObject.Find("WizardText").GetComponent<TextMeshProUGUI>();
        WizardText.text = "Hello, I am the Wizard! I will guide you through this experience";
        
    }

    // Update is called once per frame
    void Update()
    {
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            if(gameObject.name == "Movement"){
                WizardText.text = "Use the WASD keys to move around, Q and E to rotate the bottom raccoon, and mouse to look around. You may also press shift to run.";
            }
            if(gameObject.name == "Enemy"){
                WizardText.text = "You may notice a patrolman, If he catches you, you will lose. If you have trash, he will follow you once you enter his radius! He also notices when a trash can has moved, so stay aware of the threat level.";
            }
            if(gameObject.name == "Trash Interactions"){
                WizardText.text = "Knock over trash cans to collect trash bags, you can hold up to 2 bags at a time! Left click to take a bag when you are looking at it. Right click to pick the can back up to put it back on its pedestal";
            }
            if(gameObject.name == "Dumpster Interactions"){
                WizardText.text = "Left click to place bags in the dumpster, when you put one in, you can move onto the first level!";
            }
        }
    }
}
