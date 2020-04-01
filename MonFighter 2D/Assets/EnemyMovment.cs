using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovment : MonoBehaviour
{
    //Move Rdm
    public float StartwaitTime;
    private float waitTime;
    public float MoveSpeed;

    public float minX;
    public float maxX;
    public float minY;
    public float maxY;

    public Transform Enemy;
    public Transform Spot;

    //private Vector2 movment;

    void Start()
    {
        waitTime = StartwaitTime;

        Spot.position = new Vector2(Random.Range(minX, maxX), Random.Range(minY, maxY));
    }


    void Update()
    {
        Enemy.position = Vector2.MoveTowards(Enemy.position, Spot.position, MoveSpeed * Time.deltaTime);
        Enemy.rotation.SetFromToRotation(Enemy.position, Spot.position);
        Debug.Log(Enemy.rotation);

        

        if (Vector2.Distance(Enemy.position, Spot.position) < 0.2f)
        {
            if (waitTime <= 0)
            {
                Spot.position = new Vector2(Random.Range(minX, maxX), Random.Range(minY, maxY));
                waitTime = StartwaitTime;

            }
            else { waitTime -= Time.deltaTime; }
        }
    }
}
