using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 


public class MainMenu : MonoBehaviour
{
    public string levelToLoad = "MainLevel";

    public sceneFader SceneFader; 
    
    public void play()
    {
        Debug.Log("Play");
        //SceneManager.LoadScene(levelToLoad);
        SceneFader.fadeTo(levelToLoad);
    }

    public void Quit()
    {
        Debug.Log("Exiting");
        Application.Quit();
    }
    
}
