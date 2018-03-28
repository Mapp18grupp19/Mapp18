using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class Player {
    public Image panel;
    public Text text;
    public Button button;
}

[System.Serializable]
public class PlayerColor {
    public Color panelColor;
    public Color textColor;
}

public class GameController : MonoBehaviour {
    public Text[] buttonList;
    public GameObject startInfo;
    public GameObject gameOverPanel;
    public GameObject restartButton;
    public Text gameOverText;

    public Player playerX;
    public Player playerO;
    public PlayerColor activePlayerColor;
    public PlayerColor inactivePlayerColor;

    private string playerSide;
    private int moveCount;

    void Awake () {
        ResetBoard();
        SetGameControllerReferenceOnButtons();
    }

    void ResetBoard () {
        gameOverPanel.SetActive(false);
        restartButton.SetActive(false);
        moveCount = 0;
    }

    void SetGameControllerReferenceOnButtons () {
        for (int i = 0; i < buttonList.Length; i++) {
            buttonList[i].GetComponentInParent<GridSpace>().SetGameControllerReference(this);
        }
    }

    public void SetStartingSide(string startingSide) {
        playerSide = startingSide;
        if (playerSide == "X") {
            SetPlayerColors(playerX, playerO);
        }
        else {
            SetPlayerColors(playerO, playerX);
        }
        StartGame();
    }

    void StartGame () {
        SetBoardInteractable(true);
        SetPlayerButtons(false);
        startInfo.SetActive(false);
    }

    public string GetPlayerSide () {
        return playerSide;
    }

    public void EndTurn () {
        moveCount++;
        
        if (buttonList[0].text == playerSide && buttonList[1].text == playerSide && buttonList[2].text == playerSide) {
            GameOver(playerSide);
        }
        else if (buttonList[3].text == playerSide && buttonList[4].text == playerSide && buttonList[5].text == playerSide) {
            GameOver(playerSide);
        }

        else if (buttonList[6].text == playerSide && buttonList[7].text == playerSide && buttonList[8].text == playerSide) {
            GameOver(playerSide);
        }

        else if (buttonList[0].text == playerSide && buttonList[3].text == playerSide && buttonList[6].text == playerSide) {
            GameOver(playerSide);
        }

        else if (buttonList[1].text == playerSide && buttonList[4].text == playerSide && buttonList[7].text == playerSide) {
            GameOver(playerSide);
        }

        else if (buttonList[2].text == playerSide && buttonList[5].text == playerSide && buttonList[8].text == playerSide) {
            GameOver(playerSide);
        }

        else if (buttonList[0].text == playerSide && buttonList[4].text == playerSide && buttonList[8].text == playerSide) {
            GameOver(playerSide);
        }

        else if (buttonList[2].text == playerSide && buttonList[4].text == playerSide && buttonList[6].text == playerSide) {
            GameOver(playerSide);
        }
        else if (moveCount >= 9) {
            GameOver("draw");
        }
        else {
            ChangeSides();
        }
    }

    void ChangeSides () {
        if (playerSide == "X") {
            SetPlayerColors(playerO, playerX);
            playerSide = "O";
        }
        else {
            SetPlayerColors(playerX, playerO);
            playerSide = "X";
        }
    }

    void SetPlayerColors (Player newPlayer, Player oldPlayer) {
        newPlayer.panel.color = activePlayerColor.panelColor;
        newPlayer.text.color = activePlayerColor.textColor;
        oldPlayer.panel.color = inactivePlayerColor.panelColor;
        oldPlayer.text.color = inactivePlayerColor.textColor;
    }

    void SetGameOverText(string value) {
        gameOverText.text = value;
    }

    void GameOver (string winningPlayer) {
        if(winningPlayer == "draw") {
            SetPlayerColorsInactive();
            SetGameOverText("It's a draw!");
        }
        else {
            SetGameOverText(winningPlayer + " Wins!");
        }
        SetBoardInteractable(false);
        restartButton.SetActive(true);
        gameOverPanel.SetActive(true);
    }

    public void RestartGame () {
        for (int i = 0; i < buttonList.Length; i++) {
            buttonList[i].text = "";
        }
        SetPlayerButtons(true);
        SetPlayerColorsInactive();
        startInfo.SetActive(true);
        ResetBoard();
    }

    void SetBoardInteractable (bool toggle) {
        for (int i = 0; i < buttonList.Length; i++) {
            buttonList[i].GetComponentInParent<Button>().interactable = toggle;
        }
    }

    void SetPlayerColorsInactive () {
        playerX.panel.color = inactivePlayerColor.panelColor;
        playerX.text.color = inactivePlayerColor.textColor;
        playerO.panel.color = inactivePlayerColor.panelColor;
        playerO.text.color = inactivePlayerColor.textColor;
    }

    void SetPlayerButtons (bool toggle) {
        playerX.button.interactable = toggle;
        playerO.button.interactable = toggle;
    }
}


