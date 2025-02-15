using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {

    public GameObject textGameObject;
    private int score;
    public bool paused = false;

    void Start () {
        score = 0;
        UpdateScore();
    }

    void Update () {     // always include a way to quit the game:
        if (Input.GetKey("escape")) {
            Pause();
        }
    }

    public void AddScore (int newScoreValue) {
        score += newScoreValue;
        UpdateScore ();
    }

    void UpdateScore () {
        Text scoreTextB = textGameObject.GetComponent<Text>();
        scoreTextB.text = "Score: " + score;
    }

    public void PlayAgain() {
        SceneManager.LoadScene("GameScene"); // REPLACE WITH GAME SCENE
        score = 0;
    }

    public void Pause() {
        SceneManager.LoadScene("pause_menu");
    }

    public void Resume() {
        SceneManager.LoadScene("GameScene");
    }

    public void QuitGame() {
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #else
            Application.Quit();
        #endif
    }
}
