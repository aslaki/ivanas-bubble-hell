using System;
using UnityEngine;

public class WinScreen : MonoBehaviour
{

    [SerializeField]
    GameObject winScreen;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GameManager.Instance.OnRunesCollectionComplete += OnWin;
    }

    private void OnWin()
    {
        Time.timeScale = 0;
        winScreen.SetActive(true);
        GameManager.Instance.OnMenuOpen?.Invoke(GameManager.Menu.WinMenu);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnQuit()
    {
        Time.timeScale = 1;
        GameManager.Instance.Quit();
        GameManager.Instance.OnMenuClose?.Invoke(GameManager.Menu.WinMenu);
    }

    void Destroy()
    {
        GameManager.Instance.OnRunesCollectionComplete -= OnWin;
    }
}
