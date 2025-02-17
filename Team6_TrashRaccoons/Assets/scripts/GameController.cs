using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {

    public static bool paused;
    public GameObject pauseMenuUI;
    

    void Start () {
        paused = false;
        pauseMenuUI.SetActive(false);
    }

    void Update () {     // always include a way to quit the game:
        if (Input.GetKeyDown(KeyCode.Escape)) {
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
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
    }

    public void Resume() {
        paused = false;
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
    }

    public void QuitGame() {
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #else
            Application.Quit();
        #endif
    }
}
