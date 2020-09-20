using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageDirect : DamageBase
{
    public Spawnable Spawnable;
    public HealthBase HealthBase;
    public float Delay;
    public bool Repeat;

    bool isRunning;

    void Start()
    {
        Spawnable.OnSpawn += StartDirectDamage;
        StartDirectDamage();
    }

    void StartDirectDamage()
    {
        if (!isRunning)
            StartCoroutine(DelayBeforeDamage());
    }

    IEnumerator DelayBeforeDamage()
    {
        isRunning = true;
        yield return new WaitForSeconds(Delay);
        PerformDamage();
        isRunning = false;

        if (Repeat)
        {
            StartCoroutine(DelayBeforeDamage());
        }
    }

    public override void PerformDamage()
    {
        HealthBase.ChangeHealth(DamageStrength);
    }

    void OnDestroy()
    {
        Spawnable.OnSpawn -= StartDirectDamage;
    }
}
