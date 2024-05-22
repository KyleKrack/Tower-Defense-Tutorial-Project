using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
    public Transform enemyPrefab;

    public float timeBetweenWaves = 20.9f;

    private float countdown = 2f;

    private int waveIndex = 0;

    public TextMeshProUGUI waveCountDownText; 

    public Transform spawnPoint; 
    private void Update()
    {
        if (countdown <= 0f)
        {
            StartCoroutine(Spawnwave());
            countdown = timeBetweenWaves; 
        }

        countdown -= Time.deltaTime;
        countdown = Mathf.Clamp(countdown, 0f, Mathf.Infinity);
        
        waveCountDownText.text = string.Format("{0:00.00}", countdown);
    }

    IEnumerator Spawnwave()
    {
     //Debug.Log("Wave incoming!");

     waveIndex++;
     PlayerStats.Rounds++;
     
     for (int i = 0; i < waveIndex; i++)
     {
         spawnEnemy();
         yield return new WaitForSeconds(0.5f); 
     }
     
    
    }

    void spawnEnemy()
    {
        Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
    }
    
    
    
}
