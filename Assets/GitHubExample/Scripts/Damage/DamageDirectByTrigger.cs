using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageDirectByTrigger : DamageBase
{
    public Catch Catch;
    public HealthBase HealthBase;

    void Start()
    {
        Catch.OnTriggeredOn += PerformDamage;
    }

    public override void PerformDamage()
    {
        HealthBase.ChangeHealth(DamageStrength);
    }

    void OnDestroy()
    {
        Catch.OnTriggeredOn -= PerformDamage;
    }
}
