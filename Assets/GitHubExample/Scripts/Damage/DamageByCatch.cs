using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageByCatch : DamageBase
{
    public Catch Catch;

    HealthBase healthBase;
    float lastDamagePerformedTime;

    void Start()
    {
        Catch.OnTriggeredOn += PerformDamage;
    }

    public override void PerformDamage()
    {
        if (Mathf.Approximately(lastDamagePerformedTime, Time.time))
            return;

        if (Catch.HasTargetCm)
        {
            healthBase = (HealthBase)Catch.TargetCm.ComponentAssignable<HealthBase>();
            if (healthBase)
                healthBase.ChangeHealth(DamageStrength);
            lastDamagePerformedTime = Time.time;
        }
    }

    void OnDestroy()
    {
        Catch.OnTriggeredOn -= PerformDamage;
    }
}
