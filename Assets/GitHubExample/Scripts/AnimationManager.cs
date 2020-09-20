using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationManager : MonoBehaviour
{
    public Animator Animator;
    public HealthBase HealthBase;

    public string DamagedState;

    void Start()
    {
        HealthBase.OnHealthChanged += Damaged;
    }

    void Damaged(float amount)
    {
        Animator.SetTrigger(DamagedState);
    }

    void OnDestroy()
    {
        HealthBase.OnHealthChanged -= Damaged;
    }
}
