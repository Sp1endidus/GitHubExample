using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputAI : InputBase
{
    Vector2 directionToPlayer;

    void Update()
    {
        if (GameManager.PlayerExists)
        {
            directionToPlayer = GameManager.Player.transform.position - transform.position;
            Direction.x = Vector2.SignedAngle(directionToPlayer, transform.up) / 180f;
        }
        else
            Direction.x = 0f;
    }
}
