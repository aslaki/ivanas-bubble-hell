using UnityEngine;

public class CageDeathTrigger : MonoBehaviour
{
    [SerializeField] private PlayerAudio playerAudio;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("CageKiller"))
        {
            playerAudio.CageDeathSound();
        }
    }
}
