using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {
    public int score = 0;

	void Update () {
		
	}

    public void FinishLevel () {
        int currentScene = SceneManager.GetActiveScene().buildIndex;
        int nextScene = 0;
        while(nextScene == currentScene)
            nextScene = Random.Range(0, 4);
        Debug.Log(nextScene);
        SceneManager.LoadScene(nextScene);
    }
}
