using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public HealthBase Health;

    void Start()
    {
        Health.OnHealthChanged += HealthChanged;
    }

    void HealthChanged(float currentHealth)
    {
        if (Mathf.Approximately(currentHealth, 0f))
            GameManager.PlayerExists = false;
    }

    void OnDestroy()
    {
        Health.OnHealthChanged -= HealthChanged;
    }
}
