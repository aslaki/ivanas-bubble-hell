using UnityEngine;

public class Killzone : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(collision.gameObject);
    }
}
