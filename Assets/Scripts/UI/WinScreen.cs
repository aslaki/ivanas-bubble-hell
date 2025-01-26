using System;
using UnityEngine;
using static GameManager;

public class WinScreen : MonoBehaviour
{

    [SerializeField]
    GameObject winScreen;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GameManager.Instance.OnSequenceEnd += OnSequenceEnd;
    }

    private void OnSequenceEnd(Sequence sequencej)
    {
        if(sequencej != Sequence.Win)
        {
            return;
        }
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
        GameManager.Instance.ExitToMenu();
        GameManager.Instance.OnMenuClose?.Invoke(GameManager.Menu.WinMenu);
    }

    void Destroy()
    {
        GameManager.Instance.OnSequenceEnd -= OnSequenceEnd;
    }
}
