using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
    public Transform enemyPrefab;

    public float timeBetweenWaves = 5.75f;

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
        waveCountDownText.text = Mathf.Round(countdown).ToString();
    }

    IEnumerator Spawnwave()
    {
     //Debug.Log("Wave incoming!");

     waveIndex++;
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
