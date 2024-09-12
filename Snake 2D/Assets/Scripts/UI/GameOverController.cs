

using UnityEngine;

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
        SoundManager.Instance.PlayMusic(Sounds.MUSIC);
        SoundManager.Instance.PlaySound(Sounds.BUTTON_CLCK);
        SceneManager.LoadScene(0);
    }

    private void ReloadScene()
    {

        SoundManager.Instance.PlaySound(Sounds.BUTTON_CLCK);
        SoundManager.Instance.PlayMusic(Sounds.MUSIC);

        int currentScene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentScene);

    }

    
}
