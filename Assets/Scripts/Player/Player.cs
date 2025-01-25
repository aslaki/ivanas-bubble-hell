using System.Collections.Generic;
using UnityEngine;
using static GameManager;

public class Player : MonoBehaviour
{
    
    public HashSet<Rune> collectedRunes = new HashSet<Rune>();

    public int maxHealth = 100;
    public int currentHealth;

    public int numberOfRunesRequired = 3;

    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GameManager.Instance.OnPlayerHealthChange?.Invoke(currentHealth, maxHealth);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        GameManager.Instance.OnPlayerHealthChange?.Invoke(currentHealth, maxHealth);
        if(currentHealth <= 0)
        {
            Die();
        }
        
    }

    public void OnCollectRune(Rune rune)
    {
        collectedRunes.Add(rune);
        GameManager.Instance.OnCollectRune?.Invoke(rune);
        if(collectedRunes.Count == numberOfRunesRequired)
        {
            GameManager.Instance.OnRunesCollectionComplete?.Invoke();
        }

    }

    void Die()
    {
        GameManager.Instance.OnPlayerDeath?.Invoke();
    }
}
