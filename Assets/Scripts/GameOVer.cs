using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOVer : MonoBehaviour
{

    public TextMeshProUGUI roundsText;
    public sceneFader fader;
    public string menuSceneName = "MainMenu";
    

    private void OnEnable()
    {
        roundsText.color = Color.white;
        roundsText.text = PlayerStats.Rounds.ToString(); 
    }

    public void Retry()
    {
        fader.fadeTo(SceneManager.GetActiveScene().name);
    }

    public void Menu()
    {
        fader.fadeTo(menuSceneName);
        Debug.Log("Go to menu");
    }
    
    
}
