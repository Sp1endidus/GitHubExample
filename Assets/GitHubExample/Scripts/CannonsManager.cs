using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonsManager : MonoBehaviour
{
    public Cannon[] Cannons;

    public int CurrentCannon;
    public SpriteRenderer TargetCannonSprite;

    public void SwitchCannon(bool forward)
    {
        if (forward)
        {
            CurrentCannon = (CurrentCannon + 1) % Cannons.Length;
        }
        else
        {
            CurrentCannon = (CurrentCannon + Cannons.Length - 1) % Cannons.Length;
        }

        TargetCannonSprite.sprite = Cannons[CurrentCannon].CannonSprite;
    }

    public void PerformShoot()
    {
        Cannons[CurrentCannon].SpawnBullet.Spawn();
    }
}

[System.Serializable]
public class Cannon
{
    public SpawnBullet SpawnBullet;
    public Sprite CannonSprite;
}
