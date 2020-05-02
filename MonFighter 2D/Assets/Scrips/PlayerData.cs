using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[System.Serializable]
public class PlayerData
{
    public float KillCount;

    public float[] position;

    public GameObject[] Monster = new GameObject[4];
    public PlayerData (Player player)
    {
        Monster = player.Monster;

        KillCount = player.Killcount;

        position = new float[2];
        position[0] = player.transform.position.x;
        position[1] = player.transform.position.y;
    }
}
