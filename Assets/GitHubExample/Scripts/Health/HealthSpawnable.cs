using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthSpawnable : HealthBase
{
    public Spawnable Spawnable;

    protected override void Start()
    {
        base.Start();
        Spawnable.OnSpawn += ResetHealth;
    }

    public override void ApplyDeath()
    {
        Spawnable.Despawn();
    }

    void OnDestroy()
    {
        Spawnable.OnSpawn -= ResetHealth;
    }
}
