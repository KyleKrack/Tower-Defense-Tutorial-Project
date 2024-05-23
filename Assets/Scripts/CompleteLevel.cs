using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CompleteLevel : MonoBehaviour
{
    public string nextLevel = "Level02";
    public int levelToUnlock = 2;
    
    public string menuSceneName = "MainMenu";
    
    public sceneFader fader;
    
    
    
    public void Continue()
    {
        PlayerPrefs.SetInt("levelReached", levelToUnlock);
        fader.fadeTo(nextLevel);
    }

    public void Menu()
    {
        fader.fadeTo(menuSceneName);
    }
    
}
