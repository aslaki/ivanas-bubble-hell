using UnityEngine;

public class DamageBubble : MonoBehaviour
{

    [SerializeField]
    int damage;
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
            player.TakeDamage(damage);
        }
    }
}
