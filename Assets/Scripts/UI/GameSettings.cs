using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class GameSettings : MonoBehaviour
{
    [SerializeField] private GameObject settingsCanvas;

    [SerializeField] private Slider musicSlider;
    [SerializeField] private Slider soundSlider;

    [SerializeField] private AudioMixer audioMixer;

    public bool isSettingsActive;

    private GameManager gameManager;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();

        settingsCanvas.SetActive(false);
    }

    private void Update()
    {
        if (isSettingsActive && Input.GetKeyUp(KeyCode.Escape))
        {
            CloseSettings();
        }
    }

    public void OpenSettings()
    {
        settingsCanvas.SetActive(true);
        isSettingsActive= true; 
    }

    public void CloseSettings()
    {
        settingsCanvas.SetActive(false);
        isSettingsActive = false;
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
