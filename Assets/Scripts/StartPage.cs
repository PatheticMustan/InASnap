using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartPage : MonoBehaviour {
    public void PlayGame() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

    }

    public void QuitGame() {
        Application.Quit();
        Debug.Log("exited");
    }

    public void StartLvl() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}