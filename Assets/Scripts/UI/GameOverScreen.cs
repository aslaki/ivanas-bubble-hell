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
        gameOverScreen.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Restart()
    {
        gameOverScreen.SetActive(false);
        GameManager.Instance.Restart();
    }

    public void Quit()
    {
        gameOverScreen.SetActive(false);
        GameManager.Instance.Quit();
    }

}
