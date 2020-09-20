using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthDestroyable : HealthBase
{
    public GameObject RootObject;

    public override void ApplyDeath()
    {
        Destroy(RootObject);
    }
}
