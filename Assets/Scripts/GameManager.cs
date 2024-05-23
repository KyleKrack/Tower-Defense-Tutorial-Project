using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public static bool GameIsOver = false;
    public GameObject gameOverUI;
    public GameObject completeLevelUI; 
    
    void Start()
    {
        GameIsOver = false; 
    }
    
    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown("e"))
        {
            EndGame();
        }
        
        if (GameIsOver)
            return; 
        if (PlayerStats.Lives <= 0)
        {
            EndGame();
        }
    }

    void EndGame()
    {
        GameIsOver = true; 
        
        gameOverUI.SetActive(true);
        Debug.Log("Game over!");
        return; 
    }

    public void WinLevel()
    {
        Debug.Log("LEVEL WON!");
        GameIsOver = true; 
        completeLevelUI.SetActive(true);
        
    }
    
    
    
}
