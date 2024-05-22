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

    private void OnEnable()
    {
        roundsText.color = Color.white;
        roundsText.text = PlayerStats.Rounds.ToString(); 
    }

    public void Retry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); 
    }

    public void Menu()
    {
        Debug.Log("Go to menu");
    }
    
    
}
