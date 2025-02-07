using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;
using Unity.VisualScripting;
using System;
using System.Collections;
using UnityEngine.Serialization;
using static GameManager;
using System.Linq;

public class BubbleSpawner : MonoBehaviour
{

    public List<GameObject> spawnPoints = new List<GameObject>();

    [SerializeField] private GameObject[] bubbles;

    [SerializeField] private GameObject[] runeBubbles;

    [FormerlySerializedAs("firerate")]
    public float fireCooldown = 1;

    [SerializeField]
    float currentFireCooldown;

    public float cooldownTimeModifier = 0.2f;

    public float runeBubbleSpawnRate = 0.1f;

    public Rune[] collectedRunes = new Rune[0];

    public float runeBubbleStartSpawnInSec = 40;

    public float gamePlayTimer = 0;

    private bool isSpawning = true;

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

        GameManager.Instance.OnCollectRune += OnCollectRune;
        GameManager.Instance.OnSequenceStart += OnSequenceStart;

        StartCoroutine(StartDelay());
    }

    private void OnSequenceStart(GameManager.Sequence sequence)
    {
        if (sequence == GameManager.Sequence.Win)
        {
            isSpawning = false;
        }
    }

    public void SpawningStart()
    {
        if (isSpawning)
            RandomizeSpawnpoints(spawnPoints);
    }

    public void OnCollectRune(Rune rune, Rune[] collectedRunes)
    {
        this.collectedRunes = collectedRunes;
    }

    private void RandomizeSpawnpoints<T>(IList<T> spawnPoints)
    {
        int pointCount = spawnPoints.Count;

        System.Random random = new System.Random();

        for (int i = pointCount - 1; i > 1; i--)
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
        for (int i = 0; i < spawnPoints.Count; i++)
        {
            SpawnBubble(spawnPoints[i].transform);
            yield return new WaitForSeconds(currentFireCooldown);
            if (!isSpawning)
            {
                break;
            }
        }

        SpawningStart();
    }


    private void SpawnBubble(Transform spawnPoint)
    {
        int randomType;
        int randomMovement;
        float randomSpeed;

        GameObject bubble;


        // Rune bubbles custom spawn rate
        if (UnityEngine.Random.Range(0, 100) < runeBubbleSpawnRate * 100 && gamePlayTimer > runeBubbleStartSpawnInSec)
        {
            var filteredRuneBubbles = runeBubbles.Where(runeBubble => !collectedRunes.
            Contains(runeBubble.GetComponent<RuneBubble>().rune)).ToArray();
            if (filteredRuneBubbles.Length == 0)
            {
                return;
            }
            randomType = UnityEngine.Random.Range(0, filteredRuneBubbles.Length);
            bubble = Instantiate(filteredRuneBubbles[randomType], spawnPoint.transform.position, Quaternion.identity);
            Debug.Log("Rune bubble spawned: " + bubble.GetComponent<RuneBubble>().rune);
        }
        else
        {
            randomType = UnityEngine.Random.Range(0, bubbles.Length);
            bubble = Instantiate(bubbles[randomType], spawnPoint.transform.position, Quaternion.identity);
        }

        randomMovement = UnityEngine.Random.Range(0, 2);
        randomSpeed = UnityEngine.Random.Range(2, 5);

        if (randomMovement == 1)
        {
            bubble.AddComponent<BubbleWiggle>();
            bubble.GetComponent<BubbleWiggle>().speed = randomSpeed;
        }
        else
        {
            bubble.AddComponent<BubbleMover>();
            bubble.GetComponent<BubbleMover>().speed = randomSpeed;
        }
        bubble.GetComponentInChildren<SpriteRenderer>().gameObject.AddComponent<BubbleRotate>();
    }

    public void FixedUpdate()
    {
        currentFireCooldown = Mathf.Clamp(currentFireCooldown - (Time.deltaTime * cooldownTimeModifier),
         0.01f, fireCooldown);

        gamePlayTimer += Time.fixedDeltaTime;
    }

    public void OnDestroy()
    {
        GameManager.Instance.OnCollectRune -= OnCollectRune;
        GameManager.Instance.OnSequenceStart -= OnSequenceStart;
    }

    private IEnumerator StartDelay()
    {
        yield return new WaitForSeconds(3);
        SpawningStart();
    }


}
