using System;
using UnityEngine;

public class GameOverScreen : MonoBehaviour
{

    [SerializeField]
    GameObject gameOverScreen;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GameManager.Instance.OnPlayerDeath += OnGameOver;
        gameOverScreen.SetActive(false);
    }

    private void OnGameOver()
    {
        Time.timeScale = 0;
        gameOverScreen.SetActive(true);
        GameManager.Instance.OnMenuOpen?.Invoke(GameManager.Menu.GameOverMenu);
    }

    public void Restart()
    {
        Time.timeScale = 1;
        gameOverScreen.SetActive(false);
        GameManager.Instance.Restart();
        GameManager.Instance.OnMenuClose?.Invoke(GameManager.Menu.GameOverMenu);
    }

    public void Quit()
    {
        Time.timeScale = 1;
        gameOverScreen.SetActive(false);
        GameManager.Instance.Quit();
        GameManager.Instance.OnMenuClose?.Invoke(GameManager.Menu.GameOverMenu);
    }

    private void OnDestroy()
    {
        GameManager.Instance.OnPlayerDeath -= OnGameOver;
    }

}
