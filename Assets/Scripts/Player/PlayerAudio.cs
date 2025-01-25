using UnityEngine;

public class PlayerAudio : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;

    [SerializeField] private AudioClip[] lockAudioClips;

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
}
