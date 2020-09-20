using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class DamageBase : ComponentBase
{
    public float DamageStrength;
    
    public abstract void PerformDamage();
}
