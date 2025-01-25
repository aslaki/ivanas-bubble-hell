using UnityEngine;

public class GameSettings : MonoBehaviour
{
    [SerializeField] private GameObject settingsCanvas;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
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
}
