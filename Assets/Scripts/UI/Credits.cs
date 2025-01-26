using UnityEngine;

public class Credits : MonoBehaviour
{

    [SerializeField] private GameObject credits;

    void Start()
    {
        credits.SetActive(false);
    }

    private void Update()
    {
        if(credits.activeInHierarchy && Input.GetKeyUp(KeyCode.Escape))
        {
            CloseCredits();
        }
    }

    public void OpenCredits()
    {
        credits.SetActive(true);
    }

    public void CloseCredits()
    {
        credits.SetActive(false);
    }
}
