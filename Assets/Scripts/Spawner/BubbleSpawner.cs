using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;
using Unity.VisualScripting;
using System;
using System.Collections;

public class BubbleSpawner : MonoBehaviour
{

    public List<GameObject> spawnPoints = new List<GameObject>();

    [SerializeField] private GameObject[] bubbles;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        SpawningStart();
    }

    public void SpawningStart()
    {
        RandomizeSpawnpoints(spawnPoints);
    }

    private void RandomizeSpawnpoints<T>(IList<T> spawnPoints)
    {
        int pointCount = spawnPoints.Count;

        System.Random random = new System.Random();

        for(int i = pointCount - 1; i > 1; i--)
        {
            int rnd = random.Next(i + 1);

            T value = spawnPoints[rnd];
            spawnPoints[rnd] = spawnPoints[i];
            spawnPoints[i] = value;
        }  
        StartCoroutine(LaunchSpawningSequence());
    }

    private IEnumerator LaunchSpawningSequence()
    {
        for (int i = 0; i < spawnPoints.Count; i++ )
        {
            SpawnBubble(spawnPoints[i].transform);
            yield return new WaitForSeconds(1);
        }

        SpawningStart();
    }

 
    private void SpawnBubble(Transform spawnPoint)
    {
        Instantiate(bubbles[0], spawnPoint.transform);
    }

   
}
