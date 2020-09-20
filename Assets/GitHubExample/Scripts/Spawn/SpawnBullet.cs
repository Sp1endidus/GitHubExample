using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBullet : SpawnBase
{
    public GameObject Prefab;
    public bool Enabled;

    public override void Spawn()
    {
        if (Enabled && !cooldownInProgress)
        {
            foreach (var item in SpawnPoints)
            {
                base.Spawn();
                lastSpawned.transform.SetPositionAndRotation(item.position, item.rotation);
            }

            StartCoroutine(PerformCooldown());
        }
    }

    public override GameObject GetPrefab() => Prefab;
}