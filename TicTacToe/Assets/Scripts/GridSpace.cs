using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GridSpace : MonoBehaviour {
	public Button button;
	public Text buttonText;

    private GameController gameController;
    public void SetGameControllerReference (GameController gameController) {
        this.gameController = gameController;
    }

    public void SetSpace () {
		buttonText.text = gameController.GetPlayerSide();
		button.interactable = false;
        gameController.EndTurn();
	}
}
