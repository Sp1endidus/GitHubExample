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
        if (Mathf.Approximately(lastDamagePerformedTime, Time.time)) // Во избежание повторного урона для объектов с несколькими коллайдерами (можно и через bool, но тогда придется делать связь со спавн менеджером и сбрасывать при каждом спавне)
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
