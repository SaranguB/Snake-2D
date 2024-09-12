using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverController : MonoBehaviour
{
    

    public Button replayButton;
    public Button MenuButton;

    
    private void Awake()
    {
        replayButton.onClick.AddListener(ReloadScene);
        MenuButton.onClick.AddListener(MainLobby);
    }

    private void MainLobby()
    {
        SceneManager.LoadScene(0);
    }

    private void ReloadScene()
    {
        int currentScene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentScene);

    }

    
}
