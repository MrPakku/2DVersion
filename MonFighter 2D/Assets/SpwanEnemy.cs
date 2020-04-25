using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpwanEnemy : MonoBehaviour
{
    public Transform Player;

    public float Distance;
    public float ChaseDistance;

    public GameObject Enemy;
    public GameObject Spawnpoint;

    public Units[] Monster = new Units[4];

}
