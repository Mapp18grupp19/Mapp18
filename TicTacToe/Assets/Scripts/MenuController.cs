using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour {

    public Animator animStart;
    public Animator animExit;

    public void StartGame () {
        animStart.SetTrigger("Play");
        Invoke("StartTheGame", 2f);
    }

    void StartTheGame () {
        SceneManager.LoadScene("Game");
    }

    public void ExitGame () {
        animExit.SetTrigger("Play");
        Invoke("Exit", 2f);
    }
    void Exit () {
        Application.Quit();
    }
}
