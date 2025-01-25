using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleScreen : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene("Level1_Main");
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
