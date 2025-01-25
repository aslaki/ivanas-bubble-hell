using UnityEngine;
using static GameManager;

public class RuneBubble : MonoBehaviour
{
    [SerializeField]
    public Rune rune;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            Player player = collision.gameObject.GetComponentInParent<Player>();
            player.OnCollectRune(rune);
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.gameObject.CompareTag("Player"))
        {
            Player player = collider.gameObject.GetComponentInParent<Player>();
            player.OnCollectRune(rune);
            Destroy(gameObject);
        }
    }
}
