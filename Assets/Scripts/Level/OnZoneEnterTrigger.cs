using System;
using UnityEngine;

public class OnZoneEnterTrigger : MonoBehaviour
{

    public Action OnZoneEnter;

    private bool isTriggered;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.gameObject.CompareTag("Player"))
        {
            OnZoneEnter?.Invoke();
            isTriggered = true;
        }
    }
    
    void OnTriggerExit2D(Collider2D collider)
    {
        if(collider.gameObject.CompareTag("Player"))
        {
            isTriggered = false;
        }
    }
}
