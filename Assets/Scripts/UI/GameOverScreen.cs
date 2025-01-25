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
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Restart()
    {
        Time.timeScale = 1;
        gameOverScreen.SetActive(false);
        GameManager.Instance.Restart();
    }

    public void Quit()
    {
        Time.timeScale = 1;
        gameOverScreen.SetActive(false);
        GameManager.Instance.Quit();
    }

    private void OnDestroy()
    {
        GameManager.Instance.OnPlayerDeath -= OnGameOver;
    }

}
