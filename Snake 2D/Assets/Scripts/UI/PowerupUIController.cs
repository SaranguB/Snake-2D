using UnityEngine;
using UnityEngine.UI;

public class PowerupUIController : MonoBehaviour
{
    [SerializeField] private GameObject EasterEggShield;
    private Image EasterEggShieldImage;

    [SerializeField] private GameObject ScoreBoost;
    private Image ScoreBoostImage;

    [SerializeField] private GameObject Bomb;
    private Image BombImage;


    private void Start()
    {
        EasterEggShieldImage = EasterEggShield. GetComponent<Image>();
        ScoreBoostImage = ScoreBoost.GetComponent<Image>();
        BombImage = Bomb.GetComponent<Image>();
    }
    public void PowerupActivated(string tag)
    {
        if (tag == "Shield")
        {
            ChangeActivatedColor(EasterEggShieldImage);
        } 
        if (tag == "Boost")
        {
            ChangeActivatedColor(ScoreBoostImage);
        }
        if (tag == "Bomb")
        {
            ChangeActivatedColor(BombImage);
        }
    }

    private void ChangeActivatedColor(Image image)
    {
       
        Color newColor = image.color;
        newColor.a = 1f;
        image.color = newColor;
    }

    public void PowerupDeactivated(string tag)
    {
        //Debug.Log("Called to de");

        if (tag == "Shield")
        {
            ChangeDeactivatedColor(EasterEggShieldImage);
        }
        if (tag == "Boost")
        {
            ChangeDeactivatedColor(ScoreBoostImage);
        }
        if (tag == "Bomb")
        {
            ChangeDeactivatedColor(BombImage);
        }
    }

    private void ChangeDeactivatedColor(Image image)
    {
       
        Color newColor = image.color;
        newColor.a = .5f;
        image.color = newColor;
    }
}
