using System;
using System.Collections;
using Mono.Cecil;
using UnityEngine;

public class CageLocks : MonoBehaviour
{
    public GameObject fireRune;
    public GameObject waterRune;
    public GameObject earthRune;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GameManager.Instance.OnCollectRune += OnCollectRune;
        GameManager.Instance.OnRunesCollectionComplete += OnRunesCollectionComplete;
        OnCollectRune(GameManager.Rune.Fire, new GameManager.Rune[0]);
    }

    private void OnRunesCollectionComplete()
    {
        StartCoroutine(HideLocks());
    }

    private IEnumerator HideLocks()
    {
        //Wait for 2 seconds
        yield return new WaitForSeconds(2);
        this.gameObject.SetActive(false);
    }

    private void OnCollectRune(GameManager.Rune rune, GameManager.Rune[] arg2)
    {
        GameObject runeObject;
        switch(rune)
        {
            case GameManager.Rune.Fire:
                runeObject = fireRune;
                break;
            case GameManager.Rune.Water:
                runeObject = waterRune;
                break;
            case GameManager.Rune.Earth:
                runeObject = earthRune;
                break;
            default:
                return;
        }

        var part1 = runeObject.transform.GetChild(0).gameObject;
        var part2 = runeObject.transform.GetChild(1).gameObject;

        StartCoroutine(MoveRunePart(part1, new Vector2(part1.transform.position.x - 0.03f, part1.transform.position.y)));
        StartCoroutine(MoveRunePart(part2, new Vector2(part2.transform.position.x + 0.03f, part2.transform.position.y)));

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnDestroy()
    {
        GameManager.Instance.OnCollectRune -= OnCollectRune;
    }

    IEnumerator MoveRunePart(GameObject gameObject, Vector2 position)
    {
        float t = 0;

        Vector2 startPosition = gameObject.transform.position;

        while(t < 1)
        {
            t += Time.deltaTime / 1;
            gameObject.transform.position = Vector2.Lerp(startPosition, position, t);
            yield return null;
        }
        
    }


}
