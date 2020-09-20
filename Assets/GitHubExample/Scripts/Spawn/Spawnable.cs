using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawnable : MonoBehaviour
{
    public delegate void OnSpawnDelegate();
    public event OnSpawnDelegate OnSpawn;

    SpawnBase spawnBase;
    bool inited;

    public void Init(SpawnBase spawnBase)
    {
        this.spawnBase = spawnBase;
        inited = true;
    }

    public void Spawn()
    {
        if (inited)
            OnSpawn?.Invoke();
    }

    public void Despawn()
    {
        if (inited)
            spawnBase.Despawn(this);
    }
}
