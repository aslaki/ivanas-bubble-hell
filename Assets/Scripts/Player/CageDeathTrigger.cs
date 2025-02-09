using UnityEngine;

public class CageDeathTrigger : MonoBehaviour
{
    [SerializeField] private PlayerAudio playerAudio;
    [SerializeField] private GameObject cauldronSplash;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("CageKiller"))
        {
            playerAudio.CageDeathSound();
            Instantiate(cauldronSplash, transform.position, cauldronSplash.transform.rotation);
        }
    }
}
