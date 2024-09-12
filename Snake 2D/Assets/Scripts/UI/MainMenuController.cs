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
        SoundManager.Instance.PlaySound(Sounds.BUTTON_CLCK);
        SceneManager.LoadScene(2); 
    }

    private void PlaySinglePlayer()
    {

        SoundManager.Instance.PlaySound(Sounds.BUTTON_CLCK);
        SceneManager.LoadScene(1);
    }
}
