using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{

    public static int EnemiesAlive = 0;

    public Wave[] waves;

    public float timeBetweenWaves = 20.9f;

    private float countdown = 2f;

    private int waveIndex = 0;

    public GameManager gameManager; 

    public TextMeshProUGUI waveCountDownText; 

    public Transform spawnPoint; 
    private void Update()
    {
        if (EnemiesAlive > 0)
        {
            return; 
        }
        
        if (countdown <= 0f)
        {
            StartCoroutine(Spawnwave());
            countdown = timeBetweenWaves;
            return; 
        }

        countdown -= Time.deltaTime;
        countdown = Mathf.Clamp(countdown, 0f, Mathf.Infinity);
        
        waveCountDownText.text = string.Format("{0:00.00}", countdown);
    }

    IEnumerator Spawnwave()
    {
     //Debug.Log("Wave incoming!");
     
     
     PlayerStats.Rounds++;
     Wave wave = waves[waveIndex]; 
     
     EnemiesAlive = wave.count; 
     
         for (int i = 0; i < wave.count; i++)
         {
             spawnEnemy(wave.enemy);
             yield return new WaitForSeconds(1f/wave.rate); 
         }
         
     waveIndex++;

     if (waveIndex == waves.Length)
     {
         
         gameManager.WinLevel();
         this.enabled = false; 
     }
     
    }

    void spawnEnemy(GameObject enemy)
    {
        Instantiate(enemy, spawnPoint.position, spawnPoint.rotation);
        
    }
    
    
    
}
