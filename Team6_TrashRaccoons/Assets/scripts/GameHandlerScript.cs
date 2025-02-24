using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameHandlerScript : MonoBehaviour
{
    public int threatLevel = 0;

    public TextMeshProUGUI ThreatLevelText;
    // Start is called before the first frame update
    void Start()
    {
        ThreatLevelText.text = "Threat Level: " + threatLevel;
    }

    // Update is called once per frame
    void Update()
    {
        ThreatLevelText.text = "Threat Level: " + threatLevel;
    }
}
