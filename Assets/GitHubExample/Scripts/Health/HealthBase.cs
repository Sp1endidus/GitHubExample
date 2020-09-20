using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class HealthBase : ComponentBase
{
    public delegate void OnHealthChangedDelegate(float currentHealth);
    public event OnHealthChangedDelegate OnHealthChanged;

    public float HealthCurrent;
    public float HealthMax;
    [Range(0, 1)]
    public float Shield = 1f; //0 = immortal

    float startHealth;

    protected virtual void Start()
    {
        startHealth = HealthCurrent;
    }

    protected void ResetHealth()
    {
        HealthCurrent = startHealth;
    }

    public virtual void ChangeHealth(float amount)
    {
        HealthCurrent = Mathf.Clamp(HealthCurrent - amount * Shield, 0f, HealthMax);
        OnHealthChanged?.Invoke(HealthCurrent);
        if (Mathf.Approximately(HealthCurrent, 0f))
            ApplyDeath();
    }

    public abstract void ApplyDeath();
}
