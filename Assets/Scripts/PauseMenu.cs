using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject UI;
    
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.P))
        {
            TogglePause();
        }
    }



    public void TogglePause()
    {
        UI.SetActive( !UI.activeSelf);

        if (UI.activeSelf)
        {
            Time.timeScale = 0f; 
        }
        else
        {
            Time.timeScale = 1; 
        }
    }

    public void Retry()
    {
        TogglePause();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); 
    }

    public void Menu()
    {
        Debug.Log("go to menu");
    }
    
    
}
