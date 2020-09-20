using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Catch : ComponentBase
{
    public GameObject Target { get; private set; }
    public ComponentsManager TargetCm { get; private set; }
    public bool HasTargetCm => TargetCm != null;

    public PhysicsHolder PhysicsHolder;
    public TargetLayer[] LayersToCatch;

    public delegate void TriggeredOnDelegate();
    public delegate void TriggeredOffDelegate();

    public event TriggeredOnDelegate OnTriggeredOn;
    public event TriggeredOffDelegate OnTriggeredOff;

    void Start()
    {
        PhysicsHolder.CustomOnTriggerEnter2D += TriggeredOn;
        PhysicsHolder.CustomOnTriggerExit2D += TriggeredOff;
    }

    void TriggeredOn(Collider2D collision)
    {
        Target = collision.attachedRigidbody.gameObject;
        if (!CorrectLayer(Target))
        {
            Target = null;
            return;
        }

        TargetCm = Target.GetComponent<ComponentsManager>();
        
        OnTriggeredOn?.Invoke();
    }

    void TriggeredOff(Collider2D collision)
    {
        Target = null;
        TargetCm = null;
        OnTriggeredOff?.Invoke();
    }

    bool CorrectLayer(GameObject go)
    {
        if (LayersToCatch.Length == 0)
            return true;

        foreach (var item in LayersToCatch)
        {
            if (go.layer == (int)item)
                return true;
        }

        return false;
    }

    void OnDestroy()
    {
        PhysicsHolder.CustomOnTriggerEnter2D -= TriggeredOn;
        PhysicsHolder.CustomOnTriggerExit2D -= TriggeredOff;
    }
}

public enum TargetLayer
{
    Player = 8, Bullet = 9, Enemy = 10
}