using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {

    public static bool paused;
    

    void Start () {
        paused = false;
    }

    void Update () {     // always include a way to quit the game:
        if (Input.GetKey("escape")) {
            if (paused) {
                Resume();
            } else {
                Pause();
            }
        }
    }

    public void PlayAgain() {
        SceneManager.LoadScene("Testing"); // REPLACE WITH GAME SCENE
    }

    public void Pause() {
        paused = true;
        SceneManager.LoadScene("pause_menu");
    }

    public void Resume() {
        paused = false;
        SceneManager.LoadScene("Testing"); // REPLACE WITH GAME SCENE
    }

    public void QuitGame() {
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #else
            Application.Quit();
        #endif
    }
}
