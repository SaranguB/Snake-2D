using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SettingsController : MonoBehaviour
{
    public GameObject settings;

    private static SettingsController instance;
    public GameState gameState = GameState.PLAY_MODE;
    public Button replayButton;
    public Button MenuButton;
    public static SettingsController Instance { get { return instance; } }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    private void Start()
    {
        replayButton.onClick.AddListener(ReloadScene);
        MenuButton.onClick.AddListener(MainLobby);
    }


    public void EnableSettings()
    {
        settings.SetActive(true);
        gameState = GameState.PAUSE_MODE;


    }

    public void DisableSettings()
    {
        settings.SetActive(false);
        gameState = GameState.PLAY_MODE;

    }

    public GameState GetGameState()
    {
        return gameState;
    }

    private void ReloadScene()
    {
        SoundManager.Instance.PlaySound(Sounds.BUTTON_CLCK);
        int currentScene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentScene);

    }

    private void MainLobby()
    {

        SoundManager.Instance.PlaySound(Sounds.BUTTON_CLCK);

        SceneManager.LoadScene(0);
    }
}
