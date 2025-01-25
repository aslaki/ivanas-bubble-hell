using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using static GameManager;

public class Player : MonoBehaviour
{
    
    public HashSet<Rune> collectedRunes = new HashSet<Rune>();

    public int maxHealth = 100;
    public int currentHealth;

    public int numberOfRunesRequired = 3;

    [SerializeField]
    Rigidbody2D cageBody;

    [SerializeField]
    CageController cageController;

    [SerializeField]
    BoxCollider2D startZoneCollider;

    Vector2 startPosition;

    private PlayerAudio playerAudio;

    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GameManager.Instance.OnPlayerHealthChange?.Invoke(currentHealth, maxHealth);
        playerAudio = FindObjectOfType<PlayerAudio>();
        startPosition = cageBody.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.K))
        {
            StartCoroutine(PlayWinSequence());
        }
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
        GameManager.Instance.OnCollectRune?.Invoke(rune, collectedRunes.ToArray());
        playerAudio.LockSoundEffects(); 

        if(collectedRunes.Count == numberOfRunesRequired)
        {
            StartCoroutine(PlayWinSequence());
        }

    }

    System.Collections.IEnumerator PlayWinSequence()
    {
        GameManager.Instance.OnSequenceStart?.Invoke(Sequence.Win);
        cageBody.excludeLayers = 1 << LayerMask.NameToLayer("Bubbles");
        cageController.disableInput = true;

        //Force body to return to start position
        cageBody.angularDamping = 50;
        cageBody.linearDamping = 50;
        cageBody.gravityScale = 20;

        //Wait until player is in start zone
        yield return WaitForPlayerInStartZone();

        //Wait for 2 seconds
        yield return WaitForSeconds(2);

        // Translate cage to start position
        cageBody.bodyType = RigidbodyType2D.Kinematic;
        cageBody.linearVelocity = Vector2.zero;
        cageBody.angularVelocity = 0;
        
        while(Vector2.Distance(cageBody.position, startPosition) > 0.1f)
        {
            cageBody.position = Vector2.MoveTowards(cageBody.position, startPosition, 0.1f);
            yield return null;
        }

        // Also rotate cage to 0 degrees
        while(Mathf.Abs(cageBody.rotation) > 0.1f)
        {
            cageBody.rotation = Mathf.MoveTowards(cageBody.rotation, 0, 0.1f);
            yield return null;
        }

        Debug.Log("Win sequence complete");
    }

    System.Collections.IEnumerator WaitForSeconds(float seconds)
    {
        yield return new WaitForSeconds(seconds);
    }

    System.Collections.IEnumerator WaitForPlayerInStartZone()
    {
        while(!startZoneCollider.IsTouching(cageBody.GetComponent<Collider2D>()))
        {
            yield return null;
        }
    }

    void Die()
    {
        GameManager.Instance.OnPlayerDeath?.Invoke();
    }
}
