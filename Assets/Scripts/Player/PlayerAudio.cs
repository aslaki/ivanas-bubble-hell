using UnityEngine;

public class PlayerAudio : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;

    [SerializeField] private AudioClip[] lockAudioClips;
    [SerializeField] private AudioClip cageDeath;
    [SerializeField] private AudioClip cageVictory;

    private int lockSoundState;

    public void LockSoundEffects()
    {
        if(lockSoundState == 0)
        {
            audioSource.clip = lockAudioClips[lockSoundState];
            audioSource.Play();
            lockSoundState++;
        }
        else if(lockSoundState == 1)
        {
            audioSource.clip = lockAudioClips[lockSoundState];
            audioSource.Play();
            lockSoundState++;
        }

        else if(lockSoundState == 2)
        {
            audioSource.clip = lockAudioClips[lockSoundState];
            audioSource.Play();
            lockSoundState++;
        }
    }

    public void CageDeathSound()
    {
        audioSource.clip = cageDeath;
        audioSource.Play();
    }

    public void CageVictorySound()
    {
        audioSource.clip = cageVictory;
        audioSource.Play();
    }
}
