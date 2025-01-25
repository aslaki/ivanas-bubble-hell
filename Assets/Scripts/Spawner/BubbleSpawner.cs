using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;
using Unity.VisualScripting;
using System;
using System.Collections;
using UnityEngine.Serialization;

public class BubbleSpawner : MonoBehaviour
{

    public List<GameObject> spawnPoints = new List<GameObject>();

    [SerializeField] private GameObject[] bubbles;

    [FormerlySerializedAs("firerate")]
    public float fireCooldown = 1;

    [SerializeField]
    float currentFireCooldown;

    public float cooldownTimeModifier = 0.2f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentFireCooldown = fireCooldown;
        spawnPoints = new List<GameObject>();   
        //Fetch all spawnpoints (child objects) of the spawner
        foreach (Transform child in transform)
        {
            spawnPoints.Add(child.gameObject);
        }

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
            yield return new WaitForSeconds(currentFireCooldown);
        }

        SpawningStart();
    }

 
    private void SpawnBubble(Transform spawnPoint)
    {
        int randomType;
        int randomMovement;
        float randomSpeed;

        randomType = UnityEngine.Random.Range(0, bubbles.Length);
        var bubble = Instantiate(bubbles[randomType], spawnPoint.transform.position, Quaternion.identity);

        randomMovement = UnityEngine.Random.Range(0, 2);
        randomSpeed = UnityEngine.Random.Range(2, 5);

        if(randomMovement == 1)
        {
            bubble.AddComponent<BubbleWiggle>();  
            bubble.GetComponent<BubbleWiggle>().speed = randomSpeed;    
        }
        else
        {
            bubble.AddComponent<BubbleMover>();
            bubble.GetComponent<BubbleMover>().speed = randomSpeed;
        }
    }

    public void FixedUpdate()
    {
        currentFireCooldown = Mathf.Clamp(currentFireCooldown - (Time.deltaTime * cooldownTimeModifier),
         0.01f, fireCooldown);
    }

   
}
