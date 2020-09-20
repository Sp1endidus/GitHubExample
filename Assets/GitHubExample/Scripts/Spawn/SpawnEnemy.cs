using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : SpawnBase
{
    public GameObject[] Prefabs;

    public int MaxEnemies;

    Transform lastSpawnPoint;

    private void Update()
    {
        if (!cooldownInProgress)
            Spawn();
    }

    public override void Spawn()
    {
        if (CurrentSpawnedCount() < MaxEnemies)
        {
            base.Spawn();

            lastSpawnPoint = SpawnPoints[Random.Range(0, SpawnPoints.Length)];
            lastSpawned.transform.SetPositionAndRotation(lastSpawnPoint.position, lastSpawnPoint.rotation);
        }

        StartCoroutine(PerformCooldown());
    }

    public override GameObject GetPrefab() => Prefabs[Random.Range(0, Prefabs.Length)];
}
