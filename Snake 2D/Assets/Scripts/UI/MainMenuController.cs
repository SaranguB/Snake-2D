using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuController : MonoBehaviour
{  

    public Button SinglePlayerButton;
    public Button coopButton;
    public Button quitButton;

    private void Awake()
    {
        SinglePlayerButton.onClick.AddListener(PlaySinglePlayer);
        coopButton.onClick.AddListener(PlayCOOPButton);
        quitButton.onClick.AddListener(QuitGame);
    }

    private void QuitGame()
    {
        Application.Quit();
    }

    private void PlayCOOPButton()
    {
        SceneManager.LoadScene(2); 
    }

    private void PlaySinglePlayer()
    {
        SceneManager.LoadScene(1);
    }
}
