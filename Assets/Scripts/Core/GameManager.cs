using System;
using UnityEngine;
using UnityEngine.Android;

[DefaultExecutionOrder(-99999)]
public class GameManager : MonoBehaviour
{
    public enum Rune { Fire, Water, Earth };

    public enum Menu { GameOverMenu, WinMenu };

    public enum Sequence { Win, Lose };

    private static GameManager gameManager;

    public static GameManager Instance
    {
        get
        {
            return gameManager;
        }
    }

    public Action OnPlayerDeath;

    // Parameters are current health value and maximum health value
    public Action<int, int> OnPlayerHealthChange;

    // Parameters are the rune that was collected and the list of all runes collected so far
    public Action<Rune, Rune[]> OnCollectRune;

    public Action<Menu> OnMenuOpen;

    public Action<Menu> OnMenuClose;

    public Action<Sequence> OnSequenceStart;

    public Action<Sequence> OnSequenceEnd;

    public Action OnRunesCollectionComplete;

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
