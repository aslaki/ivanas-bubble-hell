using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class GameSettings : MonoBehaviour
{
    [SerializeField] private GameObject settingsCanvas;

    [SerializeField] private Slider musicSlider;
    [SerializeField] private Slider soundSlider;

    [SerializeField] private AudioMixer audioMixer;

    private GameManager gameManager;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();

        settingsCanvas.SetActive(false);
    }

    public void OpenSettings()
    {
        settingsCanvas.SetActive(true);
    }

    public void CloseSettings()
    {
        settingsCanvas.SetActive(false);    
    }

    public void SetMusicVolume(float musicVolume)
    {
        audioMixer.SetFloat("MusicVolume", musicVolume);
        gameManager.musicVolume= musicVolume;   
    }

    public void SetSoundVolume(float soundVolume)
    {
        audioMixer.SetFloat("SoundVolume", soundVolume);
        gameManager.soundVolume= soundVolume;
    }


}
