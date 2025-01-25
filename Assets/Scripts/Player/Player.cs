using UnityEngine;

public class Player : MonoBehaviour
{

    public int maxHealth = 100;
    public int currentHealth;

    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        if(currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        GameManager.Instance.OnPlayerDeath?.Invoke();
    }
}
