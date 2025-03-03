using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameHandlerScript : MonoBehaviour
{
    public int threatLevel = 0;
    public TextMeshProUGUI ThreatLevelText;
    public TextMeshProUGUI TimerText;
    public float timerDuration = 300f; // 5 minutes

    private float timer;

    // Start is called before the first frame update
    void Start()
    {
        timer = timerDuration;
        ThreatLevelText.text = "Threat Level: " + threatLevel;
        UpdateTimerText();
    }

    // Update is called once per frame
    void Update()
    {
        ThreatLevelText.text = "Threat Level: " + threatLevel;

        if (threatLevel >= 10)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            SceneManager.LoadScene("GameOverScene");
        }

        if (timer > 0)
        {
            timer -= Time.deltaTime;
            if (timer <= 0)
            {
                timer = 0;
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
                SceneManager.LoadScene("TimeOutScene"); 
            }
            UpdateTimerText();
        }
    }

    void UpdateTimerText()
    {
        int minutes = Mathf.FloorToInt(timer / 60);
        int seconds = Mathf.FloorToInt(timer % 60);
        TimerText.text = string.Format("Time left: {0:00}:{1:00}", minutes, seconds);
    }
}
