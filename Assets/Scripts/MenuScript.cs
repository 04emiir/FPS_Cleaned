using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour {
    // Start is called before the first frame update
    public bool paused;
    private void Start() {
        paused= false;
    }
    public void CloseGame() {
        Application.Quit();
    }

    public void LoadGame() {
        SceneManager.LoadScene("game");
    }

    public void PauseGame() {
        Time.timeScale = 0;
        paused=true;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

    }

    public void Unpause() {
        Time.timeScale = 1;
        paused=false;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public void ExitPlaying() {
        SceneManager.LoadScene("menu");
    }
}
