using UnityEngine;

public class PauseMenu : MonoBehaviour
{


    [SerializeField]
    GameObject pauseMenu;

    [SerializeField] private GameSettings settings;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        pauseMenu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(!settings.isSettingsActive && Input.GetKeyDown(KeyCode.Escape))
        {
            TogglePause();
        }
    }

    public void OnPauseButton()
    {
        TogglePause();
    }

    public void OnExitToMenuButton()
    {
        GameManager.Instance.ExitToMenu();
    }

    public void OnQuitButton()
    {
        GameManager.Instance.Quit();
    }

    private void TogglePause() {
        if(Time.timeScale == 0)
        {
            Time.timeScale = 1;
            pauseMenu.SetActive(false);
        }
        else
        {
            Time.timeScale = 0;
            pauseMenu.SetActive(true);
        }
    }

}
