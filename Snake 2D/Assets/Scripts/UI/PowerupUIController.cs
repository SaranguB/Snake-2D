using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PowerupUIController : MonoBehaviour
{
    public GameObject EasterEggShield;
    private Image EasterEggShieldImage;
  
    public GameObject ScoreBoost;
    private Image ScoreBoostImage;

    public GameObject Bomb;
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
