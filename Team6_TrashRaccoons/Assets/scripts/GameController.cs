using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Unity.VisualScripting;

public class GameController : MonoBehaviour {

    public static bool paused;
    public GameObject pauseMenuUI;
    private Scene scene;


    void Start () {
        paused = false;
        pauseMenuUI.SetActive(false);
        scene = SceneManager.GetActiveScene();
    }

    void Update() {     // always include a way to quit the game:
        if (scene.name != "MainMenu" && scene.name != "Credits" && scene.name != "DeathScene")
        {
            if (Input.GetKeyDown(KeyCode.Escape)) {
                if (paused) {
                    Resume();
                } else {
                    Pause();
                }
            }
        }
        if (scene.name == "MainMenu" || scene.name == "Credits" || scene.name == "DeathScene")
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
    }

    public void PlayAgain() {
        SceneManager.LoadScene("Level1"); // REPLACE WITH GAME SCENE
    }

    public void Credits() {
        SceneManager.LoadScene("Credits");
    }

    public void MainMenu() {
        SceneManager.LoadScene("MainMenu");
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
