using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpwanEnemy : MonoBehaviour
{
    public Transform Player;

    public float Distance;
    public float ChaseDistance;

    public GameObject EnemyPrefab;
    public Vector2 Spawnpoint;

    public float minX;
    public float maxX;
    public float minY;
    public float maxY;

    public GameObject[] Monster = new GameObject[4];

    public int EnemyNumber;
    public int MaxEnemySpawn;

    public void Start()
    {
        Spawnpoint = new Vector2(Random.Range(minX, maxX), Random.Range(minY, maxY));
        StartCoroutine(SpwanNumber());
    }

    public void Update()
    {
        EnemyNumber = GameObject.FindGameObjectsWithTag("Enemy").Length;   
    }

    private void SpawnEnemy()
    {
        GameObject A = Instantiate(EnemyPrefab) as GameObject;
        A.transform.position = Spawnpoint;
    }

    IEnumerator SpwanNumber()
    {
        while(EnemyNumber != MaxEnemySpawn)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(2F);
        }
    }
}
