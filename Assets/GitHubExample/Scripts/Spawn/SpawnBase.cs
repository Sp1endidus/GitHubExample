using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SpawnBase : ComponentBase
{
    public int Amount;
    public Transform[] SpawnPoints;
    public float Cooldown = 1f;

    protected List<Spawnable> objects;
    protected Spawnable lastSpawned;
    protected int currentSpawnIndex = -1;
    protected bool cooldownInProgress;

    void Start()
    {
        objects = new List<Spawnable>(Amount);
        for (int i = 0; i < Amount; i++)
        {
            AddNewObjectToPool();
        }
    }

    public virtual void Spawn()
    {
        int index = NextSpawnIndex();
        objects[index].gameObject.SetActive(true);
        objects[index].Spawn();

        lastSpawned = objects[index];
    }

    public virtual void Despawn(Spawnable obj)
    {
        for (int i = 0; i < objects.Count; i++)
        {
            if (objects[i] == obj)
            {
                objects[i].gameObject.SetActive(false);
                return;
            }
        }
    }

    public int NextSpawnIndex()
    {
        currentSpawnIndex = (currentSpawnIndex + 1) % Amount;
        if (!objects[currentSpawnIndex].gameObject.activeSelf)
        {
            return currentSpawnIndex;
        }
        else
        {
            for (int i = 0; i < objects.Count; i++)
            {
                if (!objects[i].gameObject.activeSelf)
                {
                    return i;
                }
            }
        }

        AddNewObjectToPool(true);
        return objects.Count - 1;
    }

    public void AddNewObjectToPool(bool increaseAmount = false)
    {
        GameObject spawned = Instantiate(GetPrefab());
        Spawnable spawnable = spawned.GetComponent<Spawnable>();
        if (!spawnable)
        {
            spawnable = spawned.AddComponent<Spawnable>();
        }
        spawnable.Init(this);

        objects.Add(spawnable);
        objects[objects.Count - 1].gameObject.SetActive(false);
        if (increaseAmount)
            Amount++;
    }

    public abstract GameObject GetPrefab();

    protected IEnumerator PerformCooldown()
    {
        cooldownInProgress = true;
        yield return new WaitForSeconds(Cooldown);
        cooldownInProgress = false;
    }

    public int CurrentSpawnedCount()
    {
        int result = 0;
        foreach (var item in objects)
        {
            if (item.gameObject.activeSelf)
                result++;
        }
        return result;
    }
}
