using System;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{

    [SerializeField]
    Image healthBarFill;

    void Awake()
    {
        healthBarFill.fillAmount = 1;
        GameManager.Instance.OnPlayerHealthChange += OnPlayerHealthChange;
    }

    private void OnPlayerHealthChange(int currentHealth, int maxHealth)
    {
        float fillAmount = (float)currentHealth / maxHealth;
        SetFillAmount(fillAmount);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetFillAmount(float fillAmountPercetage)
    {
        healthBarFill.fillAmount = fillAmountPercetage;
    }

    private void OnDestroy()
    {
        GameManager.Instance.OnPlayerHealthChange -= OnPlayerHealthChange;
    }
}
