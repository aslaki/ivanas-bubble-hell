using System;
using System.Collections;
using UnityEngine;

public class RuneIndicator : MonoBehaviour
{

    [SerializeField]
    private GameObject glowingRune;

    [SerializeField]
    private GameManager.Rune rune;

    public float fadeInSpeed = 1.5f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GameManager.Instance.OnCollectRune += OnCollectRune;
        glowingRune.SetActive(false);
    }

    private void OnCollectRune(GameManager.Rune rune, GameManager.Rune[] arg2)
    {
        if (rune != this.rune)
        {
            return;
        }
        //Fade in the rune
        StartCoroutine(FadeInRune(glowingRune.GetComponent<SpriteRenderer>()));
    }

    private IEnumerator FadeInRune(SpriteRenderer renderer)
    {
        Color color = renderer.color;
        color.a = 0;
        renderer.color = color;
        glowingRune.SetActive(true);

        while (renderer.color.a < 1.0f)
        {
            color.a += fadeInSpeed * Time.deltaTime;
            renderer.color = color;
            yield return null;
        }

        color.a = 1.0f;
        renderer.color = color;
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnDestroy()
    {
        GameManager.Instance.OnCollectRune -= OnCollectRune;
    }


}
