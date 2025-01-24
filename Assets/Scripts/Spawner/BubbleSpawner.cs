using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;

public class BubbleSpawner : MonoBehaviour
{

    public List<GameObject> spawnPoints = new List<GameObject>();

    [SerializeField] private GameObject[] bubbles;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        SpawnBubble();
    }

    private void SpawnBubble()
    {
        Instantiate(bubbles[0], spawnPoints[0].transform);
    }

   
}
