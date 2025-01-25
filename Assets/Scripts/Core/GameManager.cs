using System;
using UnityEngine;
using UnityEngine.Android;

public class GameManager : MonoBehaviour
{
    private static GameManager gameManager;

    public static GameManager Instance
    {
        get
        {
            return gameManager;
        }
    }

    public Action OnPlayerDeath;

    public float musicVolume;
    public float soundVolume;

    public void Awake() {
        if(gameManager != null) {
            Destroy(gameObject);
        }
        else {
            DontDestroyOnLoad(gameObject);
            gameManager = this;
        }

    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Restart()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Level1_Main");
    }

    public void ExitToMenu()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("TitleScreen");
    }

    public void Quit()
    {
        Application.Quit();
    }
}
